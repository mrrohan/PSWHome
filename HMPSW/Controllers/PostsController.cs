using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HMPSW.DAL;
using HMPSW.Models;
using Microsoft.AspNet.Identity;

namespace HMPSW.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                ViewBag.catid = id; //id categoria para a view /POST/INDEX
                ViewBag.category = db.Category.FirstOrDefault(c => c.ID == id).Description; //nome da categoria seleccionada
                return View(db.Post.Where(p => p.Category.ID == id).ToList()); //lista de posts com a categoria do id recebido
            }

            return RedirectToAction("Index", "Categories");
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Post post = db.Post.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create(int? id)
        {
            ViewBag.catid = id;
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description,Tag")] Post post, int? catid)
        {
            ViewBag.catid = catid;
            if (ModelState.IsValid)
            {
                //GET ID
                string currentUserID = User.Identity.GetUserId();
                //Search in db for username with this id
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserID);
                post.Person = currentUser;

                post.Date = DateTime.Now;

                Category cat = db.Category.FirstOrDefault(c => c.ID == catid);
                post.Category = cat;
                
                db.Post.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index/"+catid);
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.catid = post.Category.ID;
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,Tag,Rep_plus,Rep_minus")] Post post, int catid)
        {
            ViewBag.catid = catid;
            if (ModelState.IsValid)
            {
                post.Date = DateTime.Now;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges(); 
                return RedirectToAction("Index/" + catid);
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id, int? catid)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {   
            Post post = db.Post.Find(id);
            var comment = post.Comment;
            foreach(var item in comment.ToList())
            {
                db.Comment.Remove(item);
            }
            db.Post.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
