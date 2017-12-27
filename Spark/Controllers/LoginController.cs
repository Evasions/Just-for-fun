using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spark.Models;
using System.Web.Security;

namespace Spark.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel _loginUser)
        {
            if (ModelState.IsValid) {
                User userLogin = null;
                using (UserContext dbUserContext = new  UserContext()) {
                    userLogin = dbUserContext.Users.FirstOrDefault(dbU => dbU.Email == _loginUser.Email && dbU.Password == _loginUser.Password);
                }
                if (userLogin != null) {
                    FormsAuthentication.SetAuthCookie(_loginUser.Email, true);
                    return RedirectToAction("Index", "Home");
                }else {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }

            }
            return View(_loginUser);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel _registerUser)
        {
            if (ModelState.IsValid) {
                User userRegister = null;
                using (UserContext dbRegisterContext = new UserContext()) {
                    userRegister = dbRegisterContext.Users.FirstOrDefault(dbU => dbU.Email == _registerUser.Email);
                }
                if (userRegister == null) {
                    // создаем нового пользователя
                    using (UserContext dbRegisterContext = new UserContext()) {
                        dbRegisterContext.Users.Add(new Models.User { Email = _registerUser.Email, Password = _registerUser.Password, Age = _registerUser.Age });
                        dbRegisterContext.SaveChanges();

                        userRegister = dbRegisterContext.Users.Where(dbU => dbU.Email == _registerUser.Email && dbU.Password == _registerUser.Password).FirstOrDefault();
                    }if (userRegister != null) {
                        FormsAuthentication.SetAuthCookie(_registerUser.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(_registerUser);
        }
    }
}