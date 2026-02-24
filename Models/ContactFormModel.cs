using System.ComponentModel.DataAnnotations;

namespace ITCOnsultantWebsite.Models
{
    // This is a simple model to capture contact form data
    public class ContactFormModel
    {
        // Model properties becomes non-nullable with [Required] attributes
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Message { get; set; } = string.Empty;
    }
}