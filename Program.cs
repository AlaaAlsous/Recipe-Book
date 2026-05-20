using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
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

            string connectionString =
                "Server=localhost,1433;Database=recipe_book_db;User Id=recipebook;Password=Secret-Recipe-Book-Password!;TrustServerCertificate=True;Encrypt=True;";

            bool dockerAvailable = CanConnectToDockerDb(connectionString);

            if (dockerAvailable)
            {
                services.AddDbContext<RecipeDbContext>(options =>
                    options.UseSqlServer(connectionString));
            }
            else
            {
                services.AddDbContext<RecipeDbContext>(options =>
                    options.UseSqlite("Data Source=Recipe-Book.sqlite"));
            }

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
                MessageBox.Show($"Could not create the database:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }

        private static bool CanConnectToDockerDb(string connectionString)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
