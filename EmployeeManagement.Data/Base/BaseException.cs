using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Data.Base
{
    public class BaseException : Exception
    {
        public BaseException(string message)
            : base(message) { }
     
    }
}
