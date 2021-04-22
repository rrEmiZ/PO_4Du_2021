using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01.Data.Interfaces
{
   public interface IOsoba
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        string GetFullName();

    }
}
