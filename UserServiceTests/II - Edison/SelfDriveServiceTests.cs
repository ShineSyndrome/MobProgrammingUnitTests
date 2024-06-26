﻿using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBalladOfAllanMush.Ventures.II___Edison;
using TheBalladOfAllanMush.Ventures.II___Edison.Exceptions;
using TheBalladOfAllanMush.Ventures.II___Edison.Models;

namespace UnitTests.II___Edison
{
    /// <summary>
    /// Good news! You did so well fixing those bugs that Allan has
    /// bought you on to his new electric car venture.
    /// The bad news is that the friendly QA has gotten fed-up, and left
    /// for greener pastures. Mr. Mush has decided that you're ready
    /// to write unit tests instead.
    /// 
    /// Luckily the code for Edison electric cars is much better quality.
    /// Even better, the QA managed to stub out the test cases required.
    /// 
    /// There are two parts to this section- 
    /// 
    /// 1) First, fill out the tests in each placeholder method below,
    /// using the method names as guidance.
    /// 2) Write new code for a requested feature, and then write the
    /// tests that will verify the behaviour requested.
    /// 
    /// The details for the second part are found in ..\TrolleyProblem.txt
    /// </summary>
    public class SelfDriveServiceTests
    {
        private Mock<ISpeedometer> SpeedometerMock { get; } = new();
        private Mock<IEngine> EngineMock { get; } = new();
        private Mock<ISteering> SteeringMock { get; } = new();

        [Fact]
        public async Task EvadePedestrian_ParameterNull_ShouldThrowArgumentException()
        {
            //arrange

            var sut = CreateTestService();

            //act (hint: Xunit Record)


            //assert 

        }

        [Fact]
        public async Task EvadePedestrian_PedestrianIsToRight_ShouldSteerAndReturnLeft()
        {
            //arrange

            var sut = CreateTestService();

            //act

            //assert (Hint: Moq Verify can prove a service was used)
        }

        [Fact]
        public async Task EvadePedestrian_PedestrianIsToLeft_ShouldSteerAndReturnRight()
        {
            //arrange

            var sut = CreateTestService();

            //act

            //assert

        }

        [Fact]
        public async Task EvadePedestrian_PedestrianIsBehindCar_ShouldNotSteer()
        {
            //arrange

            var sut = CreateTestService();

            //act

            //assert (Hint: sometimes you need to verify something *did not* happen)

        }

        [Fact]
        public async Task EvadePedestrian_SteeringServiceError_ShouldThrowSelfDriveException()
        {
            //arrange

            var sut = CreateTestService();

            //act

            //assert
        }

        [Fact]
        public async Task AccelerateToSpeed_TargetSpeedAboveMaxCoefficient_ShouldAccelerateMultipleTimes()
        {
            //arrange
            //hint: moq callbacks can give a lot of flexibility when
            //you need to track some internal state
            //
            //...Of course if you aren't careful you might get an infinite loop.
            //I promise this is as hard as Moq gets!

            var sut = CreateTestService();

            //act

            //assert
        }

        [Fact]
        public async Task AccelerateToSpeed_TargetSpeedLessThanMaxCoefficient_ShouldAccelerateOnce()
        { 
            //arrange

            //act

            //assert
        }

        private SelfDriveService CreateTestService()
        {
            return new SelfDriveService(
                SpeedometerMock.Object,
                EngineMock.Object,
                SteeringMock.Object);
        }
    }
}
