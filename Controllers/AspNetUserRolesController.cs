using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminUI;

namespace AdminUI.Controllers
{
    public class AspNetUserRolesController : Controller
    {
        private SuymembershipEntities db = new SuymembershipEntities();

        // GET: AspNetUserRoles
        //public ActionResult Index()
        //{
        //    var aspNetUserRoles1 = db.AspNetUserRoles1.Include(a => a.AspNetRole).Include(a => a.AspNetUser);
        //    return View(aspNetUserRoles1.ToList());
        //}

        // GET: AspNetUserRoles/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AspNetUserRole aspNetUserRole = db.AspNetUserRoles1.Find(id);
        //    if (aspNetUserRole == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(aspNetUserRole);
        //}

        // GET: AspNetUserRoles/Create
        //public ActionResult Create()
        //{
        //    ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name");
        //    ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
        //    return View();
        //}

        // POST: AspNetUserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "UserRoleId,UserId,RoleId")] AspNetUserRole aspNetUserRole)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.AspNetUserRoles1.Add(aspNetUserRole);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name", aspNetUserRole.RoleId);
        //    ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserRole.UserId);
        //    return View(aspNetUserRole);
        //}

        // GET: AspNetUserRoles/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AspNetUserRole aspNetUserRole = db.AspNetUserRoles1.Find(id);
        //    if (aspNetUserRole == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name", aspNetUserRole.RoleId);
        //    ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserRole.UserId);
        //    return View(aspNetUserRole);
        //}

        // POST: AspNetUserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "UserRoleId,UserId,RoleId")] AspNetUserRole aspNetUserRole)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(aspNetUserRole).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name", aspNetUserRole.RoleId);
        //    ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserRole.UserId);
        //    return View(aspNetUserRole);
        //}

        // GET: AspNetUserRoles/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AspNetUserRole aspNetUserRole = db.AspNetUserRoles1.Find(id);
        //    if (aspNetUserRole == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(aspNetUserRole);
        //}

        // POST: AspNetUserRoles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    AspNetUserRole aspNetUserRole = db.AspNetUserRoles1.Find(id);
        //    db.AspNetUserRoles1.Remove(aspNetUserRole);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
