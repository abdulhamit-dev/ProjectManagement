using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Entities.Dtos.Project
{
    public class ProjectTasksDto
    {
        public int TaskId { get; set; }
        public string ProjectName { get; set; }
        public string TaskDescription { get; set; }
        public string UserName { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplate { get; set; }
    }
}
