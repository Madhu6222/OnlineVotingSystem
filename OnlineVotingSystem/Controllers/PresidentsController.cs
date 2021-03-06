using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineVotingSystem.Models;

namespace OnlineVotingSystem.Controllers
{
    public class PresidentsController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Presidents
        public ActionResult Index()
        {
            return View(db.Presidents.ToList());
        }

        // GET: Presidents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            President president = db.Presidents.Find(id);
            if (president == null)
            {
                return HttpNotFound();
            }
            return View(president);
        }

        // GET: Presidents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Presidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,TotalVote")] President president)
        {
            if (ModelState.IsValid)
            {
                db.Presidents.Add(president);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(president);
        }

        // GET: Presidents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            President president = db.Presidents.Find(id);
            if (president == null)
            {
                return HttpNotFound();
            }
            return View(president);
        }

        // POST: Presidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,TotalVote")] President president)
        {
            if (ModelState.IsValid)
            {
                db.Entry(president).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(president);
        }

        // GET: Presidents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            President president = db.Presidents.Find(id);
            if (president == null)
            {
                return HttpNotFound();
            }
            return View(president);
        }

        // POST: Presidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            President president = db.Presidents.Find(id);
            db.Presidents.Remove(president);
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
