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
            if (Session["admin"] != null)
            {
                var ticketReservation_tbl = db.TicketReservation_tbl.Include(t => t.Plane_tbls);
                return View(ticketReservation_tbl.ToList());
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }

        // GET: TicketReservation/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["admin"] != null)
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
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }

        // GET: TicketReservation/Create
        public ActionResult Create()
        {
            if (Session["admin"] != null)
            {
                ViewBag.PlaneID = new SelectList(db.PlaneInfo, "PlaneId", "planeName");
                return View();
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }

        // POST: TicketReservation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResId,RestFrom,RestTo,RestDepDate,RestTime,PlaneID,PlaneSeats,ResTicketPrice,ResPlaneType")] TicketReservation_tbl ticketReservation_tbl)
        {
            if (Session["admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.TicketReservation_tbl.Add(ticketReservation_tbl);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.PlaneID = new SelectList(db.PlaneInfo, "PlaneId", "planeName", ticketReservation_tbl.PlaneID);
                return View(ticketReservation_tbl);
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }

        // GET: TicketReservation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["admin"] != null)
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
                ViewBag.PlaneID = new SelectList(db.PlaneInfo, "PlaneId", "planeName", ticketReservation_tbl.PlaneID);
                return View(ticketReservation_tbl);
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }

        // POST: TicketReservation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResId,RestFrom,RestTo,RestDepDate,RestTime,PlaneID,PlaneSeats,ResTicketPrice,ResPlaneType")] TicketReservation_tbl ticketReservation_tbl)
        {
            if (Session["admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ticketReservation_tbl).State = EntityState.Modified;
                    db.SaveChanges();
                    return View();
                }
                ViewBag.PlaneID = new SelectList(db.PlaneInfo, "PlaneId", "planeName", ticketReservation_tbl.PlaneID);
                return View(ticketReservation_tbl);
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }

        // GET: TicketReservation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["admin"] != null)
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
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }

        // POST: TicketReservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["admin"] != null)
            {
                TicketReservation_tbl ticketReservation_tbl = db.TicketReservation_tbl.Find(id);
                db.TicketReservation_tbl.Remove(ticketReservation_tbl);
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
