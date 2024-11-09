using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CepediFullStack.Infrastructure.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private static readonly string _appSettingsPath = "CepediFullStack.Presentation\\appsettings.json";
        public AppDbContext CreateDbContext(string[] args)
        {
             // Start from the current directory
            var currentDirectory = Directory.GetCurrentDirectory();

            // Traverse up until we find the appsettings.json or reach the system root
            while (currentDirectory != null && !File.Exists(Path.Combine(currentDirectory, _appSettingsPath)))
            {
                var parentDirectory = Directory.GetParent(currentDirectory);
                if (parentDirectory is null) break; // Stop if we've reached the system root
                currentDirectory = parentDirectory.FullName;
            }

            if (currentDirectory is null)
                throw new InvalidOperationException("Could not locate the appsettings.json file within the project structure.");
            

            var appSettingsFullPath = Path.Combine(currentDirectory, _appSettingsPath);
            Console.WriteLine(appSettingsFullPath);
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile(appSettingsFullPath, optional: false, reloadOnChange: true)
                .Build();
            
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("Sqlite");

            optionsBuilder.UseSqlite(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}