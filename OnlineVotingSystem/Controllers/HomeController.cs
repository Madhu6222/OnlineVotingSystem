using OnlineVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineVotingSystem.Controllers
{
    public class HomeController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PresidentBarGraph()
        {

            var nameList = (from names in db.Presidents
                        where names.Name != ""
                        select names.Name).ToArray();

            var voteList = (from vote in db.Presidents
                            select vote.TotalVote).ToArray();

            var winningCandi = db.Presidents
                                .OrderByDescending(e => e.TotalVote)
                                .First();

            ViewBag.name = nameList;
            ViewBag.vote = voteList;
            ViewBag.winningCandidate = winningCandi.Name;

            return View();
        }

        public ActionResult PresidentPieGraph()
        {

            var nameList = (from names in db.Presidents
                            where names.Name != ""
                            select names.Name).ToArray();

            var voteList = (from vote in db.Presidents
                            select vote.TotalVote).ToArray();
            var winningCandi = db.Presidents
                                .OrderByDescending(e => e.TotalVote)
                                .First();

            ViewBag.name = nameList;
            ViewBag.vote = voteList;
            ViewBag.winningCandidate = winningCandi.Name;

            return View();
        }

        public ActionResult VicePresidentPieGraph()
        {

            var nameList = (from names in db.VicePresidents
                            where names.Name != ""
                            select names.Name).ToArray();

            var voteList = (from vote in db.VicePresidents
                            select vote.TotalVote).ToArray();

            var winningCandi = db.VicePresidents
                                .OrderByDescending(e => e.TotalVote)
                                .First();

            ViewBag.name = nameList;
            ViewBag.vote = voteList;
            ViewBag.winningCandidate = winningCandi.Name;

            return View();
        }

        public ActionResult VicePresidentBarGraph()
        {

            var nameList = (from names in db.VicePresidents
                            where names.Name != ""
                            select names.Name).ToArray();

            var voteList = (from vote in db.VicePresidents
                            select vote.TotalVote).ToArray();

            var winningCandi = db.VicePresidents
                                .OrderByDescending(e => e.TotalVote)
                                .First();

            ViewBag.name = nameList;
            ViewBag.vote = voteList;
            ViewBag.winningCandidate = winningCandi.Name;

            return View();
        }
    }
}