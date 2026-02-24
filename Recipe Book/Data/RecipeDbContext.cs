using Microsoft.EntityFrameworkCore;
using Recipe_Book.Models;

namespace Recipe_Book.Data
{
	public class RecipeDbContext : DbContext
	{
		public DbSet<Recipe> Recipes { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
		public DbSet<RecipeCategory> RecipeCategories { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost,1433;Database=net25_db;User Id=net25;Password=Secret-NET.25-Password!;TrustServerCertificate=True;Encrypt=True;");
		}

	}
}