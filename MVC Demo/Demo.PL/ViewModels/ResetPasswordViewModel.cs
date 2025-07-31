using System.ComponentModel.DataAnnotations;
namespace Demo.Presentation.ViewModels
{
    public class ResetPasswordViewModel
    {
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Compare(nameof(NewPassword))]

      
        public string ConfirmNewPassword { get; set; }


    }
}
