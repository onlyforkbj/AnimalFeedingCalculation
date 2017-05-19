using System;
using System.Collections.Generic;
using System.Text;
using AnimalFeedingCalculator.Data.Enums;

namespace AnimalFeedingCalculator.Data.Models
{
    public class AnimalFeedingRate
    {
        public string Animal { get; set; }

        public string Rate { get; set; }

        public FoodHabit Food { get; set; }

        public string MeatPercentage { get; set; }
    }
}