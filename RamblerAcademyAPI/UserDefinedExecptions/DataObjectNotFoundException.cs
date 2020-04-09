using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.UserDefinedExecptions
{
    public class DataObjectNotFoundException : Exception
    {
        public DataObjectNotFoundException() 
        { 
        }

        public DataObjectNotFoundException(string message)
            : base(message)
        {

        }

        public DataObjectNotFoundException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
