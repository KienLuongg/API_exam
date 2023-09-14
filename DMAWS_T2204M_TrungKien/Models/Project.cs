using System;
using System.ComponentModel.DataAnnotations;

namespace DMAWS_T2204M_TrungKien.Models
{
	public class Project
	{
		public int ProjectId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string ProjectName { get; set; }

        [Required]
        public DateTime ProjectStartDate { get; set; }

        [Required]
        public DateTime? ProjectEndDate { get; set; }

        [Required]
        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();

    }
}

