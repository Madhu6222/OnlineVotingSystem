﻿using OnlineVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineVotingSystem.Controllers
{
    public class HomeController : Controller
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

        public ActionResult Graphs()
        {

            var nameList = (from names in db.Presidents
                        where names.Name != ""
                        select names.Name).ToArray();

            var voteList = (from vote in db.Presidents
                            select vote.TotalVote).ToArray();

            ViewBag.name = nameList;
            ViewBag.vote = voteList;

            return View();
        }

    }
}