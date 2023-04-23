using DynamicForms.Domain.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicForms.Database.EfCore.Configuration;

public class InputFormConfiguration : IEntityTypeConfiguration<InputForm>
{
    public void Configure(EntityTypeBuilder<InputForm> builder)
    {
        builder.ToTable("InputForms");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Description).IsRequired();
        builder.HasMany(x =>
            x.Fields).WithOne(x =>
            x.InputForm).HasForeignKey(x => x.InputFormId);
    }
}