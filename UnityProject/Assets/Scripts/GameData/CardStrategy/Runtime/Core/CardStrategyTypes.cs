namespace GameData.CardStrategy.Core
{
    // 旧仕様・禁止語彙の注意:
    // - Defenseはカード基礎ステータスとして使わない。
    // - DamageReductionValue / 被ダメージ軽減値は内部処理値として扱う。
    // - 魔導カードは使わず、即時効果カードはTactic / 戦術カードとして扱う。
    // - 道具カードは使わず、継続設置系はRelic / 遺物カードとして扱う。
    // - BoardRowType / BoardLaneType の内部座標値は後続タスク03の BoardPosition で確定する。

    /// <summary>
    /// バトル上の陣営を表します。
    /// </summary>
    public enum FactionType
    {
        Player,
        Enemy
    }

    /// <summary>
    /// 盤面の表示上の列を、敵軍本陣列から自軍本陣列の順で表します。
    /// </summary>
    public enum BoardRowType
    {
        EnemyHome,
        EnemyBack,
        EnemyFront,
        PlayerFront,
        PlayerBack,
        PlayerHome
    }

    /// <summary>
    /// プレイヤー視点で左から右へ並ぶ盤面レーンを表します。
    /// </summary>
    public enum BoardLaneType
    {
        Lane1,
        Lane2,
        Lane3,
        Lane4,
        Lane5
    }

    /// <summary>
    /// 初期仕様で採用するカード種別を表します。
    /// </summary>
    public enum CardType
    {
        Unit,
        Strategy,
        Tactic,
        Relic
    }

    /// <summary>
    /// カードが存在し得る領域を表します。
    /// </summary>
    public enum CardZoneType
    {
        Deck,
        Hand,
        Cemetery,
        Sealed,
        Vanished,
        Board,
        Generated
    }

    /// <summary>
    /// カード使用後、破壊後、または効果解決後の移動先を表します。
    /// </summary>
    public enum CardAfterUseDestinationType
    {
        Consume,
        Seal,
        Vanish,
        StayOnBoard
    }

    /// <summary>
    /// ユニットの移動方向を表します。
    /// </summary>
    public enum MoveDirectionType
    {
        Forward,
        ForwardRight,
        ForwardLeft,
        Right,
        Left,
        BackRight,
        Backward,
        BackLeft
    }

    /// <summary>
    /// ターン進行上のフェイズを表します。
    /// </summary>
    public enum TurnPhaseType
    {
        NotStarted,
        TurnStart,
        Draw,
        Action,
        TurnEnd,
        BattleEnded
    }

    /// <summary>
    /// バトルの勝敗状態を表します。
    /// </summary>
    public enum BattleResultType
    {
        None,
        PlayerWin,
        PlayerLose
    }

    /// <summary>
    /// ユニットが実行する基本行動種別を表します。
    /// </summary>
    public enum UnitActionType
    {
        Move,
        Combat,
        Siege
    }

    /// <summary>
    /// ダメージ効果の対象種別を表します。
    /// </summary>
    public enum DamageTargetType
    {
        TargetUnit,
        TargetHome
    }

    /// <summary>
    /// ダメージ解決結果の分類を表します。
    /// </summary>
    public enum DamageResultType
    {
        AttackFailed,
        BarrierFullyBlocked,
        HpDamageDealt
    }

    /// <summary>
    /// 1マス内に存在し得るレイヤー種別を表します。
    /// </summary>
    public enum BoardCellLayerType
    {
        Unit,
        TerrainEffect,
        TileEffect,
        Relic
    }
}
