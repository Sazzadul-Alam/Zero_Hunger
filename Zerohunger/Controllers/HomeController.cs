using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zerohunger.Models;
using Zerohunger.Repository;

namespace Zerohunger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("AddUser");
        }

        UserRepo repo;

        public HomeController()
        {
            this.repo = new UserRepo();
        }
        // GET: User

        public ActionResult AddUser()
        {
            var data = repo.GetType();
            ViewBag.typeData = data;
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(UserModel user)
        {
            var data = repo.GetType();
            ViewBag.typeData = data;
            if (ModelState.IsValid)
            {
                var result = repo.AddUser(user);
                return RedirectToAction("Login");
            }

            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var result = repo.LoginUser(user);
                if (result == 1)
                {
                    return RedirectToAction("Home", "Employees");
                }
                else
                {
                    return RedirectToAction("Home", "Restaurants");

                    
                }

            }
            return View();
        }

    } // GET: User
   
}