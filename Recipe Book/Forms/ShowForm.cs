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

        public ShowForm(RecipeService recipeService)
        {
            InitializeComponent();
            _recipeService = recipeService;
        }

        private async void BtnShowRecipes_Click(object? sender, EventArgs e)
        {
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

        private async void BtnShowIngredients_Click(object? sender, EventArgs e)
        {
            var ingredients = await _recipeService.GetAllIngredientAsync();

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("QuantityUnit", "Quantity Unit");

            foreach (var i in ingredients)
            {
                dataGridView1.Rows.Add(i.Name, i.QuantityUnit);
            }
        }

        private async void BtnShowCategories_Click(object? sender, EventArgs e)
        {
            var categories = await _recipeService.GetAllCategoryAsync();

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("Name", "Category Name");

            foreach (var c in categories)
            {
                dataGridView1.Rows.Add(c.Name);
            }
        }

    }
}
