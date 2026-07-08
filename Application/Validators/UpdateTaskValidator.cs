using Application.Dtos.Requests;
using FluentValidation;

namespace Application.Validators;
public class UpdateTaskValidator : TaskValidatorBase<UpdateTaskRequest>
{
    public UpdateTaskValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        ValidateName(x => x.Name);
        ValidateDescription(x => x.Description);
        ValidatePriority(x => x.Priority);
        ValidateStatus(x => x.Status);
        ValidateLimitDate(x => x.LimitDate);
    }
}
