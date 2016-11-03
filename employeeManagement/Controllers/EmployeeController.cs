using employeeManagement.Models.ServiceConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using viewModels.employeeManagement;

namespace employeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        
        // GET: Employee
        public ActionResult Index()
        {
            IList<EmployeeViewModel> employeeVms = null;
            try
            {
                employeeVms = new RestSharpServiceConsumer<EmployeeViewModel>("api/employee/getAllEmployees").GetAll();
                SetupSearhForm();
                ViewBag.SearchResultOrAll("All the employees");
            }
            catch (Exception ex)
            {
                // logging
                //throw;
            }

            return View(employeeVms);
        }

        // helper method to setup search form
        private void SetupSearhForm()
        {
            // search form elements
            ViewBag.DepartmentSelectListItems = new[] {
                    new SelectListItem { Value = "1", Text = "Engineering" },
                    new SelectListItem { Value = "2", Text = "Marketting" },
                    new SelectListItem { Value = "3", Text = "Finance" },
                    new SelectListItem { Value = "4", Text = "Business" }
                };
            ViewBag.PermenentSelectListItems = new[] {
                    new SelectListItem { Value = "Y" , Text = "Yes"},
                    new SelectListItem { Value = "N" , Text = "No"}
                };
        }

        [HttpPost]
        public ActionResult Index(int employeeId, string firstName, string lastName, decimal salary, int departmentId, string PermanentChar)
        {
            IList<EmployeeViewModel> employeeVms = null;
            try
            {
                EmployeeViewModel employeeVm = new EmployeeViewModel()
                {
                    EmployeeId = employeeId,
                    Firstname = firstName,
                    Lastname = lastName,
                    Salary = salary,
                    DepartmentId = departmentId,
                    PermanentChar = PermanentChar
                };
                employeeVms = new RestSharpServiceConsumer<EmployeeViewModel>("api/employee/searchEmployees").Search(employeeVm);
                SetupSearhForm();
                ViewBag.SearchResultOrAll = "Search results : ";
            }
            catch (Exception ex)
            {
                // logging
                //throw;
            }

            return View(employeeVms);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            EmployeeViewModel employeeVm = null;
            try
            {
                employeeVm = new RestSharpServiceConsumer<EmployeeViewModel>(string.Format("api/employee/getEmployeeById?id={0}", id)).GetById();
            }
            catch (Exception ex)
            {
                // logging
                //throw;
            }
            return View(employeeVm);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            EmployeeViewModel employeeVm = null;
            try
            {
                employeeVm = new EmployeeViewModel();
                SetupEmployeeVmWithUiControls(employeeVm);
            }
            catch (Exception ex)
            {
                // logging
                //throw;
            }
            return View(employeeVm);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel employeeVm)
        {
            try
            {
                // TODO: Add insert logic here                
                bool isEmployeeCreated = new RestSharpServiceConsumer<EmployeeViewModel>("api/employee/putEmployee").Insert(employeeVm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeViewModel employeeVm = null;
            try
            {
                employeeVm = new RestSharpServiceConsumer<EmployeeViewModel>(string.Format("api/employee/getEmployeeById?id={0}", id)).GetById();
                SetupEmployeeVmWithUiControls(employeeVm);
            }
            catch (Exception ex)
            {
                // logging
                //throw;
            }
            return View(employeeVm);
        }

        // helper to add UI controls to the employee view model 
        private static void SetupEmployeeVmWithUiControls(EmployeeViewModel employeeVm)
        {
            employeeVm.DepartmentSelectListItems = new[] {
                    new SelectListItem { Value = "1", Text = "Engineering" },
                    new SelectListItem { Value = "2", Text = "Marketting" },
                    new SelectListItem { Value = "3", Text = "Finance" },
                    new SelectListItem { Value = "4", Text = "Business" }
                };
            employeeVm.PermenentSelectListItems = new[] {
                    new SelectListItem { Value = "Y" , Text = "Yes"},
                    new SelectListItem { Value = "N" , Text = "No"}
                };
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeViewModel employeeVm)
        {
            try
            {
                // TODO: Add update logic here
                bool isEmployeeEdited = new RestSharpServiceConsumer<EmployeeViewModel>("api/employee/postEmployee").Update(employeeVm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeViewModel employeeVm = null;
            try
            {
                employeeVm = new RestSharpServiceConsumer<EmployeeViewModel>(string.Format("api/employee/getEmployeeById?id={0}", id)).GetById();                
            }
            catch (Exception ex)
            {
                // logging
                //throw;
            }
            return View(employeeVm);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeViewModel employeeViewModel)
        {
            try
            {
                // TODO: Add delete logic here
                bool isEmployeeDeleted = new RestSharpServiceConsumer<EmployeeViewModel>(string.Format("api/employee/deleteEmployee?id={0}", id)).Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
