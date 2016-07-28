using dataAccess_EF.EF;
using System;

namespace viewModels.employeeManagement
{
    public class ViewModelConvertor
    {
        public EmployeeViewModel GetEmployeeViewModel(TBL_EMPLOYEE model)
        {
            EmployeeViewModel viewModel = null;
            try
            {
                viewModel = new EmployeeViewModel();
                viewModel.EmployeeId = model.EMPLOYEE_ID;
                viewModel.Firstname = model.FIRST_NAME;
                viewModel.Lastname = model.LASTNAME;
                viewModel.Salary = model.SALARY;
                viewModel.PermanentChar = model.PERMANENT;
                viewModel.Permanent = model.PERMANENT == "Y" ? "Yes" : "No";
                viewModel.DepartmentId = model.DEPARTMENT_FID;
                //viewModel.TBL_DEPARTMENT = model.TBL_DEPARTMENT;
                viewModel.DepartmentName = model.TBL_DEPARTMENT.NAME;                
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
            return viewModel;
        }

        public TBL_EMPLOYEE GetTblEmployee(EmployeeViewModel viewModel)
        {
            TBL_EMPLOYEE employee = null;
            try
            {
                employee = new TBL_EMPLOYEE();
                employee.EMPLOYEE_ID = viewModel.EmployeeId;
                employee.FIRST_NAME = viewModel.Firstname;
                employee.LASTNAME = viewModel.Lastname;
                employee.SALARY = viewModel.Salary;
                employee.PERMANENT = viewModel.PermanentChar;
                employee.DEPARTMENT_FID = viewModel.DepartmentId;
                //employee.TBL_DEPARTMENT = viewModel.TBL_DEPARTMENT;
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
            return employee;
        }
    }
}
