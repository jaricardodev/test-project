using FluentValidation;
using Test.Application.Commands.Company;
using Test.Application.Commands.Employee;

namespace Test.API.validators;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(c => c.fullName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(c => c.idNumber)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(c => c.dateOfBirth.ToUniversalTime())
            .NotNull()
            .LessThanOrEqualTo(DateTime.UtcNow);

        RuleFor(c => c.companyId)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}