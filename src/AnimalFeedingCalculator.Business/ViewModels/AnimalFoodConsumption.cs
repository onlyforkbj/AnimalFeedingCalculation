using System.ComponentModel;
using AnimalFeedingCalculator.Data.Enums;

namespace AnimalFeedingCalculator.Business.ViewModels
{
    public class AnimalFoodConsumption
    {
        [DisplayName("Animal")]
        public string AnimalTypeName { get; set; }

        public string Name { get; set; }

        [DisplayName("Weight in Kgs")]
        public decimal WeightInKgs { get; set; }

        [DisplayName("Food Habit")]
        public FoodHabit FoodType { get; set; }

        [DisplayName("Animal Type")]
        public AnimalType AnimalType { get; set; }

        [DisplayName("Food Rate")]
        public decimal FoodRatio { get; set; }

        [DisplayName("Cost Per Kg")]
        public decimal FoodCostPerKg { get; set; }

        [DisplayName("Meat Consumption %")]
        public string MeatConsumptionPercentage { get; set; }

        [DisplayName("Per Day Food Price")]
        public decimal PricePerDayFoodConsumption { get; set; }
    }
}