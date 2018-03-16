﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HITWashing.Models;
using HITWashing.Models.DBClass;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using HITWashing.Models.EnumClass;
using Microsoft.AspNetCore.Authentication;

namespace HITWashing.Controllers
{
    public class HomeController : Controller
    {
        private readonly WashingContext _context;

        public HomeController(WashingContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Bind("AccountName,Password")] AccountModel accountModel)
        {
            //if (ModelState.IsValid)
            //{

            //}

            var find = await _context.AccountModels.FirstOrDefaultAsync(x =>
            x.AccountName == accountModel.AccountName && x.Password == accountModel.Password);

            if (find != null)
            {
                var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Sid, find.AccountName));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, find.Type.ToString()));

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
                });
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "用户名或密码错误！");

            return View(accountModel);
        }
    }
}
