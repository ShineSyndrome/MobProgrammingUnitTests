using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBalladOfAllanMush.Ventures.III___GalaxyZ
{
    public interface IAlertService
    {
        public Task EnterAlertState(string alertLevel);
    }
}
