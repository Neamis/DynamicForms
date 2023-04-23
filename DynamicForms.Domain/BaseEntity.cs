namespace DynamicForms.Domain;

public abstract class BaseEntity
{
    public abstract DateTime CreatedAt { get; set; }
    public abstract DateTime? UpdatedAt { get; set; }
}