using Application.Dtos.Requests;

namespace Application.Validators;
public class CreateTaskValidator : TaskValidatorBase<CreateTaskRequest>
{
    public CreateTaskValidator()
    {
        ValidateName(x => x.Name);
        ValidateDescription(x => x.Description);
        ValidatePriority(x => x.Priority);
        ValidateStatus(x => x.Status);
        ValidateLimitDate(x => x.LimitDate);
    }
}
