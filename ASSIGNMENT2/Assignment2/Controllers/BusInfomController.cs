using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class BusInfomController : Controller
    {
        // GET: BusInfom
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult create(BusInfom busdetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BusInfomDB busInfoDB = new BusInfomDB();
                    if (busInfoDB.Insertbusinfo(busdetails))
                    {
                        ViewBag.Message = "Bus Details Added Successfully";
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
        public ActionResult BusDetails()
        {
            BusInfomDB busInfo = new BusInfomDB();
            ModelState.Clear();
            return View(busInfo.businfos());
        }
        public ActionResult BusDetailsbyAmount()
        {
            BusInfomDB busInfo = new BusInfomDB();
            ModelState.Clear();
            return View(busInfo.businfosbyamount());
        }
        public ActionResult BusDetailsbyRating()
        {
            BusInfomDB busInfo = new BusInfomDB();
            ModelState.Clear();
            return View(busInfo.businfosbyrating());
        }
        public ActionResult BusDetailsbydate()
        {
            BusInfomDB busInfo = new BusInfomDB();
            ModelState.Clear();
            return View(busInfo.businfosbydate());
        }
        public ActionResult BusDetailsbyboardingpoint()
        {
            BusInfomDB busInfo = new BusInfomDB();
            ModelState.Clear();
            return View(busInfo.businfosbyboardingpoint());
        }
    }
}