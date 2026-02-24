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
    }
}