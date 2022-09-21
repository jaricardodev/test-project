using Test.Application.Commands.Company;
using Test.Application.Commands.Employee;
using Test.Application.Validators.Base;
using Test.Repository;

namespace Test.Application.Validators.Company;

public class CreateEmployeeValidator: IBusinessValidationHandler<CreateEmployeeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async  Task<ValidationResult> Validate(CreateEmployeeCommand request)
    {
        var companyValidation = await _unitOfWork.CompanyRepository.FindAsync(request.companyId) == null
            ? ValidationResult.Fail(new FieldError(nameof(request.companyId), "Invalid companyId"))
            : ValidationResult.Success;

        if(!companyValidation.IsSuccessful) 
            return companyValidation;

        return await _unitOfWork.EmployeeRepository.EmployeeExistsAsync(request.idNumber)
            ? ValidationResult.Fail(new FieldError(nameof(request.idNumber), "Employee idNumber already exists"))
            : ValidationResult.Success;
    }
}