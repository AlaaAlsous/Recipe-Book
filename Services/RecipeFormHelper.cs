using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Reflection;
using System.Windows.Forms;
using Recipe_Book.Data;
using Recipe_Book.Models;

namespace Recipe_Book.Services
{
    internal static class RecipeFormHelper
    {
        public static void AddIngredient(List<(string ingredientName, decimal quantity, string unit)> ingredients,
            TextBox txtIngName, TextBox txtIngQuantity, TextBox txtIngUnit, DataGridView grid)
        {
            var name = txtIngName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Ingredient name is required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ingredients.Exists(i => string.Equals(i.ingredientName, name, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("An ingredient with that name has already been added.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIngName.Focus();
                return;
            }

            decimal qty = 0m;
            if (!string.IsNullOrWhiteSpace(txtIngQuantity.Text))
            {
                if (!decimal.TryParse(txtIngQuantity.Text.Trim(), out qty))
                {
                    MessageBox.Show("Invalid quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var unit = !string.IsNullOrWhiteSpace(txtIngUnit.Text) ? txtIngUnit.Text.Trim() : "Unit";

            ingredients.Add((name, qty, unit));
            UpdateIngredientGrid(ingredients, grid);

            txtIngName.Clear();
            txtIngQuantity.Clear();
            txtIngUnit.Clear();
            txtIngName.Focus();
        }

        public static void UpdateIngredientGrid(List<(string ingredientName, decimal quantity, string unit)> ingredients, DataGridView grid)
        {
            grid.Rows.Clear();
            foreach (var ing in ingredients)
            {
                grid.Rows.Add(ing.ingredientName, ing.quantity, ing.unit);
            }
        }

        public static void RemoveSelectedIngredient(List<(string ingredientName, decimal quantity, string unit)> ingredients, DataGridView grid)
        {
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an ingredient to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idx = grid.SelectedRows[0].Index;
            if (idx >= 0 && idx < ingredients.Count)
            {
                ingredients.RemoveAt(idx);
                UpdateIngredientGrid(ingredients, grid);
            }
        }

        public static bool TryParseCategories(string? categoriesText, IWin32Window owner, out List<string> categoryList)
        {
            categoryList = new List<string>();
            if (string.IsNullOrWhiteSpace(categoriesText))
                return true;

            var parts = categoriesText.Split(',').Select(c => c.Trim()).ToList();
            if (parts.Any(string.IsNullOrEmpty))
            {
                MessageBox.Show(owner, "Invalid category entry.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (parts.Distinct(StringComparer.OrdinalIgnoreCase).Count() != parts.Count)
            {
                MessageBox.Show(owner, "Duplicate categories entered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (var c in parts)
            {
                if (!string.IsNullOrEmpty(c))
                    categoryList.Add(c);
            }

            return true;
        }

        public static bool HasIngredients(List<(string ingredientName, decimal quantity, string unit)> ingredients, IWin32Window owner)
        {
            if (ingredients == null || ingredients.Count == 0)
            {
                MessageBox.Show(owner, "No ingredients added.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public static async Task<bool> SaveNewRecipeAsync(RecipeService service, string name, string? description, string? instructions, List<(string ingredientName, decimal quantity, string unit)> ingredients, List<string> categoryList, IWin32Window owner)
        {
            try
            {
                if (await service.RecipeExistsAsync(name))
                {
                    MessageBox.Show(owner, "A recipe with that name already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                await service.AddRecipeAsync(name, description, instructions, ingredients, categoryList);
                MessageBox.Show(owner, "Recipe saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner, $"Could not save recipe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static async Task<bool> UpdateRecipeAsync(RecipeService service, int recipeId, string name, string? description, string? instructions, List<(string ingredientName, decimal quantity, string unit)> ingredients, List<string> categoryList, IWin32Window owner)
        {
            try
            {
                var existing = await service.GetRecipeByIdAsync(recipeId);
                if (existing == null)
                {
                    MessageBox.Show(owner, "Recipe not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!string.Equals(existing.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    if (await service.RecipeExistsAsync(name))
                    {
                        MessageBox.Show(owner, "A recipe with that name already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                await service.UpdateRecipeAsync(recipeId, name, description, instructions, ingredients, categoryList);
                MessageBox.Show(owner, "Recipe updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner, $"Could not update recipe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void TextBoxWithCounter_TextChanged(Form form, object? sender, EventArgs e, ErrorProvider errorProvider)
        {
            if (sender is not TextBox tb)
                return;

            var name = tb.Name;
            if (string.IsNullOrEmpty(name) || !name.StartsWith("txt"))
                return;

            var core = name.Substring(3);
            var lblName = $"lbl{core}Count";

            var fi = form.GetType().GetField(lblName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var lbl = fi?.GetValue(form) as Label;

            int len = tb.Text.Length;
            int max = tb.MaxLength;

            if (lbl != null)
                lbl.Text = max > 0 ? $"{len}/{max}" : len.ToString();

            if (max > 0 && len >= max)
                errorProvider.SetError(tb, $"Maximum length reached ({max} characters).\n");
            else
                errorProvider.SetError(tb, "");
        }
    }
}
