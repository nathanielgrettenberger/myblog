using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class homeController : Controller
    {
        Models.MyBlogEntities db = new Models.MyBlogEntities();
        //
        // GET: /home/

        public ActionResult Index()

        {
            //
            return View(db.Posts.OrderByDescending(x=>x.DateCreate));
        }
       

    }
    // get: logout page
  
}
