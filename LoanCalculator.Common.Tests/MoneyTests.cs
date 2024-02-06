using LoanCalculator.Common.ValueObjects;

namespace LoanCalculator.Common.Tests
{
    public class MoneyTests
    {
        private static readonly Money _moneyExampleA = new(4_321.09M);
        private static readonly Money _moneyExampleB = new(987_654_321.09M);

        [Fact]
        public void EqualityCheck_Should_Return_True_IfEqual()
        {
            Assert.True(_moneyExampleA.Equals(_moneyExampleA));
        }

        [Fact]
        public void EqualityCheck_Should_Return_False_IfNotEqual()
        {
            Assert.False(_moneyExampleA.Equals(_moneyExampleB));
        }

        [Fact]
        public void ToString_Should_Print_CorrectValue_With_Formatting()
        {
            string expectedA = "$4,321.09";

            Assert.Equal(expectedA, _moneyExampleA.ToString());

            string expectedB = "$987,654,321.09";

            Assert.Equal(expectedB, _moneyExampleB.ToString());

            string expectedC = "$321.09";

            Assert.Equal(expectedC, new Money(321.09M).ToString());

            string expectedD = "$321.00";

            Assert.Equal(expectedD, new Money(321).ToString());
        }

        [Fact]
        public void Operator_Add_Should_AddCorrectly()
        {
            Money expected = new(5_321.09M);
            Assert.Equal(expected, _moneyExampleA + 1_000);
        }

        [Fact]
        public void Operator_Subtract_Should_SubtractCorrectly()
        {
            Money expected = new(3_321.09M);
            Assert.Equal(expected, _moneyExampleA - 1_000);
        }

        [Fact]
        public void Operator_Multiply_Should_MultiplyCorrectly()
        {
            Money expected = new(43_210.90M);
            Assert.Equal(expected, _moneyExampleA * 10);
        }

        [Fact]
        public void Operator_Multiply_Should_MultiplyCorrectly_WithPercentageRate()
        {
            Money expected = new(432.11M);
            PercentageRate percent = new(10);
            Assert.Equal(expected, _moneyExampleA * percent);
        }

        [Fact]
        public void Operator_Divide_Should_DivideCorrectly()
        {
            Money expected = new(432.11M);
            Assert.Equal(expected, _moneyExampleA / 10);
        }

        [Fact]
        public void Operator_Divide_Should_DivideCorrectly_WithPercentageRate()
        {
            Money expected = new(43_210.90M);
            PercentageRate percent = new(10);
            Assert.Equal(expected, _moneyExampleA / percent);
        }

        //TODO: Rename Test Case Better...?
        [Fact]
        public void BankersRounding_ShouldAlwaysApplyCorrectly()
        {
            Assert.Equal(new Money(8.76M), new Money(8.765M)); //Will round down
            Assert.Equal(new Money(7.66M), new Money(7.655M)); //Will round up
        }
    }
}