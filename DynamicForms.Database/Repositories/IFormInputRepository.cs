using DynamicForms.Database.EfCore.Repository;
using DynamicForms.Domain.Forms;

namespace DynamicForms.Database.Repositories;

public interface IFormInputRepository : IEntityRepository<InputForm>
{
}