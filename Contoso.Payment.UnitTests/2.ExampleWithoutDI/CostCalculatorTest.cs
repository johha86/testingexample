using Contoso.Payment.API.Logic;
using Xunit;

namespace Contoso.Payment.UnitTests
{
    public class CostCalculatorTest
    {
        private readonly CostCalculator _calculator;

        public CostCalculatorTest()
        {
            _calculator = new CostCalculator();
        }

        [Fact]
        public void Should_Return_Africa_Tax()
        {
            //  Arrange
            const Region region = Region.Africa;

            //  Act
            float result = _calculator.GetTaxFromRegion(region);

            //  Assert
            Assert.Equal(CostCalculator.TAX_AFRICA, result);
        }

        // 1. Que pasa si alguien modifica el codigo existente en GetTaxFromRegion?
        // 2. Que pasa si se agrega una nueva region y no fue definida?
    }
}
