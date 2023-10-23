using Microsoft.AspNetCore.Mvc;
using do_an_ck.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
        public IActionResult SupmitLogin(String email, String password)
        {
            var user_email = _context.User.FirstOrDefault(x => x.Email == email);
            var user_password = _context.User.FirstOrDefault(y => y.Password == password);
            
            if(user_email == null || user_password == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                HttpContext.Session.SetString("UserName", user_email.UserName);
                
                if (user_email.role_id == 1)
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
            string emailBody = "Xác thwucj tài khoản";
            
            SendMail.SendEMail(email, emailBody, confirmationLink,"");
            
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserName"); // Xóa giá trị cũ

            // Thêm giá trị mới hoặc thực hiện các thao tác khác
            

            // Chuyển hướng hoặc trả về trang nào đó sau khi đăng xuất
            return RedirectToAction("Index", "Home");
        }
    }
}
