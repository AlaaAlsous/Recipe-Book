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

            if (!string.IsNullOrWhiteSpace(categories))
            {
                var parts = categories.Split(',').Select(c => c.Trim()).ToList();
                if (parts.Any(string.IsNullOrEmpty))
                {
                    MessageBox.Show("Invalid category entry.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategories.Focus();
                    return;
                }

                if (parts.Distinct(StringComparer.OrdinalIgnoreCase).Count() != parts.Count)
                {
                    MessageBox.Show("Duplicate categories entered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategories.Focus();
                    return;
                }
            }

            var ingredientList = _ingredients;
            if (ingredientList == null || ingredientList.Count == 0)
            {
                MessageBox.Show("No ingredients added.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var categoryList = new List<string>();
            if (!string.IsNullOrWhiteSpace(categories))
            {
                foreach (var c in categories.Split(','))
                {
                    var cat = c.Trim();
                    if (!string.IsNullOrEmpty(cat))
                        categoryList.Add(cat);
                }
            }

            try
            {
                await _recipeService.AddRecipeAsync(name, description!, instructions!, ingredientList, categoryList);
                MessageBox.Show("Recipe saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not save recipe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
