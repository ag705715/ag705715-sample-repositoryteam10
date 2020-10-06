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
    public class FlightTracksController : Controller
    {
        private MIS4200AndrewGolikContext db = new MIS4200AndrewGolikContext();

        // GET: FlightTracks
        public ActionResult Index()
        {
            var flightTracks = db.flightTracks.Include(f => f.flight);
            return View(flightTracks.ToList());
        }

        // GET: FlightTracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightTrack flightTrack = db.flightTracks.Find(id);
            if (flightTrack == null)
            {
                return HttpNotFound();
            }
            return View(flightTrack);
        }

        // GET: FlightTracks/Create
        public ActionResult Create()
        {
            ViewBag.flightID = new SelectList(db.flights, "flightID", "departingAirport");
            return View();
        }

        // POST: FlightTracks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "flightTrackID,price,ticketID,flightID")] FlightTrack flightTrack)
        {
            if (ModelState.IsValid)
            {
                db.flightTracks.Add(flightTrack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.flightID = new SelectList(db.flights, "flightID", "departingAirport", flightTrack.flightID);
            return View(flightTrack);
        }

        // GET: FlightTracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightTrack flightTrack = db.flightTracks.Find(id);
            if (flightTrack == null)
            {
                return HttpNotFound();
            }
            ViewBag.flightID = new SelectList(db.flights, "flightID", "departingAirport", flightTrack.flightID);
            return View(flightTrack);
        }

        // POST: FlightTracks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "flightTrackID,price,ticketID,flightID")] FlightTrack flightTrack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flightTrack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.flightID = new SelectList(db.flights, "flightID", "departingAirport", flightTrack.flightID);
            return View(flightTrack);
        }

        // GET: FlightTracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightTrack flightTrack = db.flightTracks.Find(id);
            if (flightTrack == null)
            {
                return HttpNotFound();
            }
            return View(flightTrack);
        }

        // POST: FlightTracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlightTrack flightTrack = db.flightTracks.Find(id);
            db.flightTracks.Remove(flightTrack);
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
