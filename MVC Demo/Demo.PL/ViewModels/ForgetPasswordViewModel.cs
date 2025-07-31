using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
    }
}
