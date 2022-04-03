using FluentValidation;
using ProjectManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Business.ValidationRules.FluentValidation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x=>x.UserName).NotEmpty().MaximumLength(50);
            RuleFor(x=>x.Password).NotEmpty().MaximumLength(100);
            RuleFor(x=>x.FullName).MaximumLength(100);
            RuleFor(x => x.TeamId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(100);

        }
    }
}
