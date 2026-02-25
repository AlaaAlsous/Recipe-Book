using Recipe_Book.Data;
using Recipe_Book.Models;
using Recipe_Book.Services;

namespace Recipe_Book
{
    public partial class MainForm : Form
    {
        private readonly RecipeService _recipeService;

        public MainForm(RecipeService recipeService)
        {
            InitializeComponent();
            _recipeService = recipeService;
            Load += async (s, e) => await LoadRecipes();
        }

        private async Task LoadRecipes()
        {
            var recipes = await _recipeService.GetAllRecipesAsync();
            dgvRecipes.Rows.Clear();
            foreach (var recipe in recipes)
            {
                dgvRecipes.Rows.Add(recipe.RecipeId, recipe.Name, recipe.UpdatedAt);
            }
        }

        private async void BtnCreate_Click(object sender, EventArgs e)
        {
            var createForm = new Forms.CreateRecipeForm(_recipeService);
            createForm.ShowDialog();
            await LoadRecipes();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRecipes.SelectedRows.Count > 0)
            {
                var recipeId = (int)dgvRecipes.SelectedRows[0].Cells[0].Value!;
                var confirm = MessageBox.Show("Are you sure you want to delete this recipe?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    await _recipeService.DeleteRecipeAsync(recipeId);
                    await LoadRecipes();
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to delete.");
            }
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRecipes.SelectedRows.Count > 0)
            {
                var recipeId = (int)dgvRecipes.SelectedRows[0].Cells[0].Value!;
                var editForm = new Forms.EditRecipeForm(_recipeService, recipeId);
                editForm.ShowDialog();
                await LoadRecipes();
            }
            else
            {
                MessageBox.Show("Please select a recipe to edit.");
            }
        }
    }
}