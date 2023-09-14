using System;
using DMAWS_T2204M_TrungKien.Models;

namespace DMAWS_T2204M_TrungKien.DTOs
{
	public class EmployeeDTO
	{
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public DateTime EmployeeDOB { get; set; }

        public string EmployeeDepartment { get; set; }

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();
    }
}

