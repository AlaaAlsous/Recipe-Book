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

        private async Task LoadRecipes(string? query = null)
        {
            try
            {
                List<Recipe> recipes;
                if (string.IsNullOrWhiteSpace(query))
                {
                    recipes = await _recipeService.GetAllRecipesAsync();
                }
                else
                {
                    recipes = await _recipeService.SearchRecipesAsync(query);
                }

                dgvRecipes.Rows.Clear();
                foreach (var recipe in recipes)
                {
                    dgvRecipes.Rows.Add(recipe.RecipeId, recipe.Name, recipe.UpdatedAt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load recipes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var q = txtSearch?.Text ?? string.Empty;
                await LoadRecipes(q);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var createForm = new Forms.CreateRecipeForm(_recipeService);
                createForm.ShowDialog();
                await LoadRecipes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not create recipe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRecipes.SelectedRows.Count > 0)
                {
                    var cellVal = dgvRecipes.SelectedRows[0].Cells[0].Value;
                    if (cellVal == null || !int.TryParse(cellVal.ToString(), out var recipeId))
                    {
                        MessageBox.Show("Selected row does not contain a valid recipe id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

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
            catch (Exception ex)
            {
                MessageBox.Show($"Could not delete recipe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRecipes.SelectedRows.Count > 0)
                {
                    var cellVal = dgvRecipes.SelectedRows[0].Cells[0].Value;
                    if (cellVal == null || !int.TryParse(cellVal.ToString(), out var recipeId))
                    {
                        MessageBox.Show("Selected row does not contain a valid recipe id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var editForm = new Forms.EditRecipeForm(_recipeService, recipeId);
                    editForm.ShowDialog();
                    await LoadRecipes();
                }
                else
                {
                    MessageBox.Show("Please select a recipe to edit.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not edit recipe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                var showForm = new Forms.ShowForm(_recipeService);
                showForm.ShowDialog();
                await LoadRecipes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not show recipes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}