using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private readonly InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View(new Insuree());
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                // Base monthly cost
                decimal monthlyQuote = 50;

                // Age-based calculation
                var age = DateTime.Now.Year - insuree.DateOfBirth.Year;
                if (insuree.DateOfBirth > DateTime.Now.AddYears(-age)) age--; // Ajuste si aún no ha cumplido años este año

                if (age <= 18)
                {
                    monthlyQuote += 100;
                }
                else if (age >= 19 && age <= 25)
                {
                    monthlyQuote += 50;
                }
                else if (age >= 26)
                {
                    monthlyQuote += 25;
                }

                // Car year-based calculation
                if (insuree.CarYear < 2000)
                {
                    monthlyQuote += 25;
                }
                else if (insuree.CarYear > 2015)
                {
                    monthlyQuote += 25;
                }

                // Car make and model calculation
                if (insuree.CarMake.ToLower() == "porsche")
                {
                    monthlyQuote += 25;
                    if (insuree.CarModel.ToLower() == "911 carrera")
                    {
                        monthlyQuote += 25; // Costo adicional por ser Porsche 911 Carrera
                    }
                }

                // Speeding tickets calculation
                monthlyQuote += insuree.SpeedingTickets * 10;

                // DUI check (Driving Under Influence)
                if (insuree.DUI)
                {
                    monthlyQuote *= 1.25m; // Agrega 25%
                }

                // Coverage type calculation 
                if (insuree.CoverageType)
                {
                    monthlyQuote *= 1.50m; 
                }

                
                insuree.Quote = monthlyQuote;

                // Guarda en la base de datos
                db.Insurees.Add(insuree);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                System.Diagnostics.Debug.WriteLine(error.ErrorMessage); // Esto imprimirá los errores en la ventana de salida de Visual Studio
            }

            return View(insuree); // Retorna la vista si hay errores para que el usuario vea los mensajes de validación
        }

           
        


        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
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
        public ActionResult Admin()
        {
            var insurees = db.Insurees.ToList();
            return View(insurees);
        }
    }
}
