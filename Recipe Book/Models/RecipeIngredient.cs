using System.ComponentModel.DataAnnotations;

namespace Recipe_Book.Models
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;
        public decimal Quantity { get; set; }
        [Required]
        [MaxLength(50)]
        public string Unit { get; set; } = null!;
    }
}