using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePharmacy.Shared.Domain
{
    public class Appointment : BaseDomainModel
    {
        public string? Appointment_Date { get; set; }
        public string? Appointment_Time { get; set; }
        public string? Appointment_Status { get; set; }
        public virtual User? User { get; set; }
        public virtual Staff? Staff { get; set; }
    }
}
