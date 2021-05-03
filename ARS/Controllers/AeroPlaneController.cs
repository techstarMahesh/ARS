using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ARS.Models;
using ARS.Controllers;

namespace ARS.Controllers
{
    public class AeroPlaneController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: AeroPlane
        public ActionResult Index()
        {
            return View(db.PlaneInfo.ToList());
        }

        // GET: AeroPlane/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AeroPlaneInfo aeroPlaneInfo = db.PlaneInfo.Find(id);
            if (aeroPlaneInfo == null)
            {
                return HttpNotFound();
            }
            return View(aeroPlaneInfo);
        }

        // GET: AeroPlane/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AeroPlane/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaneId,planeName,SeatingCapacity,Price")] AeroPlaneInfo aeroPlaneInfo)
        {
            if (ModelState.IsValid)
            {
                db.PlaneInfo.Add(aeroPlaneInfo);
                db.SaveChanges();
                ViewBag.PlaneCreated = "Record Added";
                return View();
                //return RedirectToAction("Index");
            }

            return View(aeroPlaneInfo);
        }

        // GET: AeroPlane/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AeroPlaneInfo aeroPlaneInfo = db.PlaneInfo.Find(id);
            if (aeroPlaneInfo == null)
            {
                return HttpNotFound();
            }
            return View(aeroPlaneInfo);
        }

        // POST: AeroPlane/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaneId,planeName,SeatingCapacity,Price")] AeroPlaneInfo aeroPlaneInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aeroPlaneInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aeroPlaneInfo);
        }

        // GET: AeroPlane/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AeroPlaneInfo aeroPlaneInfo = db.PlaneInfo.Find(id);
            if (aeroPlaneInfo == null)
            {
                return HttpNotFound();
            }
            return View(aeroPlaneInfo);
        }

        // POST: AeroPlane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AeroPlaneInfo aeroPlaneInfo = db.PlaneInfo.Find(id);
            db.PlaneInfo.Remove(aeroPlaneInfo);
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
