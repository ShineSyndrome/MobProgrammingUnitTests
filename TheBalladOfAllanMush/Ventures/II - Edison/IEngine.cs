﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBalladOfAllanMush.Ventures.II___Edison
{
    public interface IEngine
    {
        Task<bool> Accelerate(int accelerationCoefficient);
    }
}
