using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBalladOfAllanMush.Ventures.III___GalaxyZ;
using TheBalladOfAllanMush.Ventures.III___GalaxyZ.Models;

namespace UnitTests.III___GalaxyZ
{
    /// <summary>
    /// Allan Mush has taken notice of your talent writing tests.
    /// He's so impressed, he's promoted you to develop for his space faring venture!
    /// 
    /// Since there's a critical launch tomorrow, everyone is crunching 
    /// to finish promised features and get a release out on time. 
    /// This has left no one any time for testing!
    /// 
    /// When you voiced your concerns, Allan waved them away. 
    /// Apparently, he sat down with his laptop last night and 
    /// bashed out the tests himself.
    /// 
    /// While working on smaller tasks for GalaxyZ, you start to get an
    /// ominous feeling about the rocket launch tomorrow...
    /// Maybe these tests aren't as air-tight as Mush would have you believe.
    /// 
    /// This time instead of changing the code in RocketDiagnosticService.cs,
    /// can you instead fix the tests so that they all accurately report failures?
    /// 
    /// You can use the title of each test to make judgement on any
    /// test behaviour that needs modifying.
    /// </summary>
    public class RocketDiagnosticServiceTests
    {
        public Mock<IRocketIgnitionService> RocketIgnitionServiceMock { get; } = new();
        public Mock<IRocketTelemetryService> RocketTelemetryServiceMock { get; } = new();
        public Mock<ILifeSupportService> LifeSupportServiceMock { get; } =  new();
        public Mock<IAlertService> AlertServiceMock { get; } = new();

        [Fact]
        public async Task IgniteEnginesAndCount_RocketEnginesNull_ShouldNotThrow()
        {
            //arrange
            var testRocket = new Rocket()
            {
                Engines = null
            };

            RocketIgnitionServiceMock.Setup(x => x.IgniteEngineAsync(It.IsAny<Booster>()))
                .ReturnsAsync(false);

            var sut = CreateTestService();

            var result = 0;

            //act
            try
            {
                result = await sut.IgniteEnginesAndCountAsync(testRocket);
            }
            catch (Exception) { }

            //assert
            Assert.Equal(0, result);
        }

        [Fact]
        public async Task IgniteEnginesAndCount_NoEnginesIgnite_ShouldReturnZero()
        {
            //arrange
            var testRocket = new Rocket()
            {
                Engines = new List<Booster>
                {
                    new Booster()
                    {
                        HorsePower = 1,
                    },
                    new Booster()
                    {
                        HorsePower = 1,
                    }
                }
            };

            RocketIgnitionServiceMock.Setup(x => x.IgniteEngineAsync(It.IsAny<Booster>()))
                .ReturnsAsync(false);

            var sut = CreateTestService();

            //act
            var result = await sut.IgniteEnginesAndCountAsync(testRocket);

            //assert
            Equals(0, result);
        }

        [Fact]
        public async Task ReportFuelLinePressure_FuelLineIdEmpty_ShouldThrowError()
        {
            //arrange 

            var sut = CreateTestService();

            //act

            var exception = await sut.ReportFuelLinePressure(string.Empty);

            //assert
            Assert.NotNull(exception);
        }

        [Fact]
        public async Task TestLifeSupport_AllServicesCheckedAndOK_ReturnsNoMessages()
        {
            //arrange
            LifeSupportServiceMock.Setup(x => x.TestMainPower())
                .ReturnsAsync(new List<string>());
            LifeSupportServiceMock.Setup(x => x.TestAuxPower())
                .ReturnsAsync(new List<string>());
            LifeSupportServiceMock.Setup(x => x.TestTemperature())
                .ReturnsAsync(new List<string>());
            LifeSupportServiceMock.Setup(x => x.TestOxygen())
                .ReturnsAsync(new List<string>());

            var sut = CreateTestService();

            //act
            var result = await sut.TestLifeSupport();

            //assert
            Assert.Empty(result);
            LifeSupportServiceMock.Verify(x => x.TestTemperature(), Times.Once);
            LifeSupportServiceMock.Verify(x => x.TestOxygen(), Times.Once);
        }

        [Fact]
        public async Task TestLifeSupport_LifeSupportThrowsInvalidOpException_RethrowsAsExecutionEngineException()
        {
            //arrange
            await Task.Delay(1);

            LifeSupportServiceMock.Setup(x => x.TestMainPower())
                .ThrowsAsync(new InvalidOperationException());

            var sut = CreateTestService();

            //act
            var exception = Record.ExceptionAsync(() => sut.TestLifeSupport());

            //assert
            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);   
        }

        [Fact]
        public async Task TestLifeSupport_LifeSupportHasNoWarnings_ShouldNotAlert()
        {
            //arrange
            LifeSupportServiceMock.Setup(x => x.TestMainPower())
                .ReturnsAsync(new List<string>());
            LifeSupportServiceMock.Setup(x => x.TestAuxPower())
                .ReturnsAsync(new List<string>());
            LifeSupportServiceMock.Setup(x => x.TestTemperature())
                .ReturnsAsync(new List<string>());
            LifeSupportServiceMock.Setup(x => x.TestOxygen())
                .ReturnsAsync(new List<string>());

            AlertServiceMock.Setup(x => x.EnterAlertState(It.IsAny<string>()))
                .Verifiable();

            var sut = CreateTestService();

            //act
            var result = await sut.TestLifeSupport();

            //assert
            Assert.Empty(result);
            AlertServiceMock.Verify(x => x.EnterAlertState(It.IsAny<string>()), Times.Never);
        }

        private RocketDiagnosticService CreateTestService()
        {
            return new RocketDiagnosticService(
                RocketIgnitionServiceMock.Object,
                RocketTelemetryServiceMock.Object,
                LifeSupportServiceMock.Object,
                MockAlertService.Object
                );
        }

        Mock<IAlertService> MockAlertService { get; } = new();
    }
}
