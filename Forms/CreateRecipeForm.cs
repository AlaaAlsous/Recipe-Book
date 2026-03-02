using Recipe_Book.Services;
using System.Linq;

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

        private void TextBoxWithCounter_TextChanged(object? sender, EventArgs e)
        {
            Recipe_Book.Services.RecipeFormHelper.TextBoxWithCounter_TextChanged(this, sender, e, errorProvider1);
        }

        private async void BtnAddRecipe_Click(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Recipe name is required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim();
            var instructions = string.IsNullOrWhiteSpace(txtInstructions.Text) ? null : txtInstructions.Text.Trim();
            var categories = string.IsNullOrWhiteSpace(txtCategories.Text) ? null : txtCategories.Text.Trim();

            if (!RecipeFormHelper.TryParseCategories(categories, this, out var categoryList))
            {
                txtCategories.Focus();
                return;
            }

            if (!RecipeFormHelper.HasIngredients(_ingredients, this))
                return;

            var saved = await RecipeFormHelper.SaveNewRecipeAsync(_recipeService, name, description, instructions, _ingredients, categoryList, this);
            if (saved)
                this.Close();
        }
        private void BtnAddIng_Click(object? sender, EventArgs e)
        {
            RecipeFormHelper.AddIngredient(_ingredients, txtIngName, txtIngQuantity, txtIngUnit, dataGridView1);
        }

        private void BtnRemoveIng_Click(object? sender, EventArgs e)
        {
            RecipeFormHelper.RemoveSelectedIngredient(_ingredients, dataGridView1);
        }
    }
}
