using System.Collections.Concurrent;
using System.Collections.Generic;
using AnimalFeedingCalculator.Business;
using AnimalFeedingCalculator.Data.Enums;
using AnimalFeedingCalculator.UnitTests.Builders;
using Xunit;

namespace AnimalFeedingCalculator.UnitTests.Managers
{
    public class OmnivoresTest : BaseTest<Omnivores>
    {
        public OmnivoresTest()
        {
            Sut = new Omnivores();
        }

        [Fact]
        public void CalculatePrice_WithNonOmnivoreData_ReturnsZeroPrice()
        {
            var carnivore = AnimalBuilder
                .Create()
                .WithAnimalType(AnimalType.Carnivores)
                .WithKg(100)
                .Build();

            var parameters = FoodPriceCalculationParametersBuilder
                .Create()
                .Build();

            var result = Sut.CalculatePrice(carnivore, parameters, new ConcurrentDictionary<string, string>());

            Assert.Equal(decimal.Zero, result);
        }

        [Fact]
        public void CalculatePrice_WithOmnivoreData_ReturnsCalculatedPrice()
        {
            var omnivore = AnimalBuilder
                .Create()
                .WithAnimalType(AnimalType.Omnivores)
                .WithKg(78)
                .Build();

            var parameters = FoodPriceCalculationParametersBuilder
                .Create()
                .WithMeatPercentage("90%")
                .WithRate(0.07M)
                .Build();

            var priceDictionary = new Dictionary<string, string>
            {
                {"Meat", "12.56"},
                {"Fruit", "5.6" }
            };

            var result = Sut.CalculatePrice(omnivore, parameters, priceDictionary);

            Assert.Equal(64.77744M, result);
        }
    }
}