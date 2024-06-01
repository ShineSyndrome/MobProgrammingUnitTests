using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBalladOfAllanMush.Ventures.III___GalaxyZ.Models;

namespace TheBalladOfAllanMush.Ventures.III___GalaxyZ
{
    /// <summary>
    /// Remember not to change this code, 
    /// no matter how tempting it is to fix!
    /// </summary>
    public class RocketDiagnosticService
    {
        private IRocketIgnitionService RocketIgnitionService { get; }

        public RocketDiagnosticService(
            IRocketIgnitionService rocketIgnitionService
            )
        { 
            RocketIgnitionService = rocketIgnitionService;
        }

        /// <summary>
        /// Attempts to ignite all engines and then
        /// returns count of how many were successful.
        /// </summary>
        /// <returns>Count of ignited engines</returns>
        public async Task<int> IgniteEnginesAndCountAsync(Rocket rocket)
        {
            if (rocket is null)
                return 0;

            int count = 0;

            foreach (var engine in rocket.Engines)
            {
                bool ignited = await RocketIgnitionService.IgniteEngineAsync(engine);

                if (!ignited)
                {
                    engine.Ignited = true;
                    count++;
                }
            }

            return count;
        }
    }
}
