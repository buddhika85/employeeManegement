using dataAccess_EF.EF;
using genericRepositoryUnitOfWork.Repository;
using genericRepositoryUnitOfWork.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Web.Http;
using viewModels.employeeManagement;

namespace api.employeeManagement.Controllers
{
    public class EmployeeController : ApiController
    {
        UnitOfWork unitOfWork = null;
        GenericRepository<TBL_EMPLOYEE> employeeRepository = null;
        ViewModelConvertor viewModelConvertor = null;

        public EmployeeController()
        {
            unitOfWork = new UnitOfWork();
            employeeRepository = unitOfWork.EmployeeRepository;
            viewModelConvertor = new ViewModelConvertor();
        }

        // Get all
        [HttpGet]
        [Route("api/employee/getAllEmployees")]
        public IList<EmployeeViewModel> GetAll()
        {
            IList<EmployeeViewModel> employeeVms = null;
            try
            {
                IEnumerable<TBL_EMPLOYEE> employees = employeeRepository.GetAll();
                employeeVms = new List<EmployeeViewModel>();
                foreach (TBL_EMPLOYEE item in employees)
                {
                    employeeVms.Add(viewModelConvertor.GetEmployeeViewModel(item));
                }
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
            return employeeVms;
        }

        // Get by Id
        [HttpGet]
        [Route("api/employee/getEmployeeById")]
        public EmployeeViewModel GetById(int id)
        {
            EmployeeViewModel employeeVm = null;
            try
            {
                TBL_EMPLOYEE employee = employeeRepository.GetByPrimaryKey(id);                
                employeeVm = viewModelConvertor.GetEmployeeViewModel(employee);                
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
            return employeeVm;
        }

        // Insert
        [HttpPut]
        [Route("api/employee/putEmployee")]
        public bool Insert(EmployeeViewModel viewModel)
        {
            bool isInserted = false;
            try
            {
                TBL_EMPLOYEE employee = viewModelConvertor.GetTblEmployee(viewModel);
                employee = employeeRepository.Insert(employee);
                if (employee != null)
                {
                    unitOfWork.SaveChanges();
                    isInserted = true;
                }
                else
                {
                    isInserted = false;
                }
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
            return isInserted;
        }

        // Update
        [HttpPost]
        [Route("api/employee/postEmployee")]
        public bool Update(EmployeeViewModel viewModel)
        {
            bool isUpdated = false;
            try
            {
                TBL_EMPLOYEE employee = viewModelConvertor.GetTblEmployee(viewModel);
                employee = employeeRepository.Update(employee);
                if (employee != null)
                {
                    unitOfWork.SaveChanges();
                    isUpdated = true;
                }
                else
                {
                    isUpdated = false;
                }
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
            return isUpdated;
        }

        // Delete
        [HttpDelete]
        [Route("api/employee/deleteEmployee")]
        public bool Delete(int id)
        {
            bool isDeleted = false;
            try
            {                
                TBL_EMPLOYEE employee = employeeRepository.Delete(id);
                if (employee != null)
                {
                    unitOfWork.SaveChanges();
                    isDeleted = true;
                }
                else
                {
                    isDeleted = false;
                }
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
            return isDeleted;
        }

        // Update
        [HttpPost]
        [Route("api/employee/searchEmployees")]
        public IList<EmployeeViewModel> Search(EmployeeViewModel viewModel)
        {
            IList<EmployeeViewModel> employeeVms = null;
            try
            {
                IEnumerable<TBL_EMPLOYEE> employees = employeeRepository.GetAll();
                employeeVms = new List<EmployeeViewModel>();
                foreach (TBL_EMPLOYEE item in employees)
                {
                    employeeVms.Add(viewModelConvertor.GetEmployeeViewModel(item));
                }
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
            return employeeVms;
        }
    }
}
