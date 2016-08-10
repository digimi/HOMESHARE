using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace HomeShare.Controllers
{
    public class ResidencesController : Controller
    {
        private HSEntities db = new HSEntities();

        // GET: Residences
        public async Task<ActionResult> Index()
        {
            var residences = db.Residences.Include(r => r.Pictures).Include(r => r.Pay).Include(r=>r.Member);
            return View(await residences.ToListAsync());
        }

        // GET: Residences/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residence residence = await db.Residences.FindAsync(id);
            if (residence == null)
            {
                return HttpNotFound();
            }
            return View(residence);
        }

        // GET: Residences/Create
        public ActionResult Create()
        {
            ViewBag.MemberID = new SelectList(db.Members, "ID", "Login");
            ViewBag.PaysID = new SelectList(db.Pays, "ID", "Name");
            return View();
        }

        // POST: Residences/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Title,Short_Desc,Long_Desc,Street,Number,Zip,City,Capacity,Unactive,UnactiveOn,ScheduleDelete,Deleted,PaysID,MemberID")] Residence residence)
        {
            if (ModelState.IsValid)
            {
                db.Residences.Add(residence);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MemberID = new SelectList(db.Members, "ID", "Login", residence.MemberID);
            ViewBag.PaysID = new SelectList(db.Pays, "ID", "Name", residence.PaysID);
            return View(residence);
        }

        // GET: Residences/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residence residence = await db.Residences.FindAsync(id);
            if (residence == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.Members, "ID", "Login", residence.MemberID);
            ViewBag.PaysID = new SelectList(db.Pays, "ID", "Name", residence.PaysID);
            return View(residence);
        }

        // POST: Residences/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Title,Short_Desc,Long_Desc,Street,Number,Zip,City,Capacity,Unactive,UnactiveOn,ScheduleDelete,Deleted,PaysID,MemberID")] Residence residence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(residence).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MemberID = new SelectList(db.Members, "ID", "Login", residence.MemberID);
            ViewBag.PaysID = new SelectList(db.Pays, "ID", "Name", residence.PaysID);
            return View(residence);
        }

        // GET: Residences/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residence residence = await db.Residences.FindAsync(id);
            if (residence == null)
            {
                return HttpNotFound();
            }
            return View(residence);
        }

        // POST: Residences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Residence residence = await db.Residences.FindAsync(id);
            db.Residences.Remove(residence);
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
