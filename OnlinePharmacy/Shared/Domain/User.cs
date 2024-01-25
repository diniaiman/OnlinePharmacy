using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePharmacy.Shared.Domain
{
    public class User : BaseDomainModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNo { get; set; }
        public string? Gender { get; set; }
        public string? DateOfBirth { get; set; }
        public virtual List<Appointment>? Appointments { get; set; }

    }
}
