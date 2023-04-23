using DynamicForm.Models;
using DynamicForms.Domain.Forms;

namespace DynamicForms.Application.Services;

public interface IInputFormService
{
    Task<bool> CreateAsync(InputFormDto inputForm);
    Task<InputForm?> GetAsync(int id);
    Task<IList<InputForm>> GetAllAsync();
}