using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBalladOfAllanMush.Ventures.II___Edison;

namespace UnitTests.II___Edison
{
    /// <summary>
    /// Good news. You did so well fixing those bugs that Allan has
    /// bought you on to his new electric car venture.
    /// The bad news is that the friendly QA has gotten fed-up, and left
    /// for greener pastures. Mr. Mush has decided that you're ready
    /// to write the unit tests in their place.
    /// 
    /// Luckily the code for Edison electric cars is much better quality.
    /// Luckier still, the QA managed to stub out the test cases required.
    /// 
    /// There are two parts to this section- 
    /// 
    /// 1) Fill out the tests in each placeholder method below.
    /// 2) Write new code for a requested feature, and then write the
    /// tests that will verify the behaviour requested.
    /// 
    /// The details for the second part are found at the bottom of this class.
    /// </summary>
    public class SelfDriveServiceTests
    {
        private Mock<ISpeedometer> SpeedometerMock { get; } = new();
        private Mock<IEngine> EngineMock { get; } = new();



        private SelfDriveService CreateTestService()
        {
            return new SelfDriveService(
                SpeedometerMock.Object,
                EngineMock.Object);
        }
    }
}
