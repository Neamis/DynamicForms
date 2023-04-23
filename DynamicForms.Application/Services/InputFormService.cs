using DynamicForm.Models;
using DynamicForms.Database.EfCore;
using DynamicForms.Database.Repositories;
using DynamicForms.Domain.Forms;

namespace DynamicForms.Application.Services;

public class InputFormService : IInputFormService
{
    private readonly IFormInputRepository _formInputRepository;
    private readonly DynamicFormsContext _context;

    public InputFormService(DynamicFormsContext context)
    {
        _formInputRepository = new FormInputRepository(context);
        _context = context;
    }

    public async Task<bool> CreateAsync(InputFormDto inputForm)
    {
        ArgumentException.ThrowIfNullOrEmpty(inputForm.Name,
            nameof(inputForm.Name));
        ArgumentException.ThrowIfNullOrEmpty(inputForm.Description,
            nameof(inputForm.Description));

        var nameIsExist =
            await _formInputRepository.AnyAsync(x => x.Name == inputForm.Name);

        if (nameIsExist)
            throw new ArgumentException("Name is already exist");

        var model = new InputForm
        {
            Name = inputForm.Name,
            Description = inputForm.Description,
            Fields = inputForm.Fields.Select(x => new FormFields
            {
                IsRequired = x.IsRequired,
                Name = x.Name,
                DataType = x.DataType,
                CreatedAt = DateTime.Now,
            }).ToList(),
            CreatedAt = DateTime.Now,
        };

        await _formInputRepository.AddAsync(model);
        return true;
    }

    public async Task<InputForm?> GetAsync(int id)
    {
        var model = await _formInputRepository.GetAsync(x => x.Id.Equals(id), x => x.Fields);
        if (model is not null)
            return model;
        return null;
    }

    public async Task<IList<InputForm>> GetAllAsync()
    {
        return await _formInputRepository.GetAllAsync();
    }
}