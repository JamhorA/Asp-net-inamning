using Bmerketo_WebApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Contexts;

public class IdentityContext : IdentityDbContext<UserEntity>
{
	public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
	{
	}
	public DbSet<UserProfileEntity> UserProfiles { get; set; }
	public DbSet<AddressEntity> Addresses { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.Entity<IdentityRole>().HasData(
			new IdentityRole { 
				Id = "87e2f379-5e41-4a1a-8f3a-c8bdfff18607", 
				Name = "Admin", 
				NormalizedName = "ADMIN", 
				ConcurrencyStamp = Guid.NewGuid().ToString(),
				},
			new IdentityRole
			{
				Id = "51ddb0cf-aae0-4f23-9585-bd6d81e79c69",
				Name = "User",
				NormalizedName = "USER",
				ConcurrencyStamp = Guid.NewGuid().ToString(),
			});
		var passwordHasher = new PasswordHasher<UserEntity>();
		var adminUserEntity = new UserEntity
		{
			Id = "ec60e97c-bf97-4e49-8a3c-979dce9cd771",
			FirstName = "Tommy",
			LastName = "Nillson",
			UserName = "admin@domain.com",
			NormalizedUserName = "ADMIN@DOMAIN.COM",
			Email = "admin@domain.com",
			NormalizedEmail = "ADMIN@DOMAIN.COM",
			ConcurrencyStamp = Guid.NewGuid().ToString(),
		};

		adminUserEntity.PasswordHash = passwordHasher.HashPassword(adminUserEntity, "BytMig123!");
		builder.Entity<UserEntity>().HasData(adminUserEntity);

		builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
		{
			UserId = adminUserEntity.Id,
			RoleId = "87e2f379-5e41-4a1a-8f3a-c8bdfff18607"
		});
	}
}
