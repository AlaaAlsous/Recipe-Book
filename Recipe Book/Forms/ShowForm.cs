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
    }
}
