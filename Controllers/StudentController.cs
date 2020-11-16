using MSConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSConsumer.Controllers
{
    public class StudentController : Controller
    {
        ServiceClient serviceClient = new ServiceClient();

        // GET: Student
        public ActionResult Index(string sortOrder, string search, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            /*            ViewBag.listLocation = servicesClient.getAllLocations();
            */
            if (search != null)
            {
                page = 1; // nếu search có giá trị trả về page = 1
            }
            else
            {
                search = currentFilter; //  nếu có thì render phần dữ liệu search ra
            }
            ViewBag.CurrentFilter = search;
            var students = from s in serviceClient.GetStudents() select s;
            if (!String.IsNullOrEmpty(search)) // check nếu search string có thì in ra hoặc không thì không in ra
            {
                students = students.Where(s => s.Name.Contains(search) || s.Phone.Contains(search)); // contains là để check xem lastname hoặc firstName có chứa search string ở trên 
            }
            switch (sortOrder)
            {
                case "name desc":
                    students = students.OrderByDescending(s => s.Name); // các case tương đương với các cột muốn sort
                    break;

                default:
                    students = students.OrderBy(s => s.Phone);
                    break;
            }

            return View(students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var student = serviceClient.GetStudents().Where(b => b.ID == id).FirstOrDefault();
            return View(student);
        }

        // GET: Location/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student newStudent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    serviceClient.CreateStudent(newStudent);
                    return RedirectToAction("Index", "Student");
                }

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            var location = serviceClient.GetStudents().Where(b => b.ID == id).FirstOrDefault();
            return View(location);
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(Student newStudent)
        {
            try
            {
                serviceClient.EditStudent(newStudent);
                // TODO: Add update logic here

                return RedirectToAction("Index", "Student");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(string id)
        {
            serviceClient.DeleteStudent(id);
            return View();
        }

        // POST: Location/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
