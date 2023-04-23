namespace DynamicForms.Domain.Forms;

public class InputForm : BaseEntity, IEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<FormFields> Fields { get; set; }
    public override DateTime CreatedAt { get; set; }
    public override DateTime? UpdatedAt { get; set; }
    public int Id { get; set; }
}