using FluentValidation;
using ProjectManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Business.ValidationRules.FluentValidation
{
    public class RoleValidator: AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(50);
        }
    }
}
