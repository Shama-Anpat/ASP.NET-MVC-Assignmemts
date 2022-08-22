using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CFAAssignment1.Models;

namespace CFAAssignment1.Controllers
{
    public class FootBallLeagueController : Controller
    {
        FootBallLeagueContext dbContext = new FootBallLeagueContext();
        // GET: FootBallLeague
        public ActionResult Index()
        {
            var data = dbContext.FootBallLeagues.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FootBallLeague fb)
        {
            if (ModelState.IsValid == true)
            {
                dbContext.FootBallLeagues.Add(fb);
                int check = dbContext.SaveChanges();
                if (check > 0)
                {
                    TempData["InsertMessage"]= "<script>alert('Data Inserted Successfully!')</script>";
                    return RedirectToAction("Index");
                    //ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data Not Inserted!')</script>";
                }
                
            }
            return View();
        }
           
    }
}