using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameData.CardStrategy.Core;

namespace GameData.CardStrategy
{
    /// <summary>
    /// 6×5の盤面全体を保持し、盤面参照と基本判定を提供します。
    /// </summary>
    public sealed class BoardState
    {
        private static readonly BoardRowType[] RowTypesInDisplayOrderValues =
        {
            BoardRowType.EnemyHome,
            BoardRowType.EnemyBack,
            BoardRowType.EnemyFront,
            BoardRowType.PlayerFront,
            BoardRowType.PlayerBack,
            BoardRowType.PlayerHome
        };

        private static readonly BoardLaneType[] LaneTypesInDisplayOrderValues =
        {
            BoardLaneType.Lane1,
            BoardLaneType.Lane2,
            BoardLaneType.Lane3,
            BoardLaneType.Lane4,
            BoardLaneType.Lane5
        };

        private static readonly ReadOnlyCollection<BoardRowType> RowTypesInDisplayOrder =
            Array.AsReadOnly(RowTypesInDisplayOrderValues);

        private static readonly ReadOnlyCollection<BoardLaneType> LaneTypesInDisplayOrder =
            Array.AsReadOnly(LaneTypesInDisplayOrderValues);

        private readonly BoardCell[,] cellsByPosition;
        private readonly ReadOnlyCollection<BoardCell> allCells;

        /// <summary>
        /// 仕様上の表示順で並ぶ盤面列を返します。
        /// </summary>
        public static IReadOnlyList<BoardRowType> DisplayRows => RowTypesInDisplayOrder;

        /// <summary>
        /// プレイヤー視点の左から右で並ぶ盤面レーンを返します。
        /// </summary>
        public static IReadOnlyList<BoardLaneType> DisplayLanes => LaneTypesInDisplayOrder;

        /// <summary>
        /// 全盤面マスを初期生成します。
        /// </summary>
        public BoardState()
        {
            cellsByPosition = new BoardCell[GameRuleConstants.BoardRowCount, GameRuleConstants.BoardLaneCount];

            List<BoardCell> generatedCells = new List<BoardCell>(GameRuleConstants.BoardCellCount);
            foreach (BoardRowType boardRowType in RowTypesInDisplayOrderValues)
            {
                foreach (BoardLaneType boardLaneType in LaneTypesInDisplayOrderValues)
                {
                    BoardPosition boardPosition = new BoardPosition(boardRowType, boardLaneType);
                    BoardCell boardCell = new BoardCell(boardPosition);

                    cellsByPosition[boardPosition.RowIndex, boardPosition.LaneIndex] = boardCell;
                    generatedCells.Add(boardCell);
                }
            }

            allCells = generatedCells.AsReadOnly();
        }

        /// <summary>
        /// 盤面列数を返します。
        /// </summary>
        public int RowCount => GameRuleConstants.BoardRowCount;

        /// <summary>
        /// 盤面レーン数を返します。
        /// </summary>
        public int LaneCount => GameRuleConstants.BoardLaneCount;

        /// <summary>
        /// 盤面マス数を返します。
        /// </summary>
        public int CellCount => allCells.Count;

        /// <summary>
        /// 指定座標のマスを返します。盤外座標の場合は例外を投げます。
        /// </summary>
        public BoardCell GetCell(BoardPosition position)
        {
            if (!TryGetCell(position, out BoardCell boardCell))
            {
                throw new ArgumentOutOfRangeException(nameof(position), position, "盤外座標のBoardCellは取得できません。");
            }

            return boardCell;
        }

        /// <summary>
        /// 指定座標が盤内の場合は対応するマスを返します。
        /// </summary>
        public bool TryGetCell(BoardPosition position, out BoardCell boardCell)
        {
            if (!IsInside(position))
            {
                boardCell = null;
                return false;
            }

            boardCell = cellsByPosition[position.RowIndex, position.LaneIndex];
            return true;
        }

        /// <summary>
        /// 指定座標が6×5の盤面内にあるかどうかを返します。
        /// </summary>
        public bool IsInside(BoardPosition position)
        {
            return position.RowIndex >= 0
                && position.RowIndex < GameRuleConstants.BoardRowCount
                && position.LaneIndex >= 0
                && position.LaneIndex < GameRuleConstants.BoardLaneCount;
        }

        /// <summary>
        /// 指定座標が盤内で、ユニット配置枠が空かどうかを返します。
        /// </summary>
        public bool IsEmptyForUnit(BoardPosition position)
        {
            return TryGetCell(position, out BoardCell boardCell) && !boardCell.HasUnit;
        }

        /// <summary>
        /// 指定座標にユニットが存在するかどうかを返します。
        /// </summary>
        public bool HasUnit(BoardPosition position)
        {
            return TryGetCell(position, out BoardCell boardCell) && boardCell.HasUnit;
        }

        /// <summary>
        /// 指定座標のユニットインスタンスIDを返します。存在しない場合はnullです。
        /// </summary>
        public string GetUnitId(BoardPosition position)
        {
            return TryGetCell(position, out BoardCell boardCell) ? boardCell.OccupyingUnitId : null;
        }

        /// <summary>
        /// 表示順で並ぶ全マスを返します。
        /// </summary>
        public IReadOnlyList<BoardCell> GetAllCells()
        {
            return allCells;
        }

        /// <summary>
        /// 指定陣営の自本陣列を返します。
        /// </summary>
        public BoardRowType GetHomeRow(FactionType faction)
        {
            switch (faction)
            {
                case FactionType.Player:
                    return BoardRowType.PlayerHome;
                case FactionType.Enemy:
                    return BoardRowType.EnemyHome;
                default:
                    throw new ArgumentOutOfRangeException(nameof(faction), faction, null);
            }
        }

        /// <summary>
        /// 指定陣営から見た敵本陣列を返します。
        /// </summary>
        public BoardRowType GetEnemyHomeRow(FactionType faction)
        {
            switch (faction)
            {
                case FactionType.Player:
                    return BoardRowType.EnemyHome;
                case FactionType.Enemy:
                    return BoardRowType.PlayerHome;
                default:
                    throw new ArgumentOutOfRangeException(nameof(faction), faction, null);
            }
        }

        /// <summary>
        /// 指定座標が指定陣営の自本陣列かどうかを返します。
        /// </summary>
        public bool IsOwnHomeRow(FactionType faction, BoardPosition position)
        {
            return IsInside(position) && position.Row == GetHomeRow(faction);
        }

        /// <summary>
        /// 指定座標が指定陣営から見た敵本陣列かどうかを返します。
        /// </summary>
        public bool IsEnemyHomeRow(FactionType faction, BoardPosition position)
        {
            return IsInside(position) && position.Row == GetEnemyHomeRow(faction);
        }

        /// <summary>
        /// 指定陣営にとって前方へ1マス進むときのRow差分を返します。
        /// </summary>
        public int GetForwardRowDelta(FactionType faction)
        {
            switch (faction)
            {
                case FactionType.Player:
                    return -1;
                case FactionType.Enemy:
                    return 1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(faction), faction, null);
            }
        }
    }
}
