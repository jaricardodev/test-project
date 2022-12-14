namespace Test.Domain.Seed;

public interface IEntity
{
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
    string CreatedBy { get; set; }
    string UpdatedBy { get; set; }
}