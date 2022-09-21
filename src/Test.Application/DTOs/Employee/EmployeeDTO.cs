using Test.Application.Commands.Base;
using Test.Application.Queries.Base;

namespace Test.Application.DTOs.Employee
{
    public record EmployeeDTO : ICommandDataResponse, IQueryDataResponse
    {
        public string FullName { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Guid CompanyId { get; set; }
    }
}
