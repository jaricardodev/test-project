using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DbRepository.EntityConfiguration.Base;
using Test.Domain.Entities;

namespace Test.DbRepository.EntityConfiguration
{
    internal class EmployeeEntityConfiguration : EntityTypeConfiguration<Employee>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.FullName)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(e => e.IdNumber)
            .IsRequired()
            .HasMaxLength(10);

            builder.Property(e => e.DateOfBirth)
            .IsRequired();

            builder.Property(e => e.CompanyId)
            .IsRequired();
        }
    }
}
