using AnimalFeedingCalculator.Data.Enums;
using Newtonsoft.Json;

namespace AnimalFeedingCalculator.Data.Models
{
    public class ZooAnimal
    {
        public string Animal { get; set; }

        [JsonProperty("@name")]
        public string Name { get; set; }

        [JsonProperty("@kg")]
        public decimal Kg { get; set; }

        public AnimalType AnimalType { get; set; }
    }
}