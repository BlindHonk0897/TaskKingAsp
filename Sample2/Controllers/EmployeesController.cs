using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sample2.Models;

namespace Sample2.Controllers
{
    public class EmployeesController : Controller
    {
        private HRMSDBEntities db = new HRMSDBEntities();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            var viewModel = new EmployeeViewModel()
            {
                Employee = new Employee(),
                MiddleGenerators = db.MiddleGenerators.ToList()

            };
            return View(viewModel);
        }

        // GET: Employees/Create
        public ActionResult Current()
        {
            var viewModel = new EmployeeViewModel()
            {
                Employee = new Employee(),
                MiddleGenerators = db.MiddleGenerators.ToList()

            };
            return View(viewModel);
        }

        public ActionResult Normal()
        {
            var viewModel = new EmployeeViewModel()
            {
                Employee = new Employee(),
                MiddleGenerators = db.MiddleGenerators.ToList()

            };
            return View(viewModel);
        }

        public ActionResult Violation()
        {
            var viewModel = new EmployeeViewModel()
            {
                Employee = new Employee(),
                MiddleGenerators = db.MiddleGenerators.ToList()

            };
            return View(viewModel);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Type")] Employee employee)
        {
            string mid = Request.Form["MiddleInitial"].ToString();
            if (ModelState.IsValid)
            {
                employee.MiddleInitial = mid;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var viewModel = new EmployeeViewModel()
            {
                Employee = employee,
                MiddleGenerators = db.MiddleGenerators.ToList()

            };
            return View(viewModel);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            var viewModel = new EmployeeViewModel()
            {
                Employee = employee,
                MiddleGenerators = db.MiddleGenerators.ToList()

            };
            return View(viewModel);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Type")] Employee employee)
        {
            string mid = Request.Form["MiddleInitial"].ToString();
            if (ModelState.IsValid)
            {
                employee.MiddleInitial = mid;
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var viewModel = new EmployeeViewModel()
            {
                Employee = employee,
                MiddleGenerators = db.MiddleGenerators.ToList()

            };
            return View(viewModel);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
        public FileResult DownloadExele()
        {
            string path = "/File/Dan.xlsx";
            return File(path, "application/vnd.ms-excel", "DanFile.xlsx");
        }
    }
}
