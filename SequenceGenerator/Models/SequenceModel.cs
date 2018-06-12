using System.ComponentModel.DataAnnotations;

namespace SequenceGenerator.Models
{
    public class SequenceModel
    {
        [Required(ErrorMessage ="Please enter a whole number")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Please Enter a Valid Whole Number e.g 0,1..")]
        [Display(Name = "Please Enter a whole Number")]
        public int? EnteredInput { get; set; }

        public Sequences Sequences { get; set; }
    }
}