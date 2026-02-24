namespace Recipe_Book.Forms
{
    public partial class CreateRecipeForm : Form
    {
        private readonly Services.RecipeService _recipeService;
        
        private readonly List<(string ingredientName, decimal quantity, string unit)> _ingredients = new();
        public CreateRecipeForm(Services.RecipeService recipeService)
        {
            InitializeComponent();
            _recipeService = recipeService;
        }

        private async void BtnAddRecipe_Click(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Recipe name is required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existingRecipes = await _recipeService.GetAllRecipesAsync();
            if (existingRecipes.Any(r => string.Equals(r.Name, name, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("A recipe with that name already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim();
            var instructions = string.IsNullOrWhiteSpace(txtInstructions.Text) ? null : txtInstructions.Text.Trim();
            var categories = string.IsNullOrWhiteSpace(txtCategories.Text) ? null : txtCategories.Text.Trim();
        }
    }
}
