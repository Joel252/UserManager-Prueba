using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagerPrueba.Data;
using UserManagerPrueba.Models;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // Aplica migraciones automáticamente
        await context.Database.MigrateAsync();

        // Si ya hay usuarios, no hacer nada
        if (context.Users.Any()) return;

        // Crea usuarios de ejemplo
        var users = new List<ApplicationUser>
        {
            new ApplicationUser { FullName = "Juan Pérez", Email = "juan@example.com", UserName = "juan@example.com" },
            new ApplicationUser { FullName = "María López", Email = "maria@example.com", UserName = "maria@example.com" }
        };

        foreach (var user in users)
        {
            await userManager.CreateAsync(user, "Demo123!");
        }
    }
}
