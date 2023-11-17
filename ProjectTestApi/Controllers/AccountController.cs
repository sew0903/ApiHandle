using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using ProjectTestApi.Models.API;
using ProjectTestApi.Models.Const;
using ProjectTestApi.Models.ViewModel;
using System.Security.Claims;
using System.Text.Json;
using System.Web;

namespace ProjectTestApi.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(loginViewModel.email) && !string.IsNullOrEmpty(loginViewModel.password))
                    {
                        string ApiLogin = MyConstanst.SiteName1 + "userlogin.asp?userid="
                         + loginViewModel.email.ToString() + "&pass="
                         + loginViewModel.password
                         .ToString();

                        var result = await HandleLogin(ApiLogin);

                        if (int.Parse(result[0].maloi) != 0)
                        {
                            SaveCoookie(loginViewModel, int.Parse(result[0].chucnang), result[0].memberid);
                            TempData["SuccessLogin"] = "Tài khoản " + result[0].user + " đăng nhập thành công!";
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return View();

        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            LogoutHandle();
            TempData["SuccessLogin"] = "Đăng xuất thành công!";
            return RedirectToAction("Index", "Home");
        }
        private async Task<List<ApiLoginModel>> HandleLogin(string url)
        {
            using (var httpContext = new HttpClient())
            {
                string jsonContent = await httpContext.GetStringAsync(url);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                if (jsonContent.Length != 0)
                {
                    List<ApiLoginModel> apiLoginModel = JsonSerializer.Deserialize<List<ApiLoginModel>>(jsonContent, options);

                    if (apiLoginModel != null)
                    {
                        return apiLoginModel;
                    }
                }
            }
            return null;
        }

        private async Task SaveCoookie(LoginViewModel loginViewModel, int? typeAccount,string? memberId)
        {
            List<Claim> lst = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,loginViewModel.email),
                new Claim(ClaimTypes.Name,loginViewModel.email),
                new Claim(ClaimTypes.Hash,loginViewModel.password)

            };
            ClaimsIdentity ci = new ClaimsIdentity(lst
                , Microsoft
                .AspNetCore
                .Authentication
                .Cookies
                .CookieAuthenticationDefaults
                .AuthenticationScheme);

            ClaimsPrincipal cp = new ClaimsPrincipal(ci);

            var option = new CookieOptions()
            {
                Path = "/",
                Expires = DateTime.Now.AddMonths(1)
            };

            HttpContext.Response.Cookies.Append(MyConstanst.KeyUserNameCookies, loginViewModel.email, option);
            HttpContext.Response.Cookies.Append(MyConstanst.KeyPasswordCookies, loginViewModel.password, option);
            HttpContext.Response.Cookies.Append(MyConstanst.KeyTypeLAccountCookies, typeAccount.ToString(), option);
            HttpContext.Response.Cookies.Append(MyConstanst.KeyMemberIdCookies, memberId, option);

            HttpContext.SignInAsync(cp);
        }

        private async Task LogoutHandle()
        {
			Response.Cookies.Delete(MyConstanst.KeyUserNameCookies);
			Response.Cookies.Delete(MyConstanst.KeyPasswordCookies);
            Response.Cookies.Delete(MyConstanst.KeyTypeLAccountCookies);

			HttpContext.SignOutAsync();
        }
        //public async Task<IActionResult> LoginWithGoogle()
        //{
        //    var authenticationProperties = new AuthenticationProperties
        //    {
        //        RedirectUri = Url.Action("GoogleLoginCallback", "Account"),
        //    };

        //    await HttpContext.ChallengeAsync("Google", authenticationProperties);

        //    return new EmptyResult();
        //}
        //public async Task<IActionResult> GoogleLoginCallback()
        //{
        //    var authenticateResult = await HttpContext.AuthenticateAsync("Google");

        //    if (!authenticateResult.Succeeded)
        //    {
        //        // Xử lý lỗi xác thực, nếu có
        //        return RedirectToAction("Login"); // Chuyển hướng đến trang đăng nhập
        //    }

        //    // Xử lý sau khi đăng nhập thành công, ví dụ: đăng ký tài khoản hoặc đưa người dùng đến trang chính của ứng dụng
        //    return RedirectToAction("Index", "Home");
        //}

    }
}
