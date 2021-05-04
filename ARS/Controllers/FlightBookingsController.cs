using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ARS.Models;

namespace ARS.Controllers
{
    public class FlightBookingsController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: FlightBookings
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                var flightsBookings = db.FlightsBookings.Include(f => f.TicketResevation_tbls);
                return View(flightsBookings.ToList());
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }

        // GET: FlightBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                FlightBooking flightBooking = db.FlightsBookings.Find(id);
                if (flightBooking == null)
                {
                    return HttpNotFound();
                }
                return View(flightBooking);
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }

        // GET: FlightBookings/Create
        public ActionResult Create()
        {
            if (Session["admin"] != null)
            {
                ViewBag.ResId = new SelectList(db.TicketReservation_tbl, "ResId", "RestFrom");
                return View();
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }

        // POST: FlightBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bId,bCusName,To,bCusEmail,bCusSeats,bCusPhone,bCusCnic,ResId")] FlightBooking flightBooking)
        {
            if (Session["admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.FlightsBookings.Add(flightBooking);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ResId = new SelectList(db.TicketReservation_tbl, "ResId", "RestFrom", flightBooking.ResId);
                return View(flightBooking);
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }

        // GET: FlightBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                FlightBooking flightBooking = db.FlightsBookings.Find(id);
                if (flightBooking == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ResId = new SelectList(db.TicketReservation_tbl, "ResId", "RestFrom", flightBooking.ResId);
                return View(flightBooking);
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }

        // POST: FlightBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bId,bCusName,To,bCusEmail,bCusSeats,bCusPhone,bCusCnic,ResId")] FlightBooking flightBooking)
        {
            if (Session["admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(flightBooking).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ResId = new SelectList(db.TicketReservation_tbl, "ResId", "RestFrom", flightBooking.ResId);
                return View(flightBooking);
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }

        // GET: FlightBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                FlightBooking flightBooking = db.FlightsBookings.Find(id);
                if (flightBooking == null)
                {
                    return HttpNotFound();
                }
                return View(flightBooking);
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }

        // POST: FlightBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["admin"] != null)
            {
                FlightBooking flightBooking = db.FlightsBookings.Find(id);
                db.FlightsBookings.Remove(flightBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
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
