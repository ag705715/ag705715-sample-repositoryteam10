using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200AndrewGolik.DAL;
using MIS4200AndrewGolik.Models;

namespace MIS4200AndrewGolik.Controllers
{
    public class PassengersController : Controller
    {
        private MIS4200AndrewGolikContext db = new MIS4200AndrewGolikContext();

        // GET: Passengers
        public ActionResult Index()
        {
            return View(db.passengers.ToList());
        }

        // GET: Passengers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = db.passengers.Find(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }

        // GET: Passengers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "passengerID,firstName,lastName,email,phone")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                db.passengers.Add(passenger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(passenger);
        }

        // GET: Passengers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = db.passengers.Find(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "passengerID,firstName,lastName,email,phone")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passenger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(passenger);
        }

        // GET: Passengers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = db.passengers.Find(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Passenger passenger = db.passengers.Find(id);
            db.passengers.Remove(passenger);
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
