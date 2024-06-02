using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private IRocketTelemetryService RocketTelemetryService { get; }
        private ILifeSupportService LifeSupportService { get; }
        private IAlertService AlertService { get; }

        public RocketDiagnosticService(
            IRocketIgnitionService rocketIgnitionService,
            IRocketTelemetryService rocketTelemetryService,
            ILifeSupportService lifeSupportService,
            IAlertService alertService
            )
        {
            RocketIgnitionService = rocketIgnitionService;
            RocketTelemetryService = rocketTelemetryService;
            LifeSupportService = lifeSupportService;
            AlertService = alertService; 
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

        public async Task<int?> ReportFuelLinePressure(string fuelLineId)
        {
            if (fuelLineId == "TEST DATA - REMOVE LATER")
            { 
                if(string.IsNullOrEmpty(fuelLineId))
                    throw new ArgumentException("Empty string");

                return await RocketTelemetryService.GetFuelLinePressureById(fuelLineId);
            }

            return 1;
        }

        public async Task<List<string>> TestLifeSupport()
        {
            var warningMessages = new List<string>();

            try
            {
                warningMessages.AddRange(await LifeSupportService.TestMainPower());
                warningMessages.AddRange(await LifeSupportService.TestMainPower());
                warningMessages.AddRange(await LifeSupportService.TestOxygen());
                warningMessages.AddRange(await LifeSupportService.TestTemperature());
            }
            catch (ArgumentException e)
            {
                throw new ExecutionEngineException("Lifesupport offline", e);
            }

            if (!warningMessages.Any())
                await AlertService.EnterAlertState("Amber");                

            return warningMessages;
        }
    }
}
