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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<RecipeIngredient>()
				.HasKey(ri => new { ri.RecipeId, ri.IngredientId });

			modelBuilder.Entity<RecipeIngredient>()
				.HasOne(ri => ri.Recipe)
				.WithMany(r => r.RecipeIngredients)
				.HasForeignKey(ri => ri.RecipeId);

			modelBuilder.Entity<RecipeIngredient>()
				.HasOne(ri => ri.Ingredient)
				.WithMany(i => i.RecipeIngredients)
				.HasForeignKey(ri => ri.IngredientId);

			modelBuilder.Entity<RecipeCategory>()
				.HasKey(rc => new { rc.RecipeId, rc.CategoryId });

			modelBuilder.Entity<RecipeCategory>()
				.HasOne(rc => rc.Recipe)
				.WithMany(r => r.RecipeCategories)
				.HasForeignKey(rc => rc.RecipeId);

			modelBuilder.Entity<RecipeCategory>()
				.HasOne(rc => rc.Category)
				.WithMany(c => c.RecipeCategories)
				.HasForeignKey(rc => rc.CategoryId);
		}
	}
}