using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OneToManyList.Models;

namespace OneToManyList.Controllers
{
    public class ContactPersonsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactPersons
        public ActionResult Index()
        {
            var contactPersons = db.ContactPersons.Include(c => c.Company);
            return View(contactPersons.ToList());
        }

        // GET: ContactPersons/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPerson contactPerson = db.ContactPersons.Find(id);
            if (contactPerson == null)
            {
                return HttpNotFound();
            }
            return View(contactPerson);
        }

        // GET: ContactPersons/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Title");
            return View();
        }

        // POST: ContactPersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CompanyId")] ContactPerson contactPerson)
        {
            if (ModelState.IsValid)
            {
                contactPerson.Id = Guid.NewGuid();
                db.ContactPersons.Add(contactPerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Title", contactPerson.CompanyId);
            return View(contactPerson);
        }

        // GET: ContactPersons/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPerson contactPerson = db.ContactPersons.Find(id);
            if (contactPerson == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Title", contactPerson.CompanyId);
            return View(contactPerson);
        }

        // POST: ContactPersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CompanyId")] ContactPerson contactPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Title", contactPerson.CompanyId);
            return View(contactPerson);
        }

        // GET: ContactPersons/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPerson contactPerson = db.ContactPersons.Find(id);
            if (contactPerson == null)
            {
                return HttpNotFound();
            }
            return View(contactPerson);
        }

        // POST: ContactPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ContactPerson contactPerson = db.ContactPersons.Find(id);
            db.ContactPersons.Remove(contactPerson);
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
