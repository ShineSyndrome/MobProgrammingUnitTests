using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBalladOfAllanMush.Ventures.II___Edison.Models;

namespace TheBalladOfAllanMush.Ventures.II___Edison
{
    public interface ISteering
    {
        Task<bool> AttemptSteering(Direction direction);
        Task<bool> SteeringOverride(Direction direction);
    }
}
