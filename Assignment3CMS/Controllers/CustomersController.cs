using CustomerBusinessLayer;
using CustomerDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Assignment3CMS.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerDbContext db = new CustomerDbContext();
       
        public ActionResult HomePage()
        {
            return View();
        }
        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }
        // GET: Customers/Details/2
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CustomerName,City,Age,Phone,Pincode")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                ViewBag.Message = "Customer details Added Successfully";
                return RedirectToAction("Create");
            }

            return View(customer);
        }
        // GET: Customers/Edit/2
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CustomerName,City,Age,Phone,Pincode")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search(string Searchby, string search)
        {
            try
            {
                List<Customer> customers = db.Customers.ToList();

                if (Searchby == "CustomerName")
                {


                    List<Customer> model = customers.Where(c => c.CustomerName.StartsWith(search) || search == null).ToList();
                    ModelState.Clear();
                    return View(model);
                }
                else
                {

                    List<Customer> model = customers.Where(c => c.CustomerID == Convert.ToInt32(search) || search == null).ToList();

                    ModelState.Clear();
                    return View(model);
                }
            }
            catch
            {
                return View(search);
            }

        }
    }
}