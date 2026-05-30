using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage="Must type First name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }
        public string UserName { get; set; }


    }
}
