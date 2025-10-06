using Microsoft.EntityFrameworkCore;
using IctApp.Data;
using Microsoft.AspNetCore.Identity;
using IctApp.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configure Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Configure Razor Pages and Authorization
builder.Services.AddRazorPages(options =>
{
    // Secure the Admin area
    options.Conventions.AuthorizeAreaFolder("Admin", "/");
});

var app = builder.Build();

// 2. Seed Admin User, Roles, and App Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Apply migrations to create the database if it doesn't exist
        await context.Database.MigrateAsync();

        // Seed Identity Data (Admin Role and User)
        await SeedIdentityData(userManager, roleManager, logger);

        // Seed App Data (Units, Lessons, etc.) from DbInitializer
        DbInitializer.Initialize(context);

        logger.LogInformation("Database seeding process completed.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

async Task SeedIdentityData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<Program> logger)
{
    string adminRole = "Admin";
    string adminEmail = "admin@example.com";
    string adminPassword = "Admin@123";

    // Ensure Admin role exists
    if (!await roleManager.RoleExistsAsync(adminRole))
    {
        await roleManager.CreateAsync(new IdentityRole(adminRole));
        logger.LogInformation("'{role}' role created.", adminRole);
    }

    // Ensure Admin user exists
    if (await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var user = new ApplicationUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
        var result = await userManager.CreateAsync(user, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, adminRole);
            logger.LogInformation("Admin user '{email}' created and assigned to '{role}' role.", adminEmail, adminRole);
        }
        else
        {
            foreach (var error in result.Errors)
            {
                logger.LogError("Error creating admin user: {error}", error.Description);
            }
        }
    }
}


// 3. Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// These must be in this order
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

