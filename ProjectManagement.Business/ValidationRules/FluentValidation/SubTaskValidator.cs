using FluentValidation;
using ProjectManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Business.ValidationRules.FluentValidation
{
    public class SubTaskValidator: AbstractValidator<SubTask>
    {
        public SubTaskValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(250);
            RuleFor(x => x.CreatedDate).NotNull();
            RuleFor(x => x.CreatedUserId).NotNull();
            RuleFor(x => x.DueDate).NotNull();
            RuleFor(x => x.TaskId).GreaterThanOrEqualTo(1);
        }
    }
}
