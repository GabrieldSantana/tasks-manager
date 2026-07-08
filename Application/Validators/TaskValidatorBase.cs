using System.Linq.Expressions;
using Domain.Enums;
using FluentValidation;

namespace Application.Validators;
public abstract class TaskValidatorBase<T> : AbstractValidator<T>
{
    protected void ValidateName(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .MaximumLength(150);
    }

    protected void ValidateDescription(Expression<Func<T, string?>> expression)
    {
        RuleFor(expression)
            .MaximumLength(200);
    }

    protected void ValidatePriority(Expression<Func<T, PriorityEnum>> expression)
    {
        RuleFor(expression)
            .IsInEnum();
    }

    protected void ValidateStatus(Expression<Func<T, StatusEnum>> expression)
    {
        RuleFor(expression)
            .IsInEnum();
    }

    protected void ValidateLimitDate(Expression<Func<T, DateTime>> expression)
    {
        RuleFor(expression)
            .GreaterThan(DateTime.UtcNow);
    }
}
