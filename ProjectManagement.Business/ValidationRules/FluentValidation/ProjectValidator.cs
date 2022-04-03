using FluentValidation;
using ProjectManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Business.ValidationRules.FluentValidation
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.TeamId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Description).MaximumLength(250);
        }
    }
}
