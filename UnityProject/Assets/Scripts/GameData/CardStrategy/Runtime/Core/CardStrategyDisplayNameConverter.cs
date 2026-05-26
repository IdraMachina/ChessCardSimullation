using System;

namespace GameData.CardStrategy.Core
{
    /// <summary>
    /// 実装用enumを画面表示向けの日本語名へ変換します。
    /// </summary>
    public static class CardStrategyDisplayNameConverter
    {
        /// <summary>
        /// 盤面列の日本語表示名を返します。
        /// </summary>
        public static string ToDisplayName(BoardRowType boardRowType)
        {
            return boardRowType switch
            {
                BoardRowType.EnemyHome => "敵軍本陣列",
                BoardRowType.EnemyBack => "敵軍後衛列",
                BoardRowType.EnemyFront => "敵軍前衛列",
                BoardRowType.PlayerFront => "自軍前衛列",
                BoardRowType.PlayerBack => "自軍後衛列",
                BoardRowType.PlayerHome => "自軍本陣列",
                _ => throw new ArgumentOutOfRangeException(nameof(boardRowType), boardRowType, null)
            };
        }

        /// <summary>
        /// 盤面レーンの日本語表示名を返します。
        /// </summary>
        public static string ToDisplayName(BoardLaneType boardLaneType)
        {
            return boardLaneType switch
            {
                BoardLaneType.Lane1 => "レーン1",
                BoardLaneType.Lane2 => "レーン2",
                BoardLaneType.Lane3 => "レーン3",
                BoardLaneType.Lane4 => "レーン4",
                BoardLaneType.Lane5 => "レーン5",
                _ => throw new ArgumentOutOfRangeException(nameof(boardLaneType), boardLaneType, null)
            };
        }

        /// <summary>
        /// 陣営の日本語表示名を返します。
        /// </summary>
        public static string ToDisplayName(FactionType factionType)
        {
            return factionType switch
            {
                FactionType.Player => "自軍",
                FactionType.Enemy => "敵軍",
                _ => throw new ArgumentOutOfRangeException(nameof(factionType), factionType, null)
            };
        }

        /// <summary>
        /// カード種別の日本語表示名を返します。
        /// </summary>
        public static string ToDisplayName(CardType cardType)
        {
            return cardType switch
            {
                CardType.Unit => "ユニットカード",
                CardType.Strategy => "計略カード",
                CardType.Tactic => "戦術カード",
                CardType.Relic => "遺物カード",
                _ => throw new ArgumentOutOfRangeException(nameof(cardType), cardType, null)
            };
        }

        /// <summary>
        /// カード領域の日本語表示名を返します。
        /// </summary>
        public static string ToDisplayName(CardZoneType cardZoneType)
        {
            return cardZoneType switch
            {
                CardZoneType.Deck => "山札",
                CardZoneType.Hand => "手札",
                CardZoneType.Cemetery => "セメタリー",
                CardZoneType.Sealed => "封印領域",
                CardZoneType.Vanished => "消滅領域",
                CardZoneType.Board => "盤面",
                CardZoneType.Generated => "生成領域",
                _ => throw new ArgumentOutOfRangeException(nameof(cardZoneType), cardZoneType, null)
            };
        }

        /// <summary>
        /// 使用後移動先の日本語表示名を返します。
        /// </summary>
        public static string ToDisplayName(CardAfterUseDestinationType destinationType)
        {
            return destinationType switch
            {
                CardAfterUseDestinationType.Consume => "消費",
                CardAfterUseDestinationType.Seal => "封印",
                CardAfterUseDestinationType.Vanish => "消滅",
                CardAfterUseDestinationType.StayOnBoard => "盤面に残る",
                _ => throw new ArgumentOutOfRangeException(nameof(destinationType), destinationType, null)
            };
        }

        /// <summary>
        /// 移動方向の日本語表示名を返します。
        /// </summary>
        public static string ToDisplayName(MoveDirectionType moveDirectionType)
        {
            return moveDirectionType switch
            {
                MoveDirectionType.Forward => "前方向",
                MoveDirectionType.ForwardRight => "斜め前右",
                MoveDirectionType.ForwardLeft => "斜め前左",
                MoveDirectionType.Right => "右",
                MoveDirectionType.Left => "左",
                MoveDirectionType.BackRight => "斜め後ろ右",
                MoveDirectionType.Backward => "後ろ",
                MoveDirectionType.BackLeft => "斜め後ろ左",
                _ => throw new ArgumentOutOfRangeException(nameof(moveDirectionType), moveDirectionType, null)
            };
        }

        /// <summary>
        /// ターンフェイズの日本語表示名を返します。
        /// </summary>
        public static string ToDisplayName(TurnPhaseType turnPhaseType)
        {
            return turnPhaseType switch
            {
                TurnPhaseType.NotStarted => "未開始",
                TurnPhaseType.TurnStart => "ターン開始",
                TurnPhaseType.Draw => "ドロー",
                TurnPhaseType.Action => "カードプレイ・ユニット操作",
                TurnPhaseType.TurnEnd => "ターン終了",
                TurnPhaseType.BattleEnded => "バトル終了",
                _ => throw new ArgumentOutOfRangeException(nameof(turnPhaseType), turnPhaseType, null)
            };
        }

        /// <summary>
        /// 勝敗状態の日本語表示名を返します。
        /// </summary>
        public static string ToDisplayName(BattleResultType battleResultType)
        {
            return battleResultType switch
            {
                BattleResultType.None => "勝敗なし",
                BattleResultType.PlayerWin => "プレイヤー勝利",
                BattleResultType.PlayerLose => "プレイヤー敗北",
                _ => throw new ArgumentOutOfRangeException(nameof(battleResultType), battleResultType, null)
            };
        }

        /// <summary>
        /// ユニット行動種別の日本語表示名を返します。
        /// </summary>
        public static string ToDisplayName(UnitActionType unitActionType)
        {
            return unitActionType switch
            {
                UnitActionType.Move => "移動",
                UnitActionType.Combat => "交戦",
                UnitActionType.Siege => "攻城",
                _ => throw new ArgumentOutOfRangeException(nameof(unitActionType), unitActionType, null)
            };
        }

        /// <summary>
        /// ダメージ対象種別の日本語表示名を返します。
        /// </summary>
        public static string ToDisplayName(DamageTargetType damageTargetType)
        {
            return damageTargetType switch
            {
                DamageTargetType.TargetUnit => "ユニット",
                DamageTargetType.TargetHome => "本陣",
                _ => throw new ArgumentOutOfRangeException(nameof(damageTargetType), damageTargetType, null)
            };
        }

        /// <summary>
        /// ダメージ結果種別の日本語表示名を返します。
        /// </summary>
        public static string ToDisplayName(DamageResultType damageResultType)
        {
            return damageResultType switch
            {
                DamageResultType.AttackFailed => "攻撃失敗",
                DamageResultType.BarrierFullyBlocked => "Barrier完全軽減",
                DamageResultType.HpDamageDealt => "HPダメージ発生",
                _ => throw new ArgumentOutOfRangeException(nameof(damageResultType), damageResultType, null)
            };
        }

        /// <summary>
        /// マス内レイヤー種別の日本語表示名を返します。
        /// </summary>
        public static string ToDisplayName(BoardCellLayerType boardCellLayerType)
        {
            return boardCellLayerType switch
            {
                BoardCellLayerType.Unit => "ユニット",
                BoardCellLayerType.TerrainEffect => "地形変化",
                BoardCellLayerType.TileEffect => "マス効果",
                BoardCellLayerType.Relic => "遺物",
                _ => throw new ArgumentOutOfRangeException(nameof(boardCellLayerType), boardCellLayerType, null)
            };
        }
    }
}
