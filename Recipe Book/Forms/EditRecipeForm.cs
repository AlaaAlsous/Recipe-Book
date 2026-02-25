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

        private async void EditRecipeForm_Load(object? sender, EventArgs e)
        {
            if (!_recipeId.HasValue)
                return;

            try
            {
                var recipe = await _recipeService.GetRecipeByIdAsync(_recipeId.Value);
                if (recipe == null)
                {
                    MessageBox.Show("Recipe not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtName.Text = recipe.Name;
                txtDescription.Text = recipe.Description ?? string.Empty;
                txtInstructions.Text = recipe.Instructions ?? string.Empty;
                txtCategories.Text = string.Join(", ", recipe.RecipeCategories.Select(rc => rc.Category.Name));

                _ingredients.Clear();
                foreach (var ri in recipe.RecipeIngredients)
                {
                    _ingredients.Add((ri.Ingredient.Name, ri.Quantity, ri.Unit));
                }

                UpdateIngredientGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load recipe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
             private void UpdateIngredientGrid()
        {
            RecipeFormHelper.UpdateIngredientGrid(_ingredients, dataGridView1);
        }
       
    }
}
