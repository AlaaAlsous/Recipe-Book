using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
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
            var sqlServerConnectionString =
                Environment.GetEnvironmentVariable("RECIPE_BOOK_SQLSERVER");

            if (!string.IsNullOrWhiteSpace(sqlServerConnectionString))
            {
                Console.WriteLine("Database provider: SQL Server (RECIPE_BOOK_SQLSERVER is set).");
                services.AddDbContext<RecipeDbContext>(options =>
                    options.UseSqlServer(sqlServerConnectionString));
            }
            else
            {
                Console.WriteLine("Database provider: SQLite (RECIPE_BOOK_SQLSERVER is not set).");
                string dataDirectory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Recipe Book");
                Directory.CreateDirectory(dataDirectory);

                string sqliteConnectionString = new Microsoft.Data.Sqlite.SqliteConnectionStringBuilder
                {
                    DataSource = Path.Combine(dataDirectory, "Recipe-Book.sqlite")
                }.ToString();

                services.AddDbContext<RecipeDbContext>(options =>
                    options.UseSqlite(sqliteConnectionString));
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
    }
}
