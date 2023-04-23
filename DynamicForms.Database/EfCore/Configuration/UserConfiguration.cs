using DynamicForms.Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicForms.Database.EfCore.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var adminUser = new User
        {
            Id = 1,
            UserName = "adminuser",
            NormalizedUserName = "ADMINUSER",
            Email = "adminuser@gmail.com",
            NormalizedEmail = "ADMINUSER@GMAIL.COM",
            PhoneNumber = "+905555555555",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        };
        adminUser.PasswordHash = CreatePasswordHash(adminUser, "adminuser");
        builder.HasData(adminUser);
    }

    private string CreatePasswordHash(User user, string password)
    {
        var passwordHasher = new PasswordHasher<User>();
        return passwordHasher.HashPassword(user, password);
    }
}