using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeInfo.Contracts.Entities.Custom
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "Female")]
        Female
    }
    public enum MaritalStatus
    {
        [Display(Name = "Married")]
        Married,
        [Display(Name = "Single")]
        Single
    }
}
