using System.ComponentModel.DataAnnotations;

namespace RedingtonTask.Domain.Entities
{
    public class ProbabilityViewModel
    {
        [Required]
        [Range(0.0, 1,
            ErrorMessage = "The value for {0} must be between 0 and 1.")]
        public decimal FirstValue { get; set; }

        [Required]
        [Range(0.0, 1,
            ErrorMessage = "Value for {0} must be float between 0 to 1.")]
        public decimal SecondValue { get; set; }

        [Required]
        public FunctionType FunctionType { get; set; }
    }
}
