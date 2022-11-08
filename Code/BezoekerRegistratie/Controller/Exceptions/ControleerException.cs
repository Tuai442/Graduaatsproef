using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Exceptions
{
    public class ControleerException : Exception
    {
        public ControleerException(string? message) : base(message)
        {
        }

        public ControleerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
