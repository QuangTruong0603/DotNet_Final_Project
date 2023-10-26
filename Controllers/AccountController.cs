using Microsoft.AspNetCore.Mvc;
using do_an_ck.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using do_an_ck.Service;
using do_an_ck.Helper;
namespace do_an_ck.Controllers
{
    
    public class AccountController : Controller
    {
        public EmailService _emailService;
        public WebBanHangDBContext _context;
        public AccountController(WebBanHangDBContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> SubmitLogin(string email, string password)
        {
            var user = _context.User.FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                HttpContext.Session.SetString("UserName", user.UserName);
                // Tạo claims cho tên người dùng và vai trò
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName), // Claim cho tên người dùng
                    new Claim(ClaimTypes.Role, user.role_id.ToString()),     // Claim cho vai trò
                };

                var claimsIdentity = new ClaimsIdentity(claims, "cookie");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Đăng nhập người dùng với các claims
                await HttpContext.SignInAsync(claimsPrincipal);

                if (user.role_id == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Users");
                }
            }
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitRegister(string email, string password, string confirm_password)
        {
            string confirmationLink = $"Click <a href=''>here</a> to confirm your registration";
            string emailBody = "Xác thực tài khoản";
            
            SendMail.SendEMail(email, emailBody, confirmationLink,"");
            
            return RedirectToAction("Index", "Home");
        }
        public async Task <IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Remove("UserName"); // Xóa giá trị cũ

            // Thêm giá trị mới hoặc thực hiện các thao tác khác
            

            // Chuyển hướng hoặc trả về trang nào đó sau khi đăng xuất
            return RedirectToAction("Index", "Home");
        }
    }
}
