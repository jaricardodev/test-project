using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Test.Application.UnitTests;

public class UnitTest
{
    [Fact]
    public void CreateCompanyValidatorSucceededWhenCompanyDoesNotExist()
    {
        //Test CreateCompanyValidator
        //Assert.True(validationResult.IsSuccessful);
    }
    
    [Fact]
    public void CreateCompanyValidatorMustFailWhenCompanyExist()
    {
        //Test CreateCompanyValidator
        //Assert.False(validationResult.IsSuccessful);
    }
}