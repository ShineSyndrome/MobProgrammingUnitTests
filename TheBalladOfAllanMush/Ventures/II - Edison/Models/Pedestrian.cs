using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBalladOfAllanMush.Ventures.II___Edison.Models
{
    public class Pedestrian
    {
        /// <summary>
        /// Direction of pedestrian relative to car.
        /// eg.
        /// 0 is straight ahead, 
        /// 90 is to the right
        /// -90 is to the left
        /// 180 or -180 is behind.
        /// </summary>
        public short Bearing { get; } = 0;
    }
}
