using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Recipe_Book.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Recipe
	{
		public int RecipeId { get; set; }
		[Required]
		[MaxLength(200)]
        public string Name { get; set; } = null!;
		[MaxLength(1000)]
		public string? Description { get; set; }
        [MaxLength(2000)]
        public string? Instructions { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime UpdatedAt { get; set; } = DateTime.Now;
		public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
		public ICollection<RecipeCategory> RecipeCategories { get; set; } = new List<RecipeCategory>();
	}
}