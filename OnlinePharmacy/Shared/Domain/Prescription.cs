using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePharmacy.Shared.Domain
{
    public class Prescription : BaseDomainModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOut { get; set; }
        public DateTime? DateIn { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Prescription Details does not meet length requirements")]
        public string? Prescription_Details { get; set; }
        [Required]
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual Staff? Staff { get; set; }
        public int? StaffId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();

            if (DateIn != null)
            {
                if (DateIn <= DateOut)
                {
                    yield return new ValidationResult("DateIn must be greater than DateOut", new[] { "DateIn" });
                }
            }
        }
    }
}
