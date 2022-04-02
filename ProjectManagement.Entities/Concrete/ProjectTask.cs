using ProjectManagement.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Entities.Concrete
{
    public class ProjectTask : EntityBase, IEntity
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsComplate { get; set; }

    }
}
