using dataAccess_EF.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace viewModels.employeeManagement
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string Firstname { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Please select whether employee is permanent or not")]
        [Display(Name = "Permenent")]
        public string PermanentChar { get; set; }           
        public string Permanent { get; set; }
        public IEnumerable<SelectListItem> PermenentSelectListItems { get; set; }

        //public virtual TBL_DEPARTMENT TBL_DEPARTMENT { get; set; }
               
        
        [Required(ErrorMessage = "Please select an employee department")]
        [Display(Name = "Department")]
        public Nullable<int> DepartmentId { get; set; }
        public IEnumerable<SelectListItem> DepartmentSelectListItems { get; set; }
        public string DepartmentName { get; set; }
    }
}
