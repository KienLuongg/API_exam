using System;
using DMAWS_T2204M_TrungKien.Models;

namespace DMAWS_T2204M_TrungKien.DTOs
{
	public class ProjectDTO
	{
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public DateTime ProjectStartDate { get; set; }

        public DateTime? ProjectEndDate { get; set; }

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();

    }
}

