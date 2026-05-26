using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameData.CardStrategy.UnityDebug
{
    /// <summary>
    /// BoardStateの状態をCanvas上の6×5簡素グリッドとして表示します。
    /// </summary>
    [RequireComponent(typeof(GridLayoutGroup))]
    public sealed class BoardDebugGridView : MonoBehaviour
    {
        private const string CellObjectNamePrefix = "Cell_";

        [SerializeField]
        [Tooltip("Play開始時にBoardStateから30個の仮セルを自動生成するかどうかを制御します。")]
        private bool rebuildOnStart = true;

        [SerializeField]
        [Tooltip("仮セルを生成するGridLayoutGroupです。未設定の場合は同じGameObjectのGridLayoutGroupを使用します。")]
        private GridLayoutGroup targetGridLayoutGroup;

        [SerializeField]
        [Tooltip("各仮セル内のTextに使用するフォントです。未設定の場合はUnity組み込みフォントを使用します。")]
        private Font cellTextFont;

        [SerializeField]
        [Tooltip("各仮セルの背景色です。タスク03のデバッグ盤面表示にのみ影響します。")]
        private Color cellBackgroundColor = new Color(0.92f, 0.92f, 0.92f, 1f);

        [SerializeField]
        [Tooltip("各仮セルの文字色です。タスク03のデバッグ盤面表示にのみ影響します。")]
        private Color cellTextColor = Color.black;

        private readonly List<GameObject> generatedCellObjects = new List<GameObject>();

        /// <summary>
        /// 直近の生成で作られた仮セルGameObject一覧を返します。
        /// </summary>
        public IReadOnlyList<GameObject> GeneratedCellObjects => generatedCellObjects;

        private void Awake()
        {
            EnsureGridLayoutGroup();
        }

        private void Start()
        {
            if (rebuildOnStart)
            {
                Rebuild();
            }
        }

        /// <summary>
        /// 新しいBoardStateから簡素グリッドを再生成します。
        /// </summary>
        public void Rebuild()
        {
            Rebuild(new BoardState());
        }

        /// <summary>
        /// 指定されたBoardStateから簡素グリッドを再生成します。
        /// </summary>
        public void Rebuild(BoardState boardState)
        {
            EnsureGridLayoutGroup();
            ConfigureGridLayoutGroup();
            ClearGeneratedCells();

            IReadOnlyList<BoardDebugSnapshot> snapshots = BoardDebugSnapshot.CreateAll(boardState);
            foreach (BoardDebugSnapshot snapshot in snapshots)
            {
                generatedCellObjects.Add(CreateCellObject(snapshot));
            }
        }

        /// <summary>
        /// 生成済みの仮セルを削除します。
        /// </summary>
        public void ClearGeneratedCells()
        {
            for (int childIndex = targetGridLayoutGroup.transform.childCount - 1; childIndex >= 0; childIndex--)
            {
                Transform childTransform = targetGridLayoutGroup.transform.GetChild(childIndex);
                if (childTransform.name.StartsWith(CellObjectNamePrefix))
                {
                    DestroyCellObject(childTransform.gameObject);
                }
            }

            generatedCellObjects.Clear();
        }

        private void EnsureGridLayoutGroup()
        {
            if (targetGridLayoutGroup == null)
            {
                targetGridLayoutGroup = GetComponent<GridLayoutGroup>();
            }
        }

        private void ConfigureGridLayoutGroup()
        {
            targetGridLayoutGroup.startCorner = GridLayoutGroup.Corner.UpperLeft;
            targetGridLayoutGroup.startAxis = GridLayoutGroup.Axis.Horizontal;
            targetGridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            targetGridLayoutGroup.constraintCount = BoardState.DisplayLanes.Count;

            if (targetGridLayoutGroup.cellSize == Vector2.zero)
            {
                targetGridLayoutGroup.cellSize = new Vector2(160f, 96f);
            }

            if (targetGridLayoutGroup.spacing == Vector2.zero)
            {
                targetGridLayoutGroup.spacing = new Vector2(4f, 4f);
            }
        }

        private GameObject CreateCellObject(BoardDebugSnapshot snapshot)
        {
            GameObject cellObject = new GameObject(
                $"{CellObjectNamePrefix}{snapshot.RowName}_{snapshot.LaneName}",
                typeof(RectTransform),
                typeof(Image));
            cellObject.transform.SetParent(targetGridLayoutGroup.transform, false);

            Image cellImage = cellObject.GetComponent<Image>();
            cellImage.color = cellBackgroundColor;

            GameObject textObject = new GameObject("CellText", typeof(RectTransform), typeof(Text));
            textObject.transform.SetParent(cellObject.transform, false);

            RectTransform textRectTransform = textObject.GetComponent<RectTransform>();
            textRectTransform.anchorMin = Vector2.zero;
            textRectTransform.anchorMax = Vector2.one;
            textRectTransform.offsetMin = new Vector2(4f, 4f);
            textRectTransform.offsetMax = new Vector2(-4f, -4f);

            Text cellText = textObject.GetComponent<Text>();
            cellText.text = snapshot.ToMultilineText();
            cellText.font = ResolveCellTextFont();
            cellText.color = cellTextColor;
            cellText.alignment = TextAnchor.MiddleCenter;
            cellText.horizontalOverflow = HorizontalWrapMode.Wrap;
            cellText.verticalOverflow = VerticalWrapMode.Truncate;
            cellText.resizeTextForBestFit = true;
            cellText.resizeTextMinSize = 8;
            cellText.resizeTextMaxSize = 14;

            return cellObject;
        }

        private Font ResolveCellTextFont()
        {
            if (cellTextFont != null)
            {
                return cellTextFont;
            }

            Font legacyRuntimeFont = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            if (legacyRuntimeFont != null)
            {
                cellTextFont = legacyRuntimeFont;
                return cellTextFont;
            }

            cellTextFont = Resources.GetBuiltinResource<Font>("Arial.ttf");
            return cellTextFont;
        }

        private static void DestroyCellObject(GameObject cellObject)
        {
            if (Application.isPlaying)
            {
                Destroy(cellObject);
            }
            else
            {
                DestroyImmediate(cellObject);
            }
        }
    }
}
