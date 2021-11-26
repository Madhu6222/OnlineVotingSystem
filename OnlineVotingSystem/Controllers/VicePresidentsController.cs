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
    public class VicePresidentsController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VicePresidents
        public ActionResult Index()
        {
            return View(db.VicePresidents.ToList());
        }

        // GET: VicePresidents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VicePresident vicePresident = db.VicePresidents.Find(id);
            if (vicePresident == null)
            {
                return HttpNotFound();
            }
            return View(vicePresident);
        }

        // GET: VicePresidents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VicePresidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,TotalVote")] VicePresident vicePresident)
        {
            if (ModelState.IsValid)
            {
                db.VicePresidents.Add(vicePresident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vicePresident);
        }

        // GET: VicePresidents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VicePresident vicePresident = db.VicePresidents.Find(id);
            if (vicePresident == null)
            {
                return HttpNotFound();
            }
            return View(vicePresident);
        }

        // POST: VicePresidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,TotalVote")] VicePresident vicePresident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vicePresident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vicePresident);
        }

        // GET: VicePresidents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VicePresident vicePresident = db.VicePresidents.Find(id);
            if (vicePresident == null)
            {
                return HttpNotFound();
            }
            return View(vicePresident);
        }

        // POST: VicePresidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VicePresident vicePresident = db.VicePresidents.Find(id);
            db.VicePresidents.Remove(vicePresident);
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
