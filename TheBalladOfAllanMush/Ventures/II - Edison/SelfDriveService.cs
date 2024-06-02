using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBalladOfAllanMush.Ventures.II___Edison.Exceptions;
using TheBalladOfAllanMush.Ventures.II___Edison.Models;

namespace TheBalladOfAllanMush.Ventures.II___Edison
{
    public class SelfDriveService : ISelfDriveService
    {
        private const int maxAccelerationCoefficient = 5;

        private ISpeedometer Speedometer { get; }
        private IEngine Engine { get; }
        private ISteering Steering { get; }

        public SelfDriveService(ISpeedometer speedometer,
            IEngine engine,
            ISteering steering)
        {
            Speedometer = speedometer;
            Engine = engine;
            Steering = steering;
        }

        public async Task<Direction> EvadePedestrian(Pedestrian pedestrian)
        {
            if (pedestrian is null)
                throw new ArgumentException();

            if (pedestrian.Bearing < -90 || pedestrian.Bearing > 90)
                return Direction.Center;

            try
            {
                return await EvasiveManeuver(pedestrian.Bearing);
            }
            catch (InvalidOperationException ex)
            {
                throw new SelfDriveException("Steering Fault", ex);
            }
        }

        private async Task<Direction> EvasiveManeuver(short bearing)
        {
            Direction direction = bearing >= 0 ? Direction.Left : Direction.Right;

            var success = await Steering.AttemptSteering(direction);

            if (!success)
                throw new InvalidOperationException();

            return direction;
        }

        public async Task AccelerateToSpeed(int targetSpeed)
        {
            while (await Speedometer.GetCurrentSpeed() < targetSpeed)
            {
                var speedIncrease = Math.Min(maxAccelerationCoefficient, targetSpeed);

                await Engine.Accelerate(speedIncrease);
            }
        }
    }
}
