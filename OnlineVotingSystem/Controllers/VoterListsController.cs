using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineVotingSystem.Models;
using Microsoft.AspNet.Identity;
using OnlineVotingSystem.Models.ViewModels;

namespace OnlineVotingSystem.Controllers
{
    public class VoterListsController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: VoterLists
        public ActionResult Index()
        {
            return View(db.VoterLists.ToList());
        }

        // GET: VoterLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoterList voterList = db.VoterLists.Find(id);
            if (voterList == null)
            {
                return HttpNotFound();
            }
            return View(voterList);
        }

        // GET: VoterLists/Create
        public ActionResult Create()
        {
            ViewBag.loginUserId = User.Identity.GetUserId();
            var presidentCandidates = db.Presidents.ToList();
            var vicePresidentCandidates = db.VicePresidents.ToList();
            var viewModel = new candidatesViewModel
            {
                PresidentCandidate = presidentCandidates, VicePresidentCandidate = vicePresidentCandidates

            };
            return View(viewModel);
        }

        // POST: VoterLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VoterId,userId,ElectionId,PresidentCandidateId,VicePresidentCandidateId,VotedTime")] VoterList voterList)
        {
            var userIdFromDb = User.Identity.GetUserId();
            var userAlreadyExists = db.VoterLists.Any(x => x.userId == userIdFromDb);
            if (userAlreadyExists)
            {
                ModelState.AddModelError("Email", "User with this email already exists");
                return RedirectToAction("Index");
            }
            else 
            {
                if (ModelState.IsValid)
                {
                    voterList.VotedTime = DateTime.Now;
                    voterList.userId = User.Identity.GetUserId();
                    var presidentIDForUpdate = db.Presidents.Find(voterList.PresidentCandidateId);
                    var vicePresidentIDForUpdate = db.VicePresidents.Find(voterList.VicePresidentCandidateId);
                    presidentIDForUpdate.TotalVote++;
                    vicePresidentIDForUpdate.TotalVote++;
                    
                    db.VoterLists.Add(voterList);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(voterList);
            }
            

            
        }

        // GET: VoterLists/Edit/5
        public ActionResult Edit(int? id)
        {
            candidatesViewModel voterList = new candidatesViewModel();
            voterList.PresidentCandidate = db.Presidents.ToList();
            voterList.VicePresidentCandidate = db.VicePresidents.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             voterList.VoterList = db.VoterLists.Find(id);
            if (voterList == null)
            {
                return HttpNotFound();
            }
            return View(voterList);
        }

        // POST: VoterLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VoterId,userId,ElectionId,PresidentCandidateId,VicePresidentCandidateId,VotedTime")] VoterList voterList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voterList).State = EntityState.Modified;
                voterList.VotedTime = DateTime.Now;
                voterList.userId = User.Identity.GetUserId();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voterList);
        }

        // GET: VoterLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoterList voterList = db.VoterLists.Find(id);
            if (voterList == null)
            {
                return HttpNotFound();
            }
            return View(voterList);
        }

        // POST: VoterLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VoterList voterList = db.VoterLists.Find(id);
            db.VoterLists.Remove(voterList);
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
