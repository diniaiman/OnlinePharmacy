using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePharmacy.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        public string? StaffType { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public string? Permissions { get; set; }
        public string? DateOfBirth { get; set; }
    }
}
