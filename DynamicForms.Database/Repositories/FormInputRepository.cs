using DynamicForms.Database.EfCore.Repository;
using DynamicForms.Domain.Forms;
using Microsoft.EntityFrameworkCore;

namespace DynamicForms.Database.Repositories;

public class FormInputRepository : EfEntityRepositoryBase<InputForm>, IFormInputRepository
{
    public FormInputRepository(DbContext context) : base(context)
    {
    }
}