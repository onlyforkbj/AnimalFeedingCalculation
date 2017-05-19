using AnimalFeedingCalculator.Data.Enums;
using AnimalFeedingCalculator.Data.Models;

namespace AnimalFeedingCalculator.UnitTests.Builders
{
    public class AnimalBuilder
    {
        private readonly ZooAnimal zooAnimal = new ZooAnimal
        {
            Animal = "Lion",
            AnimalType = AnimalType.Carnivores,
            Kg = 100,
            Name = "Simba"
        };

        private AnimalBuilder()
        {
        }

        public static AnimalBuilder Create()
        {
            return new AnimalBuilder();
        }

        public AnimalBuilder WithAnimal(string animal)
        {
            zooAnimal.Animal = animal;
            return this;
        }

        public AnimalBuilder WithAnimalType(AnimalType type)
        {
            zooAnimal.AnimalType = type;
            return this;
        }

        public AnimalBuilder WithKg(int kg)
        {
            zooAnimal.Kg = kg;
            return this;
        }

        public AnimalBuilder WithName(string name)
        {
            zooAnimal.Name = name;
            return this;
        }

        public ZooAnimal Build()
        {
            return zooAnimal;
        }
    }
}