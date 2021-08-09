using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAL.Domain.CustomExceptions
{
    public class AppExceptions : Exception
    {
        public int status { get; set; }

        public AppExceptions(string message, int _status) : base(message)
        {
            status = _status; 
        }
    }
}
