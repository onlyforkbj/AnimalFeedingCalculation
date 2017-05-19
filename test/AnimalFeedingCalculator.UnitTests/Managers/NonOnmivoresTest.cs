using AnimalFeedingCalculator.Business;
using AnimalFeedingCalculator.Data.Enums;
using AnimalFeedingCalculator.UnitTests.Builders;
using Xunit;

namespace AnimalFeedingCalculator.UnitTests.Managers
{
    public class NonOnmivoresTest : BaseTest<NonOmnivores>
    {
        public NonOnmivoresTest()
        {
            Sut = new NonOmnivores();
        }

        [Theory]
        [InlineData(AnimalType.Carnivores)]
        [InlineData(AnimalType.Herbivores)]
        public void CalculatePrice_WithCarnivoreData_ReturnsPriceCalculated(AnimalType animalType)
        {
            var carnivore = AnimalBuilder
                .Create()
                .WithAnimalType(animalType)
                .WithKg(100)
                .Build();

            var parameters = FoodPriceCalculationParametersBuilder
                .Create()
                .WithRate(0.1M)
                .Build();

            var result = Sut.CalculatePrice(carnivore, parameters);

            Assert.Equal(125.6M, result);
        }

        [Fact]
        public void CalculatePrice_WithOmnivoreData_ReturnsZeroPrice()
        {
            var carnivore = AnimalBuilder
                .Create()
                .WithKg(100)
                .WithAnimalType(AnimalType.Omnivores)
                .Build();

            var parameters = FoodPriceCalculationParametersBuilder
                .Create()
                .WithRate(0.1M)
                .Build();

            var result = Sut.CalculatePrice(carnivore, parameters);

            Assert.Equal(decimal.Zero, result);
        }
    }
}