using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class MatchDetailsController : Controller
    {
        // GET: MatchDetails
        public ActionResult details()
        {
            MatchDB matchDB = new MatchDB();
            ModelState.Clear();
            return View(matchDB.GetMatchDetails());
        }
        public ActionResult winningmatchdetails()
        {
            MatchDB matchDB = new MatchDB();
            ModelState.Clear();
            return View(matchDB.WinningTeamDetails());
        }

        public ActionResult japanmatchdetails()
        {
            MatchDB matchDB = new MatchDB();
            ModelState.Clear();
            return View(matchDB.JapanMatchDetails());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FootBallLeague Match)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MatchDB matchDB = new MatchDB();
                    if (matchDB.AddMatchDetails(Match))
                    {
                        ViewBag.Message = "Match Details Added Successfully";
                        ModelState.Clear();
                    }

                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}