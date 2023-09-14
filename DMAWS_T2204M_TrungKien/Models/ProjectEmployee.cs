using System;
using System.ComponentModel.DataAnnotations;

namespace DMAWS_T2204M_TrungKien.Models
{
	public class ProjectEmployee
	{
		public int EmployeeId { get; set; }

		public int ProjectId { get; set; }

        [Required]
        public string Tasks { get; set; }

        [Required]
        public virtual Employee Employees { get; set; }

        [Required]
        public virtual Project Projects { get; set; }

    }
}

