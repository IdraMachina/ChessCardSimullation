namespace GameData.CardStrategy.Core
{
    /// <summary>
    /// カード戦略バトル全体で共有する基本ルール定数を提供します。
    /// </summary>
    public static class GameRuleConstants
    {
        /// <summary>
        /// 盤面の縦方向の列数です。
        /// </summary>
        public const int BoardRowCount = 6;

        /// <summary>
        /// 盤面の横方向のレーン数です。
        /// </summary>
        public const int BoardLaneCount = 5;

        /// <summary>
        /// 盤面全体のマス数です。
        /// </summary>
        public const int BoardCellCount = 30;

        /// <summary>
        /// 自軍・敵軍に共通する基本本陣HPです。
        /// </summary>
        public const int DefaultHomeHp = 20;

        /// <summary>
        /// 初期仕様で扱う最大マナの上限です。
        /// </summary>
        public const int DefaultMaxManaLimit = 10;

        /// <summary>
        /// 初期仕様で扱う手札上限です。
        /// </summary>
        public const int DefaultHandLimit = 8;

        /// <summary>
        /// 通常時の基本被ダメージ軽減値です。ユニットカードの基礎ステータスとしては扱いません。
        /// </summary>
        public const int DefaultBaseDamageReductionValue = 0;
    }
}
