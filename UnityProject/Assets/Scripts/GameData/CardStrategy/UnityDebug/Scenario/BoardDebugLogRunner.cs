using GameData.CardStrategy.Core;
using UnityEngine;

namespace GameData.CardStrategy.UnityDebug
{
    /// <summary>
    /// タスク03の補助確認用にBoardStateの基本情報をUnity Consoleへ出力します。
    /// </summary>
    public sealed class BoardDebugLogRunner : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Play開始時にBoardStateの補助確認ログをConsoleへ出力するかどうかを制御します。")]
        private bool logOnStart = true;

        private void Start()
        {
            if (logOnStart)
            {
                WriteBoardDebugLog();
            }
        }

        /// <summary>
        /// BoardStateの生成結果と基本判定をDebug.Logへ出力します。
        /// </summary>
        public void WriteBoardDebugLog()
        {
            BoardState boardState = new BoardState();
            BoardPosition enemyHomeLane1Position = new BoardPosition(BoardRowType.EnemyHome, BoardLaneType.Lane1);
            BoardPosition outsideUpperLane1Position = new BoardPosition((BoardRowType)(-1), BoardLaneType.Lane1);
            BoardPosition playerHomeOutsideRightPosition = new BoardPosition(BoardRowType.PlayerHome, (BoardLaneType)5);

            Debug.Log(
                $"[BoardDebug] Board generated. RowCount={boardState.RowCount}, LaneCount={boardState.LaneCount}, CellCount={boardState.CellCount}");
            Debug.Log(
                $"[BoardDebug] PlayerHomeRow={boardState.GetHomeRow(FactionType.Player)}, EnemyHomeRow={boardState.GetHomeRow(FactionType.Enemy)}");
            Debug.Log($"[BoardDebug] PlayerForwardDelta={boardState.GetForwardRowDelta(FactionType.Player)}");
            Debug.Log($"[BoardDebug] EnemyForwardDelta={boardState.GetForwardRowDelta(FactionType.Enemy)}");
            Debug.Log($"[BoardDebug] IsInside({enemyHomeLane1Position})={boardState.IsInside(enemyHomeLane1Position)}");
            Debug.Log($"[BoardDebug] IsInside({outsideUpperLane1Position})={boardState.IsInside(outsideUpperLane1Position)}");
            Debug.Log($"[BoardDebug] IsInside({playerHomeOutsideRightPosition})={boardState.IsInside(playerHomeOutsideRightPosition)}");
        }
    }
}
