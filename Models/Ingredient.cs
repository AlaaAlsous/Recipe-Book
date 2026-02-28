using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Recipe_Book.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Ingredient
    {
        public int IngredientId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string QuantityUnit { get; set; } = null!;

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}