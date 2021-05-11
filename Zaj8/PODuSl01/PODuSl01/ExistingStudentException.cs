using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01
{
    public class ExistingStudentException : Exception
    {
        public ExistingStudentException(string message)
            : base(message)
        {
        }
    }
}
