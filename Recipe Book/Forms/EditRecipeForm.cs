using Recipe_Book.Services;
using Recipe_Book.Models;
using System.Linq;

namespace Recipe_Book.Forms
{
    public partial class EditRecipeForm : Form
    {
        private readonly int? _recipeId;
        private readonly Services.RecipeService _recipeService;
        private readonly List<(string ingredientName, decimal quantity, string unit)> _ingredients = new();

        public EditRecipeForm(Services.RecipeService recipeService, int? recipeId = null)
        {
            InitializeComponent();
            _recipeService = recipeService;
            _recipeId = recipeId;
            Load += EditRecipeForm_Load;
        }
    }
}
