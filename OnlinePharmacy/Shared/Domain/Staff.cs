using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePharmacy.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOut { get; set; }
        public DateTime? DateIn { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Staff Type does not meet length requirements")]
        public string? StaffType { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet length requirements")]
        public string? Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Gender does not meet length requirements")]
        public string? Gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not a valid")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
        public string? PhoneNo { get; set; }

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
