using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using kursa42.ViewModels;
using kursa42.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace kursa42.Controllers
{
    public class AccountController : Controller
    {
        private UsersContext db;
        public AccountController(UsersContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.User = User.Identity.Name;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = await db.User.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация
                    ViewBag.User = User.Identity.Name;
                    return RedirectToAction("AdminPanel", "Account");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            ViewBag.User = User.Identity.Name;
            return View(model);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Register()
        {
            ViewBag.User = User.Identity.Name;
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = await db.User.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    db.User.Add(new Users { Email = model.Email, Password = model.Password });
                    await db.SaveChangesAsync();
                    ViewBag.User = User.Identity.Name;
                    return RedirectToAction("Login", "Account");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            ViewBag.User = User.Identity.Name;
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
        [Authorize]
        public IActionResult AdminPanel()
        {
            ViewBag.User = User.Identity.Name;
            return View(db.Messeng);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Editing(int? id)
        {
            try
            {
                if(id != null)
                {
                    var messeng = await db.Messeng.FirstOrDefaultAsync(p => p.Id == id);
                    ViewBag.Messeng = messeng;
                    ViewBag.MessengId = id;
                    ViewBag.User = User.Identity.Name;
                    return View();
                }
                ViewBag.Error = " Неизвестная ошибка";

                return RedirectToAction("AdminPanel", "Account");
            }
            catch
            {
                ViewBag.Error = "Неизвестная ошибка";
                return RedirectToAction("AdminPanel", "Account");
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Editing(Soobshenie messengs)
        {
            try
            {
                db.Messeng.Update(messengs);
                await db.SaveChangesAsync();
                ViewBag.User = User.Identity.Name;
                return RedirectToAction("AdminPanel", "Account");
            }
            catch
            {
                ViewBag.Error = "Ошибка";
                ViewBag.User = User.Identity.Name;
                return RedirectToAction("AdminPanel", "Account");
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult Moder()
        {
            if (User.Identity.Name == "Admin")
            {
                ViewBag.User = User.Identity.Name;
                return View(db.User);
            }
            else
            {
                return RedirectToAction("AdminPanel", "Account");
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddModer(Users user)
        {

            if (user != null && User.Identity.Name == "Admin")
            {
                db.User.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Moder");
            }
            ViewBag.Error = "Ошибка при добавлении модератора";
            return RedirectToAction("Moder");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DeleteUser(int? id)
        {
            try
            {
                if (id != null && User.Identity.Name == "Admin")
                {
                    Users user = await db.User.FirstOrDefaultAsync(p => p.Id == id);
                    if (user != null)
                    {
                        db.User.Remove(user);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Moder");
                    }
                }

            }
            catch
            {
                ViewBag.Error = "Ошибка при удалении модератора";
                return RedirectToAction("Moder");
            }
            ViewBag.Error = "Ошибка при удалении модератора";
            return RedirectToAction("Moder");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id != null)
                {
                    Soobshenie messeng = await db.Messeng.FirstOrDefaultAsync(p => p.Id == id);
                    if (messeng != null)
                    {
                        db.Messeng.Remove(messeng);
                        await db.SaveChangesAsync();
                        return RedirectToAction("AdminPanel");
                    }
                }

            }
            catch
            {
                ViewBag.Error = "Ошибка при удалении";
                return RedirectToAction("AdminPanel");
            }
            ViewBag.Error = "Ошибка при удалении";
            return RedirectToAction("AdminPanel");
        }
    }
}
