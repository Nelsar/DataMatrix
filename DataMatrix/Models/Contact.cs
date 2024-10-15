using System.Net;
using System.ComponentModel.DataAnnotations;

namespace DataMatrix.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Incorrect address")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Incorrect Phone Number")]
        public string Phone { get; set; }
    }
}
