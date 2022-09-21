using Microsoft.VisualStudio.TestPlatform;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Test.Application.Commands.Company;
using Test.Application.Validators.Company;
using Test.Repository;
using Xunit;

namespace Test.Application.UnitTests;

public class UnitTest
{
    const string TEST_CODE = "testCode";

    [Fact]
    public async void CreateCompanyValidatorSucceededWhenCompanyDoesNotExist()
    {
        var companyRepoMock = GetCompanyRepoMock(false);
        var unitOfWork = GetUnitOfWorkMock(companyRepoMock.Object).Object;

        var validationResult = await new CreateCompanyValidator(unitOfWork)
            .Validate(new CreateCompanyCommand("testName", TEST_CODE));

        Assert.True(validationResult.IsSuccessful);
        CommonAsserts(companyRepoMock);
    }
    
    [Fact]
    public async Task CreateCompanyValidatorMustFailWhenCompanyExistAsync()
    {
        var companyRepoMock = GetCompanyRepoMock(true);
        var unitOfWork = GetUnitOfWorkMock(companyRepoMock.Object).Object;

        var validationResult = await new CreateCompanyValidator(unitOfWork)
            .Validate(new CreateCompanyCommand("testName", TEST_CODE));

        Assert.False(validationResult.IsSuccessful);
        Assert.Equal("Already exists", validationResult.Error);
        CommonAsserts(companyRepoMock);
    }

    private Mock<IUnitOfWork> GetUnitOfWorkMock(ICompanyRepository companyRepository) {       
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock
            .Setup(x => x.CompanyRepository)
            .Returns(companyRepository);

        return unitOfWorkMock;
    }

    private Mock<ICompanyRepository> GetCompanyRepoMock(bool companyExistMockValue) 
    {
        var companyRepositoryMock = new Mock<ICompanyRepository>();
        companyRepositoryMock
            .Setup(x => x.CompanyExistsAsync(It.IsAny<string>()))
            .ReturnsAsync(companyExistMockValue);

        return companyRepositoryMock;
    }

    private void CommonAsserts(Mock<ICompanyRepository> companyRepoMock) 
    {
        companyRepoMock.Verify(x => x.CompanyExistsAsync(TEST_CODE),Times.Once);
    }
}