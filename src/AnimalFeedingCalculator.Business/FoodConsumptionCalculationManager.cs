using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalFeedingCalculator.Business.Dtos;
using AnimalFeedingCalculator.Business.ViewModels;

namespace AnimalFeedingCalculator.Business
{
    public class FoodConsumptionCalculationManager : IFoodConsumptionCalculationManager
    {
        private readonly IFoodPriceCalculator foodPriceCalculator;

        public FoodConsumptionCalculationManager(IFoodPriceCalculator foodPriceCalculator)
        {
            this.foodPriceCalculator = foodPriceCalculator;
        }

        public async Task<IList<AnimalFoodConsumption>> CalculateFoodConsumption(ZooFoodConsumptionInputParameters
                                                                                 inputCalculationParameters)
        {
            return await foodPriceCalculator.CalculatePriceAsync(inputCalculationParameters);
        }
    }
}