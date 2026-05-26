using System;
using System.Linq;
using GameData.CardStrategy.Core;
using NUnit.Framework;

namespace GameData.CardStrategy.Tests.EditMode
{
    public sealed class CommonDefinitionsTests
    {
        [Test]
        public void BoardConstants_MatchInitialSpecification()
        {
            Assert.AreEqual(6, GameRuleConstants.BoardRowCount);
            Assert.AreEqual(5, GameRuleConstants.BoardLaneCount);
            Assert.AreEqual(30, GameRuleConstants.BoardCellCount);
            Assert.AreEqual(
                GameRuleConstants.BoardRowCount * GameRuleConstants.BoardLaneCount,
                GameRuleConstants.BoardCellCount);
            Assert.AreEqual(20, GameRuleConstants.DefaultHomeHp);
            Assert.AreEqual(10, GameRuleConstants.DefaultMaxManaLimit);
            Assert.AreEqual(8, GameRuleConstants.DefaultHandLimit);
            Assert.AreEqual(0, GameRuleConstants.DefaultBaseDamageReductionValue);
        }

        [Test]
        public void DisplayNameConverters_ReturnTextForEveryEnumValue()
        {
            AssertDisplayNames<BoardRowType>(enumValue => CardStrategyDisplayNameConverter.ToDisplayName(enumValue));
            AssertDisplayNames<BoardLaneType>(enumValue => CardStrategyDisplayNameConverter.ToDisplayName(enumValue));
            AssertDisplayNames<FactionType>(enumValue => CardStrategyDisplayNameConverter.ToDisplayName(enumValue));
            AssertDisplayNames<CardType>(enumValue => CardStrategyDisplayNameConverter.ToDisplayName(enumValue));
            AssertDisplayNames<CardZoneType>(enumValue => CardStrategyDisplayNameConverter.ToDisplayName(enumValue));
            AssertDisplayNames<CardAfterUseDestinationType>(enumValue => CardStrategyDisplayNameConverter.ToDisplayName(enumValue));
            AssertDisplayNames<MoveDirectionType>(enumValue => CardStrategyDisplayNameConverter.ToDisplayName(enumValue));
            AssertDisplayNames<TurnPhaseType>(enumValue => CardStrategyDisplayNameConverter.ToDisplayName(enumValue));
            AssertDisplayNames<BattleResultType>(enumValue => CardStrategyDisplayNameConverter.ToDisplayName(enumValue));
            AssertDisplayNames<UnitActionType>(enumValue => CardStrategyDisplayNameConverter.ToDisplayName(enumValue));
            AssertDisplayNames<DamageTargetType>(enumValue => CardStrategyDisplayNameConverter.ToDisplayName(enumValue));
            AssertDisplayNames<DamageResultType>(enumValue => CardStrategyDisplayNameConverter.ToDisplayName(enumValue));
            AssertDisplayNames<BoardCellLayerType>(enumValue => CardStrategyDisplayNameConverter.ToDisplayName(enumValue));
        }

        [Test]
        public void BoardLaneType_OrderMatchesPlayerLeftToRight()
        {
            BoardLaneType[] expectedOrder =
            {
                BoardLaneType.Lane1,
                BoardLaneType.Lane2,
                BoardLaneType.Lane3,
                BoardLaneType.Lane4,
                BoardLaneType.Lane5
            };

            CollectionAssert.AreEqual(expectedOrder, GetEnumValues<BoardLaneType>());
        }

        [Test]
        public void BoardRowType_OrderMatchesEnemyHomeToPlayerHome()
        {
            BoardRowType[] expectedOrder =
            {
                BoardRowType.EnemyHome,
                BoardRowType.EnemyBack,
                BoardRowType.EnemyFront,
                BoardRowType.PlayerFront,
                BoardRowType.PlayerBack,
                BoardRowType.PlayerHome
            };

            CollectionAssert.AreEqual(expectedOrder, GetEnumValues<BoardRowType>());
        }

        [Test]
        public void CardType_ContainsInitialCardTypes()
        {
            CardType[] expectedCardTypes =
            {
                CardType.Unit,
                CardType.Strategy,
                CardType.Tactic,
                CardType.Relic
            };

            CollectionAssert.AreEquivalent(expectedCardTypes, GetEnumValues<CardType>());
        }

        [Test]
        public void CardType_DoesNotContainDeprecatedClassifications()
        {
            string[] cardTypeNames = Enum.GetNames(typeof(CardType));

            Assert.IsFalse(cardTypeNames.Contains("Magic"));
            Assert.IsFalse(cardTypeNames.Contains("Item"));
            Assert.IsFalse(cardTypeNames.Contains("Defense"));
        }

        private static void AssertDisplayNames<TEnum>(Func<TEnum, string> getDisplayName)
            where TEnum : struct
        {
            foreach (TEnum enumValue in GetEnumValues<TEnum>())
            {
                string displayName = getDisplayName(enumValue);

                Assert.IsFalse(string.IsNullOrEmpty(displayName), $"{typeof(TEnum).Name}.{enumValue} の表示名が未定義です。");
            }
        }

        private static TEnum[] GetEnumValues<TEnum>()
            where TEnum : struct
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
        }
    }
}
