using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FortuneTellerMVC.Models;

namespace FortuneTellerMVC.Controllers
{
    public class CustomersController : Controller
    {
        private FortuneTellerMVCEntities db = new FortuneTellerMVCEntities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
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
            if (customer.Age % 2 == 0) // if age is even number...
            {
                ViewBag.RetirementAge = 75; // ...retire in 20 years
            }
            else // if age is odd number...
            {
                ViewBag.RetirementAge = 80; // ...retire in 35 years
            }
            if (customer.NumberOfSiblings == 0m)
            {
                ViewBag.VacationHome = "Paris";
            }
            else if (customer.NumberOfSiblings == 1m)
            {
                ViewBag.VacationHome = "Tuscany";
            }
            else if (customer.NumberOfSiblings == 2m)
            {
                ViewBag.VacationHome = "Hawaii";
            }
            else if (customer.NumberOfSiblings == 3m)
            {
                ViewBag.VacationHome = "Alaska";
            }
            else if (customer.NumberOfSiblings > 3m)
            {
                ViewBag.VacationHome = "Cleveland";
            }
            else if (customer.NumberOfSiblings < 0m)
            {
                ViewBag.VacationHome = "a cardboard box"; // if user entered negative number, they get a bad vacation home
            }

            switch (customer.FavoriteColor.ToLower())
            {
                case "red":
                    ViewBag.Transportation = "Mercedes-Benz";
                    break;
                case "orange":
                    ViewBag.Transportation = "mini van";
                    break;
                case "yellow":
                    ViewBag.Transportation = "luxury yacht";
                    break;
                case "green":
                    ViewBag.Transportation = "private jet";
                    break;
                case "blue":
                    ViewBag.Transportation = "Jeep Wrangler";
                    break;
                case "indigo":
                    ViewBag.Transportation = "tricycle";
                    break;
                case "violet":
                    ViewBag.Transportation = "hoverboard";
                    break;
            }
            if (customer.BirthMonth == "January")
            {
                ViewBag.Money = "$1,000,000";
            }
            else if (customer.BirthMonth == "February")
            {
                ViewBag.Money = "$1,000,000";
            }
            else if (customer.BirthMonth == "March")
            {
                ViewBag.Money = "$1,000,000";
            }
            else if (customer.BirthMonth == "April")
            {
                ViewBag.Money = "$1,000,000";
            }
            else if (customer.BirthMonth == "May")
            {
                ViewBag.Money = "$5,000,000";
            }
            else if (customer.BirthMonth == "June")
            {
                ViewBag.Money = "$5,000,000";
            }
            else if (customer.BirthMonth == "July")
            {
                ViewBag.Money = "$5,000,000";
            }
            else if (customer.BirthMonth == "August")
            {
                ViewBag.Money = "$5,000,000";
            }
            else if (customer.BirthMonth == "Septemeber")
            {
                ViewBag.Money = "$20,000,000";
            }
            else if (customer.BirthMonth == "October")
            {
                ViewBag.Money = "$20,000,000";
            }
            else if (customer.BirthMonth == "November")
            {
                ViewBag.Money = "$20,000,000";
            }
            else if (customer.BirthMonth == "December")
            {
                ViewBag.Money = "$20,000,000";
            }
            else
            {
                ViewBag.Money = "$0.00";
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
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

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
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
