using System;
using CustomEnumeration;
using Xunit;

namespace UnitTest
{
    public class EnumerationTest
    {
        public class CardType : Enumeration
        {
            public static CardType Amex = new AmexCardType();
            public static CardType Visa = new VisaCardType();
            public static CardType MasterCard = new MasterCardType();

            public CardType(int id, string name)
                : base(id, name)
            {
            }

            private class AmexCardType : CardType
            {
                public AmexCardType() : base(1, "Amex")
                { }
            }

            private class VisaCardType : CardType
            {
                public VisaCardType() : base(2, "Visa")
                { }
            }

            private class MasterCardType : CardType
            {
                public MasterCardType() : base(3, "MasterCard")
                { }
            }
        }

        [Fact]
        public void ParseNameTest()
        {
            var predefinedType = CardType.Visa;

            var mapType = Enumeration.FromDisplayName<CardType>(nameof(CardType.Visa));
            Assert.IsType<CardType>(mapType);

            Assert.Equal(predefinedType, mapType);

            var difference = Enumeration.AbsoluteDifference(predefinedType, mapType);
            Assert.Equal(0, difference);
        }

        [Fact]
        public void ParseValueTest()
        {
            var predefinedType = CardType.Visa;

            var mapType = Enumeration.FromValue<CardType>(2);
            Assert.IsType<CardType>(mapType);

            Assert.Equal(predefinedType, mapType);

            var difference = Enumeration.AbsoluteDifference(predefinedType, mapType);
            Assert.Equal(0, difference);
        }
    }
}
