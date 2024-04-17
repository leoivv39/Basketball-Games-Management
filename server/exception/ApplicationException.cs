using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.exception
{
    public class ApplicationException : Exception
    {
        public int StatusCode { get; }

        public ApplicationException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
