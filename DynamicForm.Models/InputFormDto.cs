namespace DynamicForm.Models;

public class InputFormDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<FormFieldsDto> Fields { get; set; }
}