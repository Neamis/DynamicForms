namespace DynamicForms.Domain.Forms;

public class FormFields : BaseEntity, IEntity
{
    public int InputFormId { get; set; }
    public virtual InputForm InputForm { get; set; }
    public bool IsRequired { get; set; }
    public string Name { get; set; }
    public string DataType { get; set; }

    public override DateTime CreatedAt { get; set; }
    public override DateTime? UpdatedAt { get; set; }
    public int Id { get; set; }
}