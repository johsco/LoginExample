using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using LoginExample.Interfaces.Managers;
using LoginExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginExample.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserManager _userManager;

        public LoginController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserName(UserLoginRequest loginRequest)
        {
            return RedirectToAction("Password", loginRequest);
        }

        public ActionResult Password(UserLoginRequest loginRequest)
        {
            return View(loginRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginRequest loginRequest)
        {
            //Bad login
            if (await _userManager.LoginUserAsync(loginRequest) == false)
            {
                return RedirectToAction("Index");
            }


            ControllerContext.HttpContext.Session.SetString("UserName", loginRequest.UserName);

            return RedirectToAction("Index", "Home");

        }
    }
}