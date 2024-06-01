using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
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
    /// Allan Mush was so impressed with your work squashing those bugs,
    /// he bought you aboard his space faring venture!
    /// 
    /// Sadly the friendly QA has been fired, but Allan has assured you that
    /// everything will be fine. This time he wrote all the tests himself!
    /// 
    /// While working on smaller tasks for GalaxyZ, you start to get an
    /// ominous feeling about the rocket launch tomorrow...
    /// Maybe these tests aren't as air-tight as Mush would have you believe.
    /// 
    /// This time instead of changing the code in RocketDiagnosticService.cs,
    /// can you instead fix the tests so that they accurately report failures?
    /// 
    /// You can use the title of each test to make judgement on any
    /// test behaviour that needs modifying.
    /// </summary>
    public class RocketDiagnosticServiceTests
    {
        public Mock<IRocketIgnitionService> RocketIgnitionServiceMock { get; } = new();

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

        private RocketDiagnosticService CreateTestService()
        {
            return new RocketDiagnosticService(
                RocketIgnitionServiceMock.Object);
        }
    }
}
