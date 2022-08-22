using DFAAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DFAAssignment1.Controllers
{
    public class FootBallLeagueController : Controller
    {
        MatchEntities db = new MatchEntities();
        // GET: FootBallLeague
        public ActionResult Index()
        {
            return View(db.FootBallLeagues.ToList());
        }

        public ActionResult WinningMatchList()
        {
            IEnumerable<FootBallLeague> list = db.FootBallLeagues.ToList().Where(result => result.MatchStatus == "Win");
            return View(list);  
        }
        
       
    }
}