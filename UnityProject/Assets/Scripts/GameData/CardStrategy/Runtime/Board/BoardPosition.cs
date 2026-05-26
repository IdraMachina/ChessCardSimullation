using System;
using GameData.CardStrategy.Core;

namespace GameData.CardStrategy
{
    /// <summary>
    /// 盤面上の1座標を表す値オブジェクトです。
    /// </summary>
    public readonly struct BoardPosition : IEquatable<BoardPosition>
    {
        /// <summary>
        /// 盤外や未選択を表す補助座標です。
        /// </summary>
        public static BoardPosition Invalid => new BoardPosition((BoardRowType)(-1), (BoardLaneType)(-1));

        /// <summary>
        /// 表示上の上から下へ並ぶ盤面列です。
        /// </summary>
        public BoardRowType Row { get; }

        /// <summary>
        /// プレイヤー視点で左から右へ並ぶ盤面レーンです。
        /// </summary>
        public BoardLaneType Lane { get; }

        /// <summary>
        /// 盤面座標を生成します。
        /// </summary>
        public BoardPosition(BoardRowType row, BoardLaneType lane)
        {
            Row = row;
            Lane = lane;
        }

        /// <summary>
        /// 0始まりの内部インデックスから盤面座標を生成します。
        /// </summary>
        public static BoardPosition FromIndices(int rowIndex, int laneIndex)
        {
            return new BoardPosition((BoardRowType)rowIndex, (BoardLaneType)laneIndex);
        }

        /// <summary>
        /// 盤面列の0始まり内部インデックスを返します。
        /// </summary>
        public int RowIndex => (int)Row;

        /// <summary>
        /// 盤面レーンの0始まり内部インデックスを返します。
        /// </summary>
        public int LaneIndex => (int)Lane;

        /// <summary>
        /// 表示用の盤面列名を返します。
        /// </summary>
        public string GetRowName()
        {
            return Enum.IsDefined(typeof(BoardRowType), Row) ? Row.ToString() : RowIndex.ToString();
        }

        /// <summary>
        /// 表示用の盤面レーン名を返します。
        /// </summary>
        public string GetLaneName()
        {
            if (Enum.IsDefined(typeof(BoardLaneType), Lane))
            {
                return Lane.ToString();
            }

            return LaneIndex >= 0 ? $"Lane{LaneIndex + 1}" : LaneIndex.ToString();
        }

        /// <summary>
        /// デバッグ表示向けの短い座標文字列を返します。
        /// </summary>
        public string ToDisplayString()
        {
            return $"{GetRowName()} / {GetLaneName()}";
        }

        /// <summary>
        /// 同じ盤面座標かどうかを判定します。
        /// </summary>
        public bool Equals(BoardPosition other)
        {
            return Row == other.Row && Lane == other.Lane;
        }

        /// <summary>
        /// 同じ盤面座標かどうかを判定します。
        /// </summary>
        public override bool Equals(object comparisonObject)
        {
            return comparisonObject is BoardPosition otherPosition && Equals(otherPosition);
        }

        /// <summary>
        /// 盤面座標のハッシュ値を返します。
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return (RowIndex * 397) ^ LaneIndex;
            }
        }

        /// <summary>
        /// ログ表示向けの座標文字列を返します。
        /// </summary>
        public override string ToString()
        {
            return $"Row={GetRowName()}, Lane={GetLaneName()}";
        }

        /// <summary>
        /// 2つの盤面座標が同じかどうかを判定します。
        /// </summary>
        public static bool operator ==(BoardPosition leftPosition, BoardPosition rightPosition)
        {
            return leftPosition.Equals(rightPosition);
        }

        /// <summary>
        /// 2つの盤面座標が異なるかどうかを判定します。
        /// </summary>
        public static bool operator !=(BoardPosition leftPosition, BoardPosition rightPosition)
        {
            return !leftPosition.Equals(rightPosition);
        }
    }
}
