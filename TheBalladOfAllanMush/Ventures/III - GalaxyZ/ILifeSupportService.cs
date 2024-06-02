using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBalladOfAllanMush.Ventures.III___GalaxyZ
{
    public interface ILifeSupportService
    {
        public Task<List<string>> TestMainPower();
        public Task<List<string>> TestAuxPower();
        public Task<List<string>> TestOxygen();
        public Task<List<string>> TestTemperature();
        public Task RebootLifeSupport();
    }
}
