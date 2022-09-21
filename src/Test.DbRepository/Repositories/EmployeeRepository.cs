using Microsoft.EntityFrameworkCore;
using Test.DbRepository.Repositories.Base;
using Test.Domain.Entities;
using Test.Repository;

namespace Test.DbRepository.Repositories
{
    public class EmployeeRepository : EntityFrameworkRepository<Employee>, IEmployeeRepository
    {
        protected EmployeeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
