using ProjectManagement.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Entities.Concrete
{
    public class Project: EntityBase,IEntity
    {
        public string Description { get; set; }
        public int TeamId { get; set; }
    }
}
