using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePharmacy.Shared.Domain
{
    public class Prescription : BaseDomainModel
    {
        public string? Prescription_Date { get; set; }
        public string? Prescription_Details { get; set; }
        public virtual User? User { get; set; }
        public virtual Staff? Staff { get; set; }
    }
}
