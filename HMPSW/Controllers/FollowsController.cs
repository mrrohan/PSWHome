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

namespace HMPSW.Controllers
{
    public class FollowsController : Controller
    {
        private HMContext db = new HMContext();

        // GET: Follows
        public ActionResult Index()
        {
            return View(db.Follow.ToList());
        }

        // GET: Follows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Follow follow = db.Follow.Find(id);
            if (follow == null)
            {
                return HttpNotFound();
            }
            return View(follow);
        }

        // GET: Follows/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Follows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Followed,Follower")] Follow follow)
        {
            if (ModelState.IsValid)
            {
                db.Follow.Add(follow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(follow);
        }

        // GET: Follows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Follow follow = db.Follow.Find(id);
            if (follow == null)
            {
                return HttpNotFound();
            }
            return View(follow);
        }

        // POST: Follows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Followed,Follower")] Follow follow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(follow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(follow);
        }

        // GET: Follows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Follow follow = db.Follow.Find(id);
            if (follow == null)
            {
                return HttpNotFound();
            }
            return View(follow);
        }

        // POST: Follows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Follow follow = db.Follow.Find(id);
            db.Follow.Remove(follow);
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
