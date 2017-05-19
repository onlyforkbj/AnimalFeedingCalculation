using System.Collections.Generic;
using Newtonsoft.Json;

namespace AnimalFeedingCalculator.Data.Models
{
    [JsonObject]
    public class ZooRoot
    {
        public Zoo Zoo { get; set; }
    }

    [JsonObject]
    public class Zoo
    {
        public Lions Lions { get; set; }

        public Giraffes Giraffes { get; set; }

        public Tigers Tigers { get; set; }

        public Zebras Zebras { get; set; }

        public Wolves Wolves { get; set; }

        public Piranhas Piranhas { get; set; }

        public IEnumerable<ZooAnimal> AllZooAnimals()
        {
            var zooAnimals = new List<ZooAnimal>();
            zooAnimals.AddRange(Lions.Lion);
            zooAnimals.AddRange(Giraffes.Giraffe);
            zooAnimals.AddRange(Tigers.Tiger);
            zooAnimals.AddRange(Zebras.Zebra);
            zooAnimals.AddRange(Wolves.Wolf);
            zooAnimals.Add(Piranhas.Piranha);

            return zooAnimals;
        }
    }

    public class Wolf : ZooAnimal
    {
        public Wolf()
        {
            Animal = nameof(Wolf);
            AnimalType = Enums.AnimalType.Omnivores;
        }
    }

    [JsonObject]
    public class Wolves
    {
        public IList<Wolf> Wolf { get; set; }
    }

    public class Piranha : ZooAnimal
    {
        public Piranha()
        {
            Animal = nameof(Piranha);
            AnimalType = Enums.AnimalType.Omnivores;
        }
    }

    [JsonObject]
    public class Piranhas
    {
        public Piranha Piranha { get; set; }
    }

    public class Zebra : ZooAnimal
    {
        public Zebra()
        {
            Animal = nameof(Zebra);
            AnimalType = Enums.AnimalType.Herbivores;
        }
    }

    [JsonObject]
    public class Zebras
    {
        public IList<Zebra> Zebra { get; set; }
    }

    public class Tiger : ZooAnimal
    {
        public Tiger()
        {
            Animal = nameof(Tiger);
            AnimalType = Enums.AnimalType.Carnivores;
        }
    }

    [JsonObject]
    public class Tigers
    {
        public IList<Tiger> Tiger { get; set; }
    }

    public class Giraffe : ZooAnimal
    {
        public Giraffe()
        {
            Animal = nameof(Giraffe);
            AnimalType = Enums.AnimalType.Herbivores;
        }
    }

    [JsonObject]
    public class Giraffes
    {
        public IList<Giraffe> Giraffe { get; set; }
    }

    public class Lion : ZooAnimal
    {
        public Lion()
        {
            Animal = nameof(Lion);
            AnimalType = Enums.AnimalType.Carnivores;
        }
    }

    [JsonObject]
    public class Lions
    {
        public IList<Lion> Lion { get; set; }
    }
}