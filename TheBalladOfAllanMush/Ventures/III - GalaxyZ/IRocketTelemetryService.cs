using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBalladOfAllanMush.Ventures.III___GalaxyZ
{
    public interface IRocketTelemetryService
    {
        public Task<int> GetFuelLinePressureById(string Id);
    }
}
