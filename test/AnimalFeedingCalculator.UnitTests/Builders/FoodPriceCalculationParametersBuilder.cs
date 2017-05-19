using System.Runtime.InteropServices;
using AnimalFeedingCalculator.Business.Dtos;
using AnimalFeedingCalculator.Data.Enums;

namespace AnimalFeedingCalculator.UnitTests.Builders
{
    public class FoodPriceCalculationParametersBuilder
    {
        private readonly FoodPriceCalculationParameters foodPriceCalculationParameters = new FoodPriceCalculationParameters
        {
            Rate = 0.1M,
            Price = 12.56M,
            Habit = FoodHabit.Meat,
            MeatPercentage = "100%"
        };

        private FoodPriceCalculationParametersBuilder()
        {
        }

        public static FoodPriceCalculationParametersBuilder Create()
        {
            return new FoodPriceCalculationParametersBuilder();
        }

        public FoodPriceCalculationParameters Build()
        {
            return foodPriceCalculationParameters;
        }

        public FoodPriceCalculationParametersBuilder WithMeatPercentage(string percentage)
        {
            foodPriceCalculationParameters.MeatPercentage = percentage;
            return this;
        }

        public FoodPriceCalculationParametersBuilder WithRate(decimal rate)
        {
            foodPriceCalculationParameters.Rate = rate;
            return this;
        }
    }
}