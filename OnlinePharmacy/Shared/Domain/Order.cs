using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePharmacy.Shared.Domain
{
    public class Order : BaseDomainModel
    {
        public string? Order_Date { get; set; }
        public string? Order_Status { get; set; }
        public virtual User? User { get; set; }
        public virtual Staff? Staff { get; set; }

     
    }
}
