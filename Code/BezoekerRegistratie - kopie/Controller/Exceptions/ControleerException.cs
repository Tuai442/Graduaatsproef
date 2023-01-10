using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Exceptions
{
    public class ControleerException : Exception
    {
        private string message1;

        public ControleerException(string? message) : base(message)
        {
        }

        public ControleerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public ControleerException(string? message, string message1) : this(message)
        {
            this.message1 = message1;
        }
    }
}
