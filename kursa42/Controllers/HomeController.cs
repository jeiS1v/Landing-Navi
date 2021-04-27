using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using kursa42.Models;
using Microsoft.AspNetCore.Authorization;

namespace kursa42.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsersContext db;
        public HomeController(UsersContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            // return Content(User.Identity.Name);
            return View();
        }

        [HttpPost]
        public async Task <IActionResult>  Messeng (Soobshenie mess)
        {
            if (mess != null)
            {
                try
                {
                    db.Messeng.Add(mess);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Error = "Ошибка отправки сведения";
                    return RedirectToAction("Index");
                }

            }
            ViewBag.Error = "Ошибка отправки сведения";
            return RedirectToAction("Index");
        }
    }
}
