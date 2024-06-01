using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBalladOfAllanMush.Ventures.II___Edison.Constants;

namespace TheBalladOfAllanMush.Ventures.II___Edison
{
    public class SelfDriveService
    {
        private const int maxAccelerationCoefficient = 5;

        private ISpeedometer Speedometer { get; }
        private IEngine Engine { get; }

        public SelfDriveService(ISpeedometer speedometer,
            IEngine engine)
        {
            Speedometer = speedometer;
            Engine = engine;
        }

        public async Task<List<string>> AccelerateToSpeed(int targetSpeed)
        {
            if (targetSpeed < 0)
                throw new ArgumentException();

            List<string> messages = new();

            while (await Speedometer.GetCurrentSpeed() < targetSpeed)
            {
                var speedIncrease = Math.Max(maxAccelerationCoefficient, targetSpeed);

                var isSuccess = await Engine.Accelerate(speedIncrease);

                if (!isSuccess)
                    throw new InvalidOperationException();
            }

            return messages;
        }
    }
}
