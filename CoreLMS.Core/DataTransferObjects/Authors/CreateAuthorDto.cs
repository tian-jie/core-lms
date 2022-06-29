using System.ComponentModel.DataAnnotations;

namespace CoreLMS.Core.DataTransferObjects
{
    public class CreateAuthorDto : IDto
    {
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string Suffix { get; set; }

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Phone]
        public string ContactPhoneNumber { get; set; }

        public string Description { get; set; }
        public string WebsiteURL { get; set; }
    }
}
