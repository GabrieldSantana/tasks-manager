using Application.Dtos.Requests;
using FluentValidation;

namespace Application.Validators;
public class TaskFilterValidator : AbstractValidator<TaskFilterRequest>
{
    public TaskFilterValidator()
    {
        RuleFor(x => x.PageNumber)
          .GreaterThan(0);

        RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100);
    }
}
