using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBalladOfAllanMush.Ventures.II___GalaxyZ.Models;

namespace TheBalladOfAllanMush.Ventures.II___GalaxyZ
{
    public interface IRocketIgnitionService
    {
        /// <summary>
        /// Attempts to ignite an engine and reports success or failure.
        /// </summary>
        /// <returns>1 if successful, 0 if not.</returns>
        public Task<bool> IgniteEngineAsync(Engine engine);
    }
}
