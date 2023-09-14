using System;
using System.ComponentModel.DataAnnotations;

namespace DMAWS_T2204M_TrungKien.Models
{
	public class Employee
	{
		public int EmployeeId { get; set; }

		[Required]
        [StringLength(150, MinimumLength = 2)]
		public string EmployeeName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EmployeeDOB { get; set; }

        [Required]
        public string EmployeeDepartment { get; set; }

        
        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();
    }
}

