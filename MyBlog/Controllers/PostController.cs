using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    // reqiure the user to the login page
    [Authorize()]
    public class PostController : Controller
    {
        //make a connection so the database
        Models.MyBlogEntities db = new Models.MyBlogEntities();
        //
        // GET: /Post/

        public ActionResult Index()
        {
            // the index will return all the users posts
            return View(db.Posts.Where(x=>x.Username == User.Identity.Name.ToLower()));
        }
        // Get: post/create
        [HttpGet]
        public ActionResult Create()
        {
            // pass a blank post
            return View(new Models.Post());
        
        }
        // public
        public ActionResult Create(Models.Post post)
        {
            post.Username = User.Identity.Name;
            // set the time to now
            post.DateCreate = DateTime.Now;
            post.Likes = 0;
            // make sure imageurl has value
            if (post.ImageURL == null)
            {
                post.ImageURL = "";
            
            }
            //save it to that data base
            db.Posts.Add(post);
            db.SaveChanges();
            // kick user back to thi post
            return RedirectToAction("Index", "Post");
        }
        //GET: /Post/Delete/{if}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Models.Post postToDelete = db.Posts.Find(id);
            return View(postToDelete);

        
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
            // get post from dadt base
        {
            Models.Post postToDelete = db.Posts.Find(id);
            // delete the post from the database
            db.Posts.Remove(postToDelete);
            db.SaveChanges();
            return RedirectToAction("Index", "Post");
        
        }
        public ActionResult Edit(int id)
        {
            Models.Post postToEdit = db.Posts.Find(id);
            return View(postToEdit);
        
        }
        [HttpPost]
        public ActionResult Edit(Models.Post postToEdit)
        {
            db.Entry(postToEdit).State = System.Data.EntityState.Modified;
            // kick them back to th
            
            //saveChanges();  
            db.SaveChanges();
         return RedirectToAction("Index", "Post"); 
           
        }
        
            

    }
}
