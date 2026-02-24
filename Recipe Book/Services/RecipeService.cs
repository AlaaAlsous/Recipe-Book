using Microsoft.EntityFrameworkCore;
using Recipe_Book.Data;
using Recipe_Book.Models;

namespace Recipe_Book.Services
{
	public class RecipeService
	{
		private readonly RecipeDbContext _context;

		public RecipeService(RecipeDbContext context)
		{
			_context = context;
		}

		public async Task AddRecipeAsync(
			string recipeName,
			string description,
			string instructions,
			List<(string ingredientName, decimal quantity, string unit)> ingredients,
			List<string> categories)
		{
			var recipe = new Recipe
			{
				Name = recipeName,
				Description = description,
				Instructions = instructions,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			};

			var ingredientList = ingredients ?? new List<(string ingredientName, decimal quantity, string unit)>();
			var ingredientNames = ingredientList.Select(i => i.ingredientName).ToList();
			var existingIngredients = new List<Ingredient>();
			if (ingredientNames.Count > 0)
			{
				existingIngredients = await _context.Ingredients
					.Where(i => ingredientNames.Contains(i.Name))
					.ToListAsync();
			}

			var categoryNames = categories ?? new List<string>();
			var existingCategories = new List<Category>();
			if (categoryNames.Count > 0)
			{
				existingCategories = await _context.Categories
					.Where(c => categoryNames.Contains(c.Name))
					.ToListAsync();
			}
			_context.Recipes.Add(recipe);
			await _context.SaveChangesAsync();
		}
	}
}