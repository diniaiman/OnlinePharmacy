using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePharmacy.Shared.Domain
{
    public class Product : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet length requirements")]
        public string? Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Description does not meet length requirements")]
        public string? Description { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet length requirements")]
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Category does not meet length requirements")]
        public string? Category { get; set; }
    }
}
