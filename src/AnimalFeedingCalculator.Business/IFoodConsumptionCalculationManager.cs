using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalFeedingCalculator.Business.Dtos;
using AnimalFeedingCalculator.Business.ViewModels;

namespace AnimalFeedingCalculator.Business
{
    public interface IFoodConsumptionCalculationManager
    {
        Task<IList<AnimalFoodConsumption>> CalculateFoodConsumption(ZooFoodConsumptionInputParameters inputCalculationParameters);
    }
}