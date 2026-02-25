
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

    }
}
