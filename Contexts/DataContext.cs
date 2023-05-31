using Bmerketo_WebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace Bmerketo_WebApp.Contexts;

public class DataContext : DbContext
{
	
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{

	}
	public DbSet<ProductEntity> Products { get; set; }
	public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
	public DbSet<ProductImageUrlEntity> ProductImages { get; set; }
	public DbSet<ProductRelationshipEntity> ProductRelationships { get; set; }
	public DbSet<ProductTagEntity> ProductTags { get; set; }
	public DbSet<ContactFormEntity> ContactForms { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<ProductEntity>().HasData(
			new ProductEntity { Id = 1, Title = "ThnkPad T14s G2 Core I7 16GB 512GB SSD 14", Price = 1200, Description = "Arbete har aldrig varit snyggare\r\nOavsett om du föredrar en pekskärm eller en traditionell bildskärm kan du välja bland flera skärmalternativ till ThinkPad T14s Gen 2. Vad du än väljer får du smala ramar som ger maximalt skärmutrymme. Välj en FHD-lågenergipanel för maximal batteritid, eller satsa på en FHD-pekskärm med vidvinkelvy. För större detaljskärpa och ljusstyrka och förbluffande korrekta färger kan 4K-bildskärmen fås med Dolby Vision™ IPS HDR." });

		var productTags = new[]
		   {
			new ProductTagEntity { Id = 1, TagName = "new" },
			new ProductTagEntity { Id = 2, TagName = "discount" },
			new ProductTagEntity { Id = 3, TagName = "popular" },
			new ProductTagEntity { Id = 4, TagName = "featured" },
			new ProductTagEntity { Id = 5, TagName = "top selling" },
			new ProductTagEntity { Id = 6, TagName = "related" }
		   };
		modelBuilder.Entity<ProductTagEntity>().HasData(productTags);


		modelBuilder.Entity<ProductImageUrlEntity>().HasData(
			new ProductImageUrlEntity { Id = 1, ImageUrlName = "https://images.pexels.com/photos/812264/pexels-photo-812264.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" });

		modelBuilder.Entity<ProductCategoryEntity>().HasData(
			new ProductCategoryEntity { Id = 1, CategoryName = "Hem Elektronik"});

		
		modelBuilder.Entity<ProductRelationshipEntity>().HasData(
			new ProductRelationshipEntity { ProductId = 1, TagId = 1, ImageUrlId = 1, CategoryId = 1 });
	}
}
