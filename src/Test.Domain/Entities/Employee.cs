using Test.Domain.Seed;

namespace Test.Domain.Entities
{
    public class Employee : Entity
    {
        public static Employee New(
            string fullName,
            string idNumber,
            DateTime dateOfBirth,
            Guid companyId
            )
        {
            var organization = new Employee(
                Guid.Empty,
                fullName,
                idNumber,
                dateOfBirth,
                companyId,
                null, 
                null,
                DateTime.UtcNow,
                DateTime.UtcNow
            );

            return organization;
        }

        public Employee(
            Guid id,
            string fullName,
            string idNumber,
            DateTime dateOfBirth,
            Guid companyId,
            string? createdBy,
            string? updatedBy,
            DateTime createdAt,
            DateTime updatedAt) : base(id, createdBy, updatedBy, createdAt, updatedAt)
        {
            Id = id;
            FullName = fullName;
            IdNumber = idNumber;
            DateOfBirth = dateOfBirth;
            CompanyId = companyId;
        }
        
        public string FullName { get; private set; }
        public string IdNumber { get; private set; }
        public DateTime DateOfBirth { get; private set; } 
        public Guid CompanyId { get; private set; }
        public Company Company { get; set; }       
    }
}
