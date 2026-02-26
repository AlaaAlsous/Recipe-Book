using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Recipe_Book.Services;

namespace Recipe_Book.Forms
{
    public partial class ShowForm : Form
    {
        private readonly RecipeService _recipeService;
        private enum ViewMode { None, Recipes, Ingredients, Categories, RecipeIngredients }
        private ViewMode _currentView = ViewMode.None;

        public ShowForm(RecipeService recipeService)
        {
            InitializeComponent();
            _recipeService = recipeService;
        }

        private async void BtnShowRecipes_Click(object? sender, EventArgs e)
        {
            try
            {
                _currentView = ViewMode.Recipes;
                buttonDelete.Visible = false;
                button4.Visible = true;
                var recipes = await _recipeService.GetAllRecipesAsync();

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns.Add("Name", "Name");
                dataGridView1.Columns.Add("Description", "Description");
                dataGridView1.Columns.Add("Instructions", "Instructions");
                dataGridView1.Columns.Add("CreatedAt", "CreatedAt");
                dataGridView1.Columns.Add("UpdatedAt", "UpdatedAt");

                foreach (var r in recipes)
                {
                    dataGridView1.Rows.Add(r.RecipeId, r.Name, r.Description ?? string.Empty, r.Instructions ?? string.Empty, r.CreatedAt, r.UpdatedAt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load recipes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnShowIngredients_Click(object? sender, EventArgs e)
        {
            try
            {
                _currentView = ViewMode.Ingredients;
                buttonDelete.Visible = true;
                button4.Visible = false;
                var ingredients = await _recipeService.GetAllIngredientsAsync();

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns["Id"]!.Visible = false;
                dataGridView1.Columns.Add("Name", "Name");
                dataGridView1.Columns.Add("QuantityUnit", "Quantity Unit");

                foreach (var i in ingredients)
                {
                    dataGridView1.Rows.Add(i.IngredientId, i.Name, i.QuantityUnit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load ingredients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnShowCategories_Click(object? sender, EventArgs e)
        {
            try
            {
                _currentView = ViewMode.Categories;
                buttonDelete.Visible = true;
                button4.Visible = false;
                var categories = await _recipeService.GetAllCategoriesAsync();

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns["Id"]!.Visible = false;
                dataGridView1.Columns.Add("Name", "Category Name");

                foreach (var c in categories)
                {
                    dataGridView1.Rows.Add(c.CategoryId, c.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnShowRecipeIngredients_Click(object? sender, EventArgs e)
        {
            try
            {
                _currentView = ViewMode.RecipeIngredients;
                buttonDelete.Visible = false;
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a recipe to view its ingredients.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value?.ToString(), out var recipeId))
                {
                    MessageBox.Show("Selected row does not contain a valid recipe id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var recipe = await _recipeService.GetRecipeByIdAsync(recipeId);
                if (recipe == null)
                {
                    MessageBox.Show("Recipe not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Add("RecipeName", "Recipe Name");
                dataGridView1.Columns.Add("IngredientName", "Ingredient Name");
                dataGridView1.Columns.Add("Quantity", "Quantity");
                dataGridView1.Columns.Add("Unit", "Unit");

                foreach (var ri in recipe.RecipeIngredients)
                {
                    dataGridView1.Rows.Add(recipe.Name, ri.Ingredient.Name, ri.Quantity, ri.Unit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load recipe ingredients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
