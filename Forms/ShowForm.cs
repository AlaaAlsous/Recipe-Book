using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Recipe_Book.Services;
using System.Drawing.Printing;

namespace Recipe_Book.Forms
{
    public partial class ShowForm : Form
    {
        private readonly RecipeService _recipeService;
        private PrintDocument _printDocument;
        private string _printText = string.Empty;
        private Font _printFont = new Font("Segoe UI", 12);
        private int _printCharIndex = 0;
        private int _printPageNumber = 1;
        private Font _footerFont = new Font("Segoe UI", 10);
        private enum ViewMode { None, Recipes, Ingredients, Categories, RecipeIngredients }
        private ViewMode _currentView = ViewMode.None;

        public ShowForm(RecipeService recipeService)
        {
            InitializeComponent();
            _recipeService = recipeService;
            _printDocument = new PrintDocument();
            _printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private async void BtnShowRecipes_Click(object? sender, EventArgs e)
        {
            try
            {
                _currentView = ViewMode.Recipes;
                buttonDelete.Visible = false;
                button4.Visible = true;
                buttonPrint.Visible = true;
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
                buttonPrint.Visible = false;
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
                buttonPrint.Visible = false;
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
                buttonPrint.Visible = false;
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

        private async void BtnDelete_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an item to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = dataGridView1.SelectedRows[0];
                object? idObj = null;
                if (dataGridView1.Columns.Contains("Id"))
                    idObj = row.Cells["Id"].Value;
                else
                    idObj = row.Cells[0].Value;

                if (!int.TryParse(idObj?.ToString(), out var id))
                {
                    MessageBox.Show("Selected row does not contain a valid id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool ok = false;
                if (_currentView == ViewMode.Ingredients)
                {
                    ok = await _recipeService.DeleteIngredientAsync(id);
                    if (!ok)
                        MessageBox.Show("Could not delete ingredient. It may be used by one or more recipes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Ingredient deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BtnShowIngredients_Click(null, EventArgs.Empty);
                }
                else if (_currentView == ViewMode.Categories)
                {
                    ok = await _recipeService.DeleteCategoryAsync(id);
                    if (!ok)
                        MessageBox.Show("Could not delete category. It may be used by one or more recipes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Category deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BtnShowCategories_Click(null, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Delete is not available for the current view.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not delete item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnPrint_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_currentView != ViewMode.Recipes)
                {
                    MessageBox.Show("Select a recipe in the recipes view to print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a recipe to print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                var sb = new System.Text.StringBuilder();
                sb.AppendLine(recipe.Name);
                sb.AppendLine(new string('=', Math.Min(80, recipe.Name.Length + 5)));
                if (!string.IsNullOrWhiteSpace(recipe.Description))
                {
                    sb.AppendLine("Description:");
                    sb.AppendLine(recipe.Description);
                    sb.AppendLine();
                }
                if (!string.IsNullOrWhiteSpace(recipe.Instructions))
                {
                    sb.AppendLine("Instructions:");
                    sb.AppendLine(recipe.Instructions);
                    sb.AppendLine();
                }

                if (recipe.RecipeIngredients != null && recipe.RecipeIngredients.Any())
                {
                    sb.AppendLine("Ingredients:");
                    foreach (var ri in recipe.RecipeIngredients)
                    {
                        sb.AppendLine($"- {ri.Ingredient.Name}: {ri.Quantity} {ri.Unit}");
                    }
                }

                _printText = sb.ToString();

                using var dialog = new PrintDialog();
                dialog.Document = _printDocument;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _printDocument.DocumentName = recipe.Name;
                    _printCharIndex = 0;
                    _printPageNumber = 1;
                    _printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not print recipe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object? sender, PrintPageEventArgs e)
        {
            var layoutRect = new RectangleF(e.MarginBounds.X, e.MarginBounds.Y, e.MarginBounds.Width, e.MarginBounds.Height);

            float footerHeight = _footerFont.GetHeight(e.Graphics!) + 8f;
            var contentRect = new RectangleF(layoutRect.X, layoutRect.Y, layoutRect.Width, Math.Max(0, layoutRect.Height - footerHeight));

            var sf = StringFormat.GenericTypographic;
            sf.FormatFlags &= ~StringFormatFlags.MeasureTrailingSpaces;

            string remaining = _printText.Substring(Math.Min(_printCharIndex, _printText.Length));
            int charsFitted = 0;
            int linesFilled = 0;

            e.Graphics!.MeasureString(remaining, _printFont, new SizeF(contentRect.Width, contentRect.Height), sf, out charsFitted, out linesFilled);

            if (charsFitted <= 0)
            {
                e.HasMorePages = false;
                return;
            }

            string pageText = remaining.Substring(0, charsFitted);

            e.Graphics.DrawString(pageText, _printFont, Brushes.Black, contentRect, sf);

            string footer = $"Page {_printPageNumber}";
            var footerSize = e.Graphics.MeasureString(footer, _footerFont);
            float footerX = layoutRect.X + (layoutRect.Width - footerSize.Width) / 2f;
            float footerY = layoutRect.Y + contentRect.Height + 4f;
            e.Graphics.DrawString(footer, _footerFont, Brushes.Black, new System.Drawing.PointF(footerX, footerY));

            _printCharIndex += charsFitted;
            bool more = _printCharIndex < _printText.Length;
            e.HasMorePages = more;
            if (more)
            {
                _printPageNumber++;
            }
        }
    }
}
