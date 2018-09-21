using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SwinSoftwareLab.Models;

namespace SwinSoftwareLab.Controllers
{
    public class ModulesController : Controller
    {
        private SwinSLEntities db = new SwinSLEntities();

        // GET: Modules
        public async Task<ActionResult> Index()
        {
            var modules = db.Modules.Include(m => m.Student);
            return View(await modules.ToListAsync());
        }

        // GET: Modules/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = await db.Modules.FindAsync(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // GET: Modules/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Students, "ID", "FirstName");
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MacAddress,IssueDate,ID")] Module module)
        {
            if (ModelState.IsValid)
            {
                db.Modules.Add(module);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Students, "ID", "FirstName", module.ID);
            return View(module);
        }

        // GET: Modules/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = await db.Modules.FindAsync(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Students, "ID", "FirstName", module.ID);
            return View(module);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MacAddress,IssueDate,ID")] Module module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(module).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Students, "ID", "FirstName", module.ID);
            return View(module);
        }

        // GET: Modules/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = await db.Modules.FindAsync(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Module module = await db.Modules.FindAsync(id);
            db.Modules.Remove(module);
            await db.SaveChangesAsync();
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
