using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01
{
    class ExistingStudentExeption : SystemException
    {
        public ExistingStudentExeption() : base() { }
        public ExistingStudentExeption(string message) : base(message) { }
        public ExistingStudentExeption(string message, System.Exception inner) :
       base(message, inner)
        { }
    }
}
