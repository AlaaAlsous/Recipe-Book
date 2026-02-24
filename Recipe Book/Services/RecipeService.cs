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

			foreach (var ing in ingredientList)
			{
				var ingredient = existingIngredients.FirstOrDefault(i => i.Name == ing.ingredientName);

				if (ingredient == null)
				{
					ingredient = new Ingredient { Name = ing.ingredientName, QuantityUnit = ing.unit };
					_context.Ingredients.Add(ingredient);
				}

				recipe.RecipeIngredients.Add(new RecipeIngredient
				{
					Recipe = recipe,
					Ingredient = ingredient,
					Quantity = ing.quantity,
					Unit = ing.unit
				});
			}

			foreach (var cat in categoryNames)
			{
				var category = existingCategories.FirstOrDefault(c => c.Name == cat);

				if (category == null)
				{
					category = new Category { Name = cat };
					_context.Categories.Add(category);
				}

				recipe.RecipeCategories.Add(new RecipeCategory
				{
					Recipe = recipe,
					Category = category
				});
			}

			_context.Recipes.Add(recipe);
			await _context.SaveChangesAsync();
		}

		public async Task<List<Recipe>> GetAllRecipesAsync()
		{
			return await _context.Recipes
				.Include(r => r.RecipeIngredients)
					.ThenInclude(ri => ri.Ingredient)
				.Include(r => r.RecipeCategories)
					.ThenInclude(rc => rc.Category)
				.ToListAsync();
		}

		public async Task<Recipe?> GetRecipeByIdAsync(int id)
		{
			return await _context.Recipes
				.Include(r => r.RecipeIngredients)
					.ThenInclude(ri => ri.Ingredient)
				.Include(r => r.RecipeCategories)
					.ThenInclude(rc => rc.Category)
				.FirstOrDefaultAsync(r => r.RecipeId == id);
		}

		public async Task UpdateRecipeAsync(
			int recipeId,
			string recipeName,
			string description,
			string instructions,
			List<(string ingredientName, decimal quantity, string unit)> ingredients,
			List<string> categories)
		{
			var recipe = await _context.Recipes
				.Include(r => r.RecipeIngredients)
				.Include(r => r.RecipeCategories)
				.FirstOrDefaultAsync(r => r.RecipeId == recipeId);

			if (recipe == null)
				return;

			recipe.Name = recipeName;
			recipe.Description = description;
			recipe.Instructions = instructions;
			recipe.UpdatedAt = DateTime.Now;

			_context.RecipeIngredients.RemoveRange(recipe.RecipeIngredients);
			_context.RecipeCategories.RemoveRange(recipe.RecipeCategories);

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

			foreach (var ing in ingredientList)
			{
				var ingredient = existingIngredients.FirstOrDefault(i => i.Name == ing.ingredientName);

				if (ingredient == null)
				{
					ingredient = new Ingredient { Name = ing.ingredientName, QuantityUnit = ing.unit };
					_context.Ingredients.Add(ingredient);
				}

				recipe.RecipeIngredients.Add(new RecipeIngredient
				{
					Recipe = recipe,
					Ingredient = ingredient,
					Quantity = ing.quantity,
					Unit = ing.unit
				});
			}

			foreach (var cat in categoryNames)
			{
				var category = existingCategories.FirstOrDefault(c => c.Name == cat);

				if (category == null)
				{
					category = new Category { Name = cat };
					_context.Categories.Add(category);
				}

				recipe.RecipeCategories.Add(new RecipeCategory
				{
					Recipe = recipe,
					Category = category
				});
			}

			await _context.SaveChangesAsync();
		}

		public async Task DeleteRecipeAsync(int id)
		{
			var recipe = await _context.Recipes.FindAsync(id);
			if (recipe != null)
			{
				_context.Recipes.Remove(recipe);
				await _context.SaveChangesAsync();
			}
		}
	}
}