using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Exceptions
{
    public class AfspraakException : Exception
    {
        public AfspraakException(string? message) : base(message)
        {
        }

        public AfspraakException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
