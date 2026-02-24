using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Recipe_Book.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        public int CategoryId { get; set; }
        [Required] 
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public ICollection<RecipeCategory> RecipeCategories { get; set; } = new List<RecipeCategory>();
    }
}