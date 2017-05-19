using AnimalFeedingCalculator.Data.Enums;

namespace AnimalFeedingCalculator.Business.Dtos
{
    public class FoodPriceCalculationParameters
    {
        public FoodHabit Habit { get; set; }
        public decimal Rate { get; set; }
        public decimal Price { get; set; }
        public string MeatPercentage { get; set; }
    }
}