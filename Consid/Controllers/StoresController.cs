using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Consid;
using Consid.Models;
using GuigleAPI;
using GuigleAPI.Model;

namespace Consid.Controllers
{
    public class StoresController : Controller
    {
        private Model1 db = new Model1();

        // GET: Stores
        public ActionResult Index()
        {
            var stores = db.Stores.Include(s => s.Companies);
            return View(stores.ToList());
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stores stores = db.Stores.Find(id);
            if (stores == null)
            {
                return HttpNotFound();
            }
            return View(stores);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name");
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyId,Name,Adress,City,Zip,Country,Longitude,Latitude")] Stores stores)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(stores);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", stores.CompanyId);
            return View(stores);
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stores stores = db.Stores.Find(id);
            if (stores == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", stores.CompanyId);
            return View(stores);
        }

        // POST: Stores/Edit/5
        //Has this wierd functionality that updates lat, long when updating :D
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CompanyId,Name,Adress,City,Zip,Country,Longitude,Latitude")] Stores stores)
        {
            if (ModelState.IsValid)
            {              
                var latlng = await geoCode(stores.Adress + ", " + stores.City + ", " + stores.Country);
                stores.Latitude = latlng.Item1.ToString();
                stores.Longitude = latlng.Item2.ToString();
                db.Entry(stores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", stores.CompanyId);
            return View(stores);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stores stores = db.Stores.Find(id);
            if (stores == null)
            {
                return HttpNotFound();
            }
            return View(stores);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stores stores = db.Stores.Find(id);
            db.Stores.Remove(stores);
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

        //Takes and address and gives back lat,lng as result 
        //lat = result.Item1, lng = result.Item2
        public async Task<Tuple<double, double>> geoCode(string address)
        {
            GoogleGeocodingAPI.GoogleAPIKey = " AIzaSyBHnO1TC2wWkYXssMdJhwdJt3jUia9bpyY ";
            Tuple<double, double> result = await GoogleGeocodingAPI.GetCoordinatesFromAddressAsync(address);
            return result;
        }
    }
}
