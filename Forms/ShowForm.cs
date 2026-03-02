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
        private PrintDocument _printDocument = new PrintDocument();
        private Font _printFont = new Font("Segoe UI", 12);
        private int _printPageNumber = 1;
        private Font _footerFont = new Font("Segoe UI", 10);
        private string _printTitle = string.Empty;
        private string _printDescription = string.Empty;
        private string _printInstructions = string.Empty;
        private List<(string Name, string Quantity, string Unit)> _printIngredients = new List<(string, string, string)>();
        private Font _titleFont = new Font("Segoe UI", 20, FontStyle.Bold);
        private Font _labelFont = new Font("Segoe UI", 14, FontStyle.Bold);
        private int _printIngredientIndex = 0;
        private enum ViewMode { None, Recipes, Ingredients, Categories, RecipeIngredients }
        private ViewMode _currentView = ViewMode.None;

        public ShowForm(RecipeService recipeService)
        {
            InitializeComponent();
            _recipeService = recipeService;
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

                _printTitle = recipe.Name ?? string.Empty;
                _printDescription = recipe.Description ?? string.Empty;
                _printInstructions = recipe.Instructions ?? string.Empty;
                _printIngredients.Clear();
                if (recipe.RecipeIngredients != null)
                {
                    foreach (var ri in recipe.RecipeIngredients)
                    {
                        var qty = ri.Quantity.ToString();
                        var unit = ri.Unit ?? string.Empty;
                        _printIngredients.Add((ri.Ingredient.Name, qty, unit));
                    }
                }

                _printIngredientIndex = 0;

                using var dialog = new PrintDialog();
                dialog.Document = _printDocument;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _printDocument.DocumentName = recipe.Name!;
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
            var g = e.Graphics!;
            var layout = e.MarginBounds;
            float x = layout.X;
            float y = layout.Y;
            float bottom = layout.Bottom;

            if (!string.IsNullOrEmpty(_printTitle))
            {
                var titleSize = g.MeasureString(_printTitle, _titleFont);
                float titleX = layout.X + (layout.Width - titleSize.Width) / 2f;
                g.DrawString(_printTitle, _titleFont, Brushes.Maroon, titleX, y);
                y += titleSize.Height + 4f;

                using (var pen = new Pen(Color.Maroon, 1.5f))
                {
                    g.DrawLine(pen, layout.X, y, layout.Right, y);
                }
                y += 8f;
            }

            if (_printPageNumber == 1)
            {
                if (!string.IsNullOrWhiteSpace(_printDescription))
                {
                    g.DrawString("Description:", _labelFont, Brushes.DarkBlue, x, y);
                    y += _labelFont.GetHeight(g) + 2f;

                    var descSize = g.MeasureString(_printDescription, _printFont, (int)layout.Width);
                    var descRect = new RectangleF(x, y, layout.Width, descSize.Height);
                    g.DrawString(_printDescription, _printFont, Brushes.Black, descRect);
                    y += descSize.Height + 6f;
                }

                if (!string.IsNullOrWhiteSpace(_printInstructions))
                {
                    g.DrawString("Instructions:", _labelFont, Brushes.DarkBlue, x, y);
                    y += _labelFont.GetHeight(g) + 2f;

                    var instrSize = g.MeasureString(_printInstructions, _printFont, (int)layout.Width);
                    var instrRect = new RectangleF(x, y, layout.Width, instrSize.Height);
                    g.DrawString(_printInstructions, _printFont, Brushes.Black, instrRect);
                    y += instrSize.Height + 6f;
                }
            }

            if (_printIngredients != null && _printIngredients.Count > 0)
            {
                g.DrawString("Ingredients:", _labelFont, Brushes.DarkBlue, x, y);
                y += _labelFont.GetHeight(g) + 6f;

                float nameColWidth = layout.Width * 0.6f;
                float otherWidth = layout.Width - nameColWidth - 8f;
                float qtyColWidth = otherWidth * 0.6f;
                float unitColWidth = otherWidth - qtyColWidth;
                float qtyColX = x + nameColWidth + 8f;
                float unitColX = qtyColX + qtyColWidth;

                g.DrawString("Name", _labelFont, Brushes.DarkGreen, x, y);
                g.DrawString("Quantity", _labelFont, Brushes.DarkGreen, qtyColX, y);
                g.DrawString("Unit", _labelFont, Brushes.DarkGreen, unitColX, y);
                y += _labelFont.GetHeight(g) + 4f;

                for (int i = _printIngredientIndex; i < _printIngredients.Count; i++)
                {
                    var row = _printIngredients[i];
                    var nameSize = g.MeasureString(row.Name, _printFont, (int)nameColWidth);
                    var qtySize = g.MeasureString(row.Quantity, _printFont, (int)qtyColWidth);
                    var unitSize = g.MeasureString(row.Unit, _printFont, (int)unitColWidth);
                    float rowHeight = Math.Max(Math.Max(nameSize.Height, qtySize.Height), unitSize.Height) + 4f;

                    if (y + rowHeight > bottom - _footerFont.GetHeight(g) - 8f)
                    {
                        _printIngredientIndex = i;
                        e.HasMorePages = true;
                        _printPageNumber++;
                        return;
                    }

                    var nameRect = new RectangleF(x, y, nameColWidth, rowHeight);
                    var qtyRect = new RectangleF(qtyColX, y, qtyColWidth, rowHeight);
                    var unitRect = new RectangleF(unitColX, y, unitColWidth, rowHeight);
                    g.DrawString(row.Name, _printFont, Brushes.Black, nameRect);
                    g.DrawString(row.Quantity, _printFont, Brushes.Black, qtyRect);
                    g.DrawString(row.Unit, _printFont, Brushes.Black, unitRect);
                    y += rowHeight;
                }

                _printIngredientIndex = _printIngredients.Count;
                y += 6f;
            }

            string footer = $"Page {_printPageNumber}";
            var footerSize = g.MeasureString(footer, _footerFont);
            float footerX = layout.X + (layout.Width - footerSize.Width) / 2f;
            float footerY = layout.Bottom - footerSize.Height;
            g.DrawString(footer, _footerFont, Brushes.Black, new PointF(footerX, footerY));

            e.HasMorePages = false;
        }
    }
}
