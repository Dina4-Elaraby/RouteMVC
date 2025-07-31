using Demo.DataAccess.Models.IdentityModel;
using Demo.Presentation.Utilties;
using Demo.Presentation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Demo.Presentation.Controllers
{
    public class AuthController(UserManager<ApplicationUser> _userMnager, SignInManager<ApplicationUser> _signInManager) : Controller
    {

        #region Register
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = new ApplicationUser()
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
            };
            var result = _userMnager.CreateAsync(user, registerViewModel.Password).Result;
            if (result.Succeeded) // can register
                return RedirectToAction("Login");
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(registerViewModel);
        }

        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);
            //Get Email
            var UserEmail = _userMnager.FindByEmailAsync(loginViewModel.Email).Result;
            if (UserEmail is not null)
            {
                var flag = _userMnager.CheckPasswordAsync(UserEmail, loginViewModel.Password).Result;

                if (flag)
                {
                    var result = _signInManager.PasswordSignInAsync(UserEmail, loginViewModel.Password, loginViewModel.RememberMe, false).Result;
                    if (result.IsNotAllowed)
                        ModelState.AddModelError(string.Empty, "You are not allowed to login");
                    if (result.IsLockedOut)
                        ModelState.AddModelError(string.Empty, "Your account is lockedout");
                    if (result.Succeeded)
                        return RedirectToAction(nameof(HomeController.Index), "Home");

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invaled Login");
                }


            }

            return View(loginViewModel);
        }

        #endregion

        public IActionResult SignOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult ForgetPassword() => View();

        [HttpPost]
        public IActionResult SendResetPasswordLink(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            if(ModelState.IsValid)
            {
                //Get user by email
                var User = _userMnager.FindByEmailAsync(forgetPasswordViewModel.Email).Result;
                if(User is not null)
                {
                    var Token = _userMnager.GeneratePasswordResetTokenAsync(User).Result;
                    // formate link of url
                    var ResetPasswordLink = Url.Action("ResetPassword", "Auth", new { email = forgetPasswordViewModel.Email, Token }, Request.Scheme);
                    var email = new Email()
                    {
                        To = forgetPasswordViewModel.Email,
                        Subject = "Reset password",
                        Body = ResetPasswordLink,
                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(CheckInBox));
                }
            }
            //if model state is not valid
            ModelState.AddModelError(string.Empty, "Invalid Operation");
            return View(nameof(ForgetPassword), forgetPasswordViewModel);
        }

        [HttpGet]
        public IActionResult CheckInBox() => View();

        public IActionResult ResetPassword(string email,string token)
        {
            //can send email and token from email send to this action to action post reset password
            TempData["email"] = email;
            TempData["token"] = token;

            return View(); 
        }
       
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid) return View(resetPasswordViewModel);
            // get email and token to make reset password
            var email = TempData["email"] as string;
            var token = TempData["token"] as string;

            var User = _userMnager.FindByEmailAsync(email).Result;
            var resetPassword = _userMnager.ResetPasswordAsync(User, token, resetPasswordViewModel.NewPassword).Result;
            if(resetPassword.Succeeded)
                     return RedirectToAction(nameof(Login));
            else
            {
                foreach(var error in resetPassword.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(nameof(ResetPassword), resetPasswordViewModel);
        }
       
    }

}
