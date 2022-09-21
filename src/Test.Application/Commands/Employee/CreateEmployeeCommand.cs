using MediatR;
using Test.Application.Commands.Base;

namespace Test.Application.Commands.Employee;

public record CreateEmployeeCommand
    (
        string fullName, 
        string idNumber, 
        DateTime dateOfBirth, 
        Guid companyId
    ): BaseCommand, IRequest<CreateEmployeeResponse>;