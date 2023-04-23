using DynamicForms.Domain.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicForms.Database.EfCore.Configuration;

public class FormFieldConfiguration : IEntityTypeConfiguration<FormFields>
{
    public void Configure(EntityTypeBuilder<FormFields> builder)
    {
        builder.ToTable("FormFields");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
    }
}