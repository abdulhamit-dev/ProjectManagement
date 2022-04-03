using FluentValidation;
using ProjectManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Business.ValidationRules.FluentValidation
{
    public class UserRoleValidator: AbstractValidator<UserRole>
    {
        public UserRoleValidator()
        {
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
            RuleFor(x=>x.RoleId).GreaterThanOrEqualTo(1);
        }
    }
}
