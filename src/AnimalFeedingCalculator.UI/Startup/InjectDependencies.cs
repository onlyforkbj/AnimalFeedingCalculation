using AnimalFeedingCalculator.Business;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalFeedingCalculator.UI.Startup
{
    public class InjectDependencies
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddSingleton<IFoodConsumptionCalculationManager, FoodConsumptionCalculationManager>();
            services.AddSingleton<IFoodPriceCalculator, FoodPriceCalculator>();
            services.AddSingleton<Omnivores>();
            services.AddSingleton<NonOmnivores>();
        }
    }
}