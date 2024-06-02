using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBalladOfAllanMush.Ventures.II___Edison.Exceptions
{
    public class SelfDriveException : Exception
    {
        public SelfDriveException() { }
        public SelfDriveException(string message) : base(message) { }
        public SelfDriveException(string message, Exception inner) : base(message, inner) { }
    }
}
