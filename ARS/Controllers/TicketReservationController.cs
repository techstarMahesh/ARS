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
    public class TicketReservationController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: TicketReservation
        public ActionResult Index()
        {
            return View(db.TicketReservation_tbl.ToList());
        }

        // GET: TicketReservation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketReservation_tbl ticketReservation_tbl = db.TicketReservation_tbl.Find(id);
            if (ticketReservation_tbl == null)
            {
                return HttpNotFound();
            }
            return View(ticketReservation_tbl);
        }

        // GET: TicketReservation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketReservation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResId,RestFrom,RestTo,RestDepDate,RestTime,PlaneID,Plane_tbls,PlaneSeats,ResTicketPrice,ResPlaneType")] TicketReservation_tbl ticketReservation_tbl)
        {
            if (ModelState.IsValid)
            {
                db.TicketReservation_tbl.Add(ticketReservation_tbl);
                db.SaveChanges();
                ViewBag.Created = "Record Created";
                return View();
                //return RedirectToAction("Index");
            }

            return View(ticketReservation_tbl);
        }

        // GET: TicketReservation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketReservation_tbl ticketReservation_tbl = db.TicketReservation_tbl.Find(id);
            if (ticketReservation_tbl == null)
            {
                return HttpNotFound();
            }
            return View(ticketReservation_tbl);
        }

        // POST: TicketReservation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResId,RestFrom,RestTo,RestDepDate,RestTime,PlaneID,Plane_tbls,PlaneSeats,ResTicketPrice,ResPlaneType")] TicketReservation_tbl ticketReservation_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketReservation_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticketReservation_tbl);
        }

        // GET: TicketReservation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketReservation_tbl ticketReservation_tbl = db.TicketReservation_tbl.Find(id);
            if (ticketReservation_tbl == null)
            {
                return HttpNotFound();
            }
            return View(ticketReservation_tbl);
        }

        // POST: TicketReservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketReservation_tbl ticketReservation_tbl = db.TicketReservation_tbl.Find(id);
            db.TicketReservation_tbl.Remove(ticketReservation_tbl);
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
