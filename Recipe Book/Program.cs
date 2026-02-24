using Microsoft.Extensions.DependencyInjection;
using Recipe_Book.Data;
using Recipe_Book.Services;

namespace Recipe_Book
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            services.AddDbContext<RecipeDbContext>();
            services.AddScoped<RecipeService>();
            services.AddTransient<MainForm>();

            var serviceProvider = services.BuildServiceProvider();

            try
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<RecipeDbContext>();
                    context.Database.EnsureCreated();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Det gick inte att skapa databasen:\n{ex.Message}", "Fel vid databas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }
    }
}
