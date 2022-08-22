using DFAAssignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DFAAssignment2.Controllers
{
    public class BusInfoController : Controller
    {
        DatabaseFirstEntities db = new DatabaseFirstEntities();
        // GET: BusInfo
        public ActionResult Index()
        {
            return View(db.BusInfoms.ToList());
        }
        public ActionResult BoardingPointasMumbaiList()
        {
            IEnumerable<BusInfom> list = db.BusInfoms.ToList().Where(result => result.BoardingPoint == "MUM");
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BusInfom bi)
        {
            if (ModelState.IsValid == true)
            {
                //db.BusInfoms.Add(bi);  //data will be inserted into DBset
                db.spInsertData(bi.BoardingPoint,bi.TravelDate,bi.Amount,bi.Rating);
                int check = db.SaveChanges();
                if (check > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Data Added Successfully!')</script>";
                    return RedirectToAction("Index");
                    //ModelState.Clear();
                }
                else
                {
                    TempData["InsertMessage"] = "Data not Inserted!";

                }
            }

            return View();
        }
       
    }
}