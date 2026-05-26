using System;

namespace GameData.CardStrategy
{
    /// <summary>
    /// 盤面上の1マスの状態を保持します。
    /// </summary>
    public sealed class BoardCell
    {
        /// <summary>
        /// 指定座標に対応する盤面マスを生成します。
        /// </summary>
        public BoardCell(BoardPosition position)
        {
            Position = position;
        }

        /// <summary>
        /// このマスの盤面座標です。
        /// </summary>
        public BoardPosition Position { get; }

        /// <summary>
        /// このマスに存在するユニットインスタンスIDです。未配置の場合はnullです。
        /// </summary>
        public string OccupyingUnitId { get; private set; }

        /// <summary>
        /// このマスに設定されている地形変化インスタンスIDです。未設定の場合はnullです。
        /// </summary>
        public string TerrainEffectInstanceId { get; private set; }

        /// <summary>
        /// このマスに設定されているマス効果インスタンスIDです。未設定の場合はnullです。
        /// </summary>
        public string TileEffectInstanceId { get; private set; }

        /// <summary>
        /// このマスに設置されている遺物インスタンスIDです。未設定の場合はnullです。
        /// </summary>
        public string RelicInstanceId { get; private set; }

        /// <summary>
        /// ユニットが存在するかどうかを返します。
        /// </summary>
        public bool HasUnit => !string.IsNullOrEmpty(OccupyingUnitId);

        /// <summary>
        /// 地形変化が設定されているかどうかを返します。
        /// </summary>
        public bool HasTerrainEffect => !string.IsNullOrEmpty(TerrainEffectInstanceId);

        /// <summary>
        /// マス効果が設定されているかどうかを返します。
        /// </summary>
        public bool HasTileEffect => !string.IsNullOrEmpty(TileEffectInstanceId);

        /// <summary>
        /// 遺物が設置されているかどうかを返します。
        /// </summary>
        public bool HasRelic => !string.IsNullOrEmpty(RelicInstanceId);

        /// <summary>
        /// ユニットインスタンスIDを設定します。
        /// </summary>
        public void SetOccupyingUnitId(string unitInstanceId)
        {
            OccupyingUnitId = ValidateInstanceId(unitInstanceId, nameof(unitInstanceId));
        }

        /// <summary>
        /// ユニットインスタンスIDを未設定状態に戻します。
        /// </summary>
        public void ClearOccupyingUnitId()
        {
            OccupyingUnitId = null;
        }

        /// <summary>
        /// 地形変化インスタンスIDを設定します。
        /// </summary>
        public void SetTerrainEffectInstanceId(string terrainEffectInstanceId)
        {
            TerrainEffectInstanceId = ValidateInstanceId(terrainEffectInstanceId, nameof(terrainEffectInstanceId));
        }

        /// <summary>
        /// 地形変化インスタンスIDを未設定状態に戻します。
        /// </summary>
        public void ClearTerrainEffectInstanceId()
        {
            TerrainEffectInstanceId = null;
        }

        /// <summary>
        /// マス効果インスタンスIDを設定します。
        /// </summary>
        public void SetTileEffectInstanceId(string tileEffectInstanceId)
        {
            TileEffectInstanceId = ValidateInstanceId(tileEffectInstanceId, nameof(tileEffectInstanceId));
        }

        /// <summary>
        /// マス効果インスタンスIDを未設定状態に戻します。
        /// </summary>
        public void ClearTileEffectInstanceId()
        {
            TileEffectInstanceId = null;
        }

        /// <summary>
        /// 遺物インスタンスIDを設定します。
        /// </summary>
        public void SetRelicInstanceId(string relicInstanceId)
        {
            RelicInstanceId = ValidateInstanceId(relicInstanceId, nameof(relicInstanceId));
        }

        /// <summary>
        /// 遺物インスタンスIDを未設定状態に戻します。
        /// </summary>
        public void ClearRelicInstanceId()
        {
            RelicInstanceId = null;
        }

        private static string ValidateInstanceId(string instanceId, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(instanceId))
            {
                throw new ArgumentException("インスタンスIDには空ではない文字列を指定してください。", argumentName);
            }

            return instanceId;
        }
    }
}
