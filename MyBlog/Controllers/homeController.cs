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
       // get: /home/like/id
        public ActionResult Like(int id)
        {
            // go to the data base and retrive the post that macthes the id
            Models.Post post = db.Posts.Find(id);
            post.Likes = post.Likes + 1;
            // save the changes in to the database
            db.SaveChanges();
            //return the number of likes
            return Content(post.Likes + "likes");
        
        }
        //ajax post : /home/addComment
        public ActionResult addComment(Models.Comment c)
        {
            //  set the other properties of the other comment
            c.DateCreate = DateTime.Now;
            //add it to tthe database
            db.Comments.Add(c);
            db.SaveChanges();
            return PartialView("comment", c);

        }


        }
}
