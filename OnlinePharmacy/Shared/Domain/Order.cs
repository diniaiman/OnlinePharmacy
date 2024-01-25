using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlinePharmacy.Shared.Domain
{
    public class Order : BaseDomainModel 
    {

        public string? Order_Date{ get; set; }
        public string? Order_Status { get; set; }
        public virtual Customer? Customer { get; set; }
        public int CustomerId {  get; set; }
        public virtual Staff? Staff { get; set; }

        
    }
}
