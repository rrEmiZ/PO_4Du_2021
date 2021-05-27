using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17.Dto
{
    public class StaffDto
    {
        public int? ManagerId { get; internal set; }
        public int StoreId { get; internal set; }
        public byte Active { get; internal set; }
        public string Phone { get; internal set; }
        public string Email { get; internal set; }
        public string LastName { get; internal set; }
        public string FirstName { get; internal set; }
        public int Id { get; internal set; }

        public int Orders { get; set; }
    }
}
