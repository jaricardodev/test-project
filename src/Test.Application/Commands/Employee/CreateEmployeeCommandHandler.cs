using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Test.Application.Commands.Employee;
using Test.Application.DTOs.Employee;
using Test.Repository;

namespace Test.Application.Commands.Company;

public class CreateEmployeeCommandHandler: IRequestHandler<CreateEmployeeCommand, CreateEmployeeResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateEmployeeCommandHandler> _logger;

    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateEmployeeCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CreateEmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = Domain.Entities.Employee.New(
                request.fullName, 
                request.idNumber,
                request.dateOfBirth,
                request.companyId
            );              
            
        _logger.LogInformation(@"----- Creating Employee - 
            FullName: {@fullName} - 
            IdNumber: {@idNumber} - 
            DateOfBirth: {@dateOfBirth} - 
            CompanyId: {@companyId}", 
            request.fullName, 
            request.idNumber,
            request.dateOfBirth,
            request.companyId
            );
        
        employee = await _unitOfWork.EmployeeRepository.CreateAsync(employee, cancellationToken);
        await _unitOfWork.SaveEntitiesAsync(cancellationToken);

        return new CreateEmployeeResponse
        {
            Result = _mapper.Map<EmployeeDTO>(employee)
        };
    }
}