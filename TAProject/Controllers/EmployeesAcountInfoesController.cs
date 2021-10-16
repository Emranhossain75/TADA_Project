using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TAProject.Models;

namespace TAProject.Controllers
{
    public class EmployeesAcountInfoesController : Controller
    {
        private EmployeeInformationEntities db = new EmployeeInformationEntities();

        // GET: EmployeesAcountInfoes
        public ActionResult Index()
        {
            return View(db.PersonsAcountInfoes.ToList());
        }

        // GET: EmployeesAcountInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonsAcountInfo personsAcountInfo = db.PersonsAcountInfoes.Find(id);
            if (personsAcountInfo == null)
            {
                return HttpNotFound();
            }
            return View(personsAcountInfo);
        }

        // GET: EmployeesAcountInfoes/Create
        public ActionResult Create()
        {
            var list = new List<string>() { "Sumit", "Raihan", "Rashed", "Farhad" };
            ViewBag.list = list;
            var paidUnpaid = new List<string>() { "Paid", "Unpaid"};
            ViewBag.list1 = paidUnpaid;
            return View();
        }

        // POST: EmployeesAcountInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,EmployeeName,TravelCost,LunchCost,InstrumentsCost,TotalCost,Paid")] PersonsAcountInfo personsAcountInfo)
        {
            
            if (ModelState.IsValid)
            {
               
                var abc = (personsAcountInfo.TravelCost + personsAcountInfo.LunchCost + personsAcountInfo.InstrumentsCost);

                PersonsAcountInfo ab = new PersonsAcountInfo();
                ab.ID = personsAcountInfo.ID;
                ab.InstrumentsCost = personsAcountInfo.InstrumentsCost; ;
                ab.LunchCost = personsAcountInfo.LunchCost;
                ab.Date = personsAcountInfo.Date;
                ab.EmployeeName = personsAcountInfo.EmployeeName;
                ab.TotalCost = abc;
                ab.Paid = personsAcountInfo.Paid;
                ab.TravelCost = personsAcountInfo.TravelCost;
                db.PersonsAcountInfoes.Add(ab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personsAcountInfo);
        }

        // GET: EmployeesAcountInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonsAcountInfo personsAcountInfo = db.PersonsAcountInfoes.Find(id);
            if (personsAcountInfo == null)
            {
                return HttpNotFound();
            }
            return View(personsAcountInfo);
        }

        // POST: EmployeesAcountInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeName,TravelCost,LunchCost,InstrumentsCost,TotalCost,Paid")] PersonsAcountInfo personsAcountInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personsAcountInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personsAcountInfo);
        }

        // GET: EmployeesAcountInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonsAcountInfo personsAcountInfo = db.PersonsAcountInfoes.Find(id);
            if (personsAcountInfo == null)
            {
                return HttpNotFound();
            }
            return View(personsAcountInfo);
        }

        // POST: EmployeesAcountInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonsAcountInfo personsAcountInfo = db.PersonsAcountInfoes.Find(id);
            db.PersonsAcountInfoes.Remove(personsAcountInfo);
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
