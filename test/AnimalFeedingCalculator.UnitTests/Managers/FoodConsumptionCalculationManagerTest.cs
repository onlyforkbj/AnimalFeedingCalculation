using System.Threading.Tasks;
using AnimalFeedingCalculator.Business;
using AnimalFeedingCalculator.UnitTests.Builders;
using Moq;
using Xunit;

namespace AnimalFeedingCalculator.UnitTests.Managers
{
    public class FoodConsumptionCalculationManagerTest : BaseTest<FoodConsumptionCalculationManager>
    {
        private readonly Mock<IFoodPriceCalculator> priceCalculatorMock = new Mock<IFoodPriceCalculator>();

        public FoodConsumptionCalculationManagerTest()
        {
            Sut = new FoodConsumptionCalculationManager(priceCalculatorMock.Object);
        }

        [Fact]
        public async Task CalculatePrice_WhenCalled_InvokesRightMethod()
        {
            var parameters = ZooFoodConsumptionInputParametersBuilder
                .Create()
                .Build();

            await Sut.CalculateFoodConsumption(parameters);

            priceCalculatorMock.Verify(m => m.CalculatePriceAsync(parameters), Times.AtLeastOnce);
        }
    }
}