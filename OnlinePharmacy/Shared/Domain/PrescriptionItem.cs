using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePharmacy.Shared.Domain
{
    public class PrescriptionItem : BaseDomainModel
    {
        public int? Quantity { get; set; }
        public virtual Product? Product { get; set; }
        public int ProductId { get; set; }
        public virtual Prescription? Prescription { get; set; }
        public int PrescriptionId { get; set; }
    }
}
