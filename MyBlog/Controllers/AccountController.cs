using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; // add using for membership

namespace MyBlog.Controllers
{
    public class AccountController : Controller
    {
        // add a connection to the my bolg database
        Models.MyBlogEntities db = new Models.MyBlogEntities();
        //
        // GET: /Account/

        public ActionResult Index()
        {
            // to create a user
            Membership.CreateUser("admin", "techIsFun1");
            // to log someone in
            if (Membership.ValidateUser("admin", "techIsFun1"))
            {
                //user/pass is a macth log them in
                FormsAuthentication.SetAuthCookie("admin", false);
            
            }
            return View();
        }
        // get: / account/reister
        [HttpGet]
        public ActionResult Register()
        {
            // creating a blank register
            return View(new Models.Register());
        
        }
        //POST: Account/Register
        [HttpPost]
        public ActionResult Register(Models.Register reg)
        {
            // post action recives a Register object
            // 1. check to see if the username is already in use
            if (Membership.GetUser(reg.Username) == null)
            {
                // user is valid so add the usre
                Membership.CreateUser(reg.Username, reg.Password);

            
            }
            else
            {
                // username is already in use
                ViewBag.Error = " That Username is already in use my friend. You should pick another one. Be Different when picking how you want to be called on the wonderful blog";
                // return the view with the reg object
                return View(reg);
            }
            // add user to myblob authors
            Models.Author author = new Models.Author();
            //set the properties of our author 
            author.Username = reg.Username;
                author.Name = reg.Name;
                    author.ImageURL = reg.ImageURl;
                    if (author.ImageURL == null)
                    {
                        author.ImageURL = "";
                    
                    }
            // add authour to the database
                    db.Authors.Add(author);
                    db.SaveChanges();
            // log the user in
                    FormsAuthentication.SetAuthCookie(reg.Username, false);
                    return RedirectToAction("Index", "Home");
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");

        }
        // get 
        [HttpGet]
        public ActionResult Login()
        {
            return View(new Models.Login());
        
        }
        [HttpPost]
        public ActionResult login(Models.Login log)
        {
            if (Membership.ValidateUser(log.Username, log.Password))

            {
                FormsAuthentication.SetAuthCookie(log.Username, false);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Error = " Incorect Username/Password. Try again.";
                    return View(log);
            }
        }
            
        
        
        
        
              

    }
}
