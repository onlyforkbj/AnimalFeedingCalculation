using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalFeedingCalculator.Business;
using AnimalFeedingCalculator.UnitTests.Builders;
using Moq;
using Xunit;

namespace AnimalFeedingCalculator.UnitTests.Managers
{
    public class FoodPriceCalculatorTest : BaseTest<FoodPriceCalculator>
    {
        private readonly Mock<Omnivores> omnivoresMock = new Mock<Omnivores>();
        private readonly Mock<NonOmnivores> nonOmnivoresMock = new Mock<NonOmnivores>();

        public FoodPriceCalculatorTest()
        {
            Sut = new FoodPriceCalculator(omnivoresMock.Object, nonOmnivoresMock.Object);
        }

        [Fact]
        public async Task CalculatePrice_WithValidData_ReturnsPriceDetails()
        {
            var parameters = ZooFoodConsumptionInputParametersBuilder
                .Create()
                .Build();

            var result = await Sut.CalculatePriceAsync(parameters);

            Assert.NotNull(result);
            Assert.Equal(4, result.Count);
            Assert.NotEqual(1, result.Select(ani => ani.PricePerDayFoodConsumption == decimal.Zero).Count());
        }
    }
}