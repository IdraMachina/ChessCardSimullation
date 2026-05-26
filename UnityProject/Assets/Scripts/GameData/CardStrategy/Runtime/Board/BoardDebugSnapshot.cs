using System;
using System.Collections.Generic;

namespace GameData.CardStrategy
{
    /// <summary>
    /// DebugLogや簡素GUIに渡すための盤面表示用データです。
    /// </summary>
    public sealed class BoardDebugSnapshot
    {
        private const string EmptyUnitDisplayText = "Empty";
        private const string NoneLayerDisplayText = "None";

        private BoardDebugSnapshot(
            BoardPosition position,
            string rowName,
            string laneName,
            string unitDisplayText,
            string terrainDisplayText,
            string tileEffectDisplayText,
            string relicDisplayText)
        {
            Position = position;
            RowName = rowName;
            LaneName = laneName;
            UnitDisplayText = unitDisplayText;
            TerrainDisplayText = terrainDisplayText;
            TileEffectDisplayText = tileEffectDisplayText;
            RelicDisplayText = relicDisplayText;
        }

        /// <summary>
        /// 表示対象の盤面座標です。
        /// </summary>
        public BoardPosition Position { get; }

        /// <summary>
        /// 盤面列名です。
        /// </summary>
        public string RowName { get; }

        /// <summary>
        /// 盤面レーン名です。
        /// </summary>
        public string LaneName { get; }

        /// <summary>
        /// ユニット枠の表示文字列です。
        /// </summary>
        public string UnitDisplayText { get; }

        /// <summary>
        /// 地形変化枠の表示文字列です。
        /// </summary>
        public string TerrainDisplayText { get; }

        /// <summary>
        /// マス効果枠の表示文字列です。
        /// </summary>
        public string TileEffectDisplayText { get; }

        /// <summary>
        /// 遺物枠の表示文字列です。
        /// </summary>
        public string RelicDisplayText { get; }

        /// <summary>
        /// BoardCellから表示用スナップショットを生成します。
        /// </summary>
        public static BoardDebugSnapshot FromCell(BoardCell boardCell)
        {
            if (boardCell == null)
            {
                throw new ArgumentNullException(nameof(boardCell));
            }

            return new BoardDebugSnapshot(
                boardCell.Position,
                boardCell.Position.GetRowName(),
                boardCell.Position.GetLaneName(),
                boardCell.HasUnit ? boardCell.OccupyingUnitId : EmptyUnitDisplayText,
                boardCell.HasTerrainEffect ? boardCell.TerrainEffectInstanceId : NoneLayerDisplayText,
                boardCell.HasTileEffect ? boardCell.TileEffectInstanceId : NoneLayerDisplayText,
                boardCell.HasRelic ? boardCell.RelicInstanceId : NoneLayerDisplayText);
        }

        /// <summary>
        /// BoardStateの全マスから表示用スナップショットを生成します。
        /// </summary>
        public static IReadOnlyList<BoardDebugSnapshot> CreateAll(BoardState boardState)
        {
            if (boardState == null)
            {
                throw new ArgumentNullException(nameof(boardState));
            }

            List<BoardDebugSnapshot> snapshots = new List<BoardDebugSnapshot>(boardState.CellCount);
            foreach (BoardCell boardCell in boardState.GetAllCells())
            {
                snapshots.Add(FromCell(boardCell));
            }

            return snapshots.AsReadOnly();
        }

        /// <summary>
        /// 複数行のセル表示文字列を返します。
        /// </summary>
        public string ToMultilineText()
        {
            return $"Row: {RowName}\n"
                + $"Lane: {LaneName}\n"
                + $"Unit: {UnitDisplayText}\n"
                + $"Terrain: {TerrainDisplayText}\n"
                + $"Tile: {TileEffectDisplayText}\n"
                + $"Relic: {RelicDisplayText}";
        }
    }
}
