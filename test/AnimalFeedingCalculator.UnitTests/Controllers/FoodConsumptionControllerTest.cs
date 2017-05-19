using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalFeedingCalculator.Business;
using AnimalFeedingCalculator.Business.Dtos;
using AnimalFeedingCalculator.Data.Models;
using AnimalFeedingCalculator.UI.Controllers;
using AnimalFeedingCalculator.UI.Extensions;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace AnimalFeedingCalculator.UnitTests.Controllers
{
    public class FoodConsumptionControllerTest : BaseTest<FoodConsumptionController>
    {
        private readonly Mock<IFoodConsumptionCalculationManager> calculationManagerMock =
            new Mock<IFoodConsumptionCalculationManager>();

        private readonly Mock<ISession> sessionMock = new Mock<ISession>();

        private readonly Mock<IHttpContextAccessor> httpContextMock = new Mock<IHttpContextAccessor>();

        public FoodConsumptionControllerTest()
        {
            Sut = new FoodConsumptionController(calculationManagerMock.Object, httpContextMock.Object);
        }

        [Fact]
        public async Task Calculate_WhenUploadedDataInSessionIsNull_ReturnsNull()
        {
            httpContextMock
                .Setup(m => m.HttpContext.Session.Get<IEnumerable<ZooAnimal>>("AllZooAnimalsUploaded"))
                .Returns((IEnumerable<ZooAnimal>)null);

            httpContextMock
                .Setup(m => m.HttpContext.Session.Get<IDictionary<string, string>>("PriceDictionary"))
                .Returns((IDictionary<string, string>)null);

            httpContextMock
                .Setup(m => m.HttpContext.Session.Get<IEnumerable<AnimalFeedingRate>>("AnimalFeedingRates"))
                .Returns((IEnumerable<AnimalFeedingRate>)null);

            var result = await Sut.Calculate();
            Assert.Null(result);
        }

        [Fact]
        public async Task Calculate_WithData_InvokesCalculation()
        {
            httpContextMock
                .Setup(m => m.HttpContext.Session.Get<IEnumerable<ZooAnimal>>("AllZooAnimalsUploaded"))
                .Returns(new List<ZooAnimal>());

            httpContextMock
                .Setup(m => m.HttpContext.Session.Get<IDictionary<string, string>>("PriceDictionary"))
                .Returns(new Dictionary<string, string>());

            httpContextMock
                .Setup(m => m.HttpContext.Session.Get<IEnumerable<AnimalFeedingRate>>("AnimalFeedingRates"))
                .Returns(new List<AnimalFeedingRate>());

            var result = await Sut.Calculate();
            Assert.NotNull(result);
            calculationManagerMock.Verify(m => m.CalculateFoodConsumption(It.IsAny<ZooFoodConsumptionInputParameters>()));
        }
    }
}