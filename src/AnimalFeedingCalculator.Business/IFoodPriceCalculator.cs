using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalFeedingCalculator.Business.Dtos;
using AnimalFeedingCalculator.Business.ViewModels;

namespace AnimalFeedingCalculator.Business
{
    public interface IFoodPriceCalculator
    {
        Task<IList<AnimalFoodConsumption>> CalculatePriceAsync(ZooFoodConsumptionInputParameters inputParameters);
    }
}