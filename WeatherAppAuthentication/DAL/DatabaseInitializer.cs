// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DAL.Core;
using DAL.Core.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DAL;


public interface IDatabaseInitializer
{
    Task SeedAsync();
}


public class DatabaseInitializer : IDatabaseInitializer
{
    // Default password for all users
    public const string DefaultPassword = "Passw0rd=";

    // Default user names
    private readonly IAccountManager _accountManager;

    // data contexts
    // private readonly ApplicationDbContext _dataContextSqLite;
    // private readonly ApplicationDbContext _dataContextMsSql;
    // private readonly ApplicationDbContext _dataContextMySql;
    private readonly ApplicationDbContext _context;

    // logger
    private readonly ILogger _logger;


    public DatabaseInitializer(
        ApplicationDbContext context,
        IAccountManager accountManager,
        ILogger<DatabaseInitializer> logger)
    {
        _accountManager = accountManager;
        _context = context;
        _logger = logger;
    }


    public async Task SeedAsync()
    {
        // ------------------------------------------------------------------ //
        // initialize SeedDb Databases before been used
        // ------------------------------------------------------------------ //
        await SeedDbMigrateDatabasesAsync();


        // ------------------------------------------------------------------ //
        // initialize SeedDb Databases before been used
        // ------------------------------------------------------------------ //
        await SeedDbGenerateCreateScript();

        Console.WriteLine("Debug zone");
        // PrintDebugInformation();

        // -------------------------------------------------------------- //


        await _context.Database.MigrateAsync().ConfigureAwait(false);


        await SeedDefaultUsersAsync();
        await SeedDemoDataAsync();
    }


    private async Task SeedDefaultUsersAsync()
    {
        if (!await _context.Users.AnyAsync())
        {
            _logger.LogInformation("Generating inbuilt accounts");

            const string adminRoleName = "administrator";
            const string userRoleName = "user";

            await EnsureRoleAsync(adminRoleName, "Default administrator",
                ApplicationPermissions.GetAllPermissionValues());

            await EnsureRoleAsync(userRoleName, "Default user",
                new string[] { });

            await CreateUserAsync("admin", "tempP@ss123",
                "Inbuilt Administrator", "admin@ebenmonney.com",
                "+1 (123) 000-0000", new[] {adminRoleName});

            await CreateUserAsync("user", "tempP@ss123",
                "Inbuilt Standard User", "user@ebenmonney.com",
                "+1 (123) 000-0001", new[] {userRoleName});

            _logger.LogInformation("Inbuilt account generation completed");
        }
    }


    private async Task EnsureRoleAsync(
        string roleName, string description, string[] claims)
    {
        if (await _accountManager
                .GetRoleByNameAsync(roleName)
                .ConfigureAwait(false) == null)
        {
            _logger.LogInformation($"Generating default role: {roleName}");

            var applicationRole = new ApplicationRole(roleName, description);

            var result =
                await _accountManager.CreateRoleAsync(applicationRole, claims);

            if (!result.Succeeded)
                throw new Exception(
                    $"Seeding \"{description}\" role failed." +
                    $" Errors: {string.Join(Environment.NewLine, result.Errors)}");
        }
    }


    private async Task<ApplicationUser> CreateUserAsync(
        string userName, string password, string fullName, string email,
        string phoneNumber, string[] roles)
    {
        _logger.LogInformation($"Generating default user: {userName}");

        var applicationUser = new ApplicationUser
        {
            UserName = userName,
            FullName = fullName,
            Email = email,
            PhoneNumber = phoneNumber,
            EmailConfirmed = true,
            IsEnabled = true
        };

        var result =
            await _accountManager.CreateUserAsync(applicationUser, roles,
                password);

        if (!result.Succeeded)
            throw new Exception(
                $"Seeding \"{userName}\" user failed. " +
                $"Errors: {string.Join(Environment.NewLine, result.Errors)}");

        return applicationUser;
    }


    private async Task SeedDemoDataAsync()
    {
        if (!await _context.Customers.AnyAsync() &&
            !await _context.ProductCategories.AnyAsync())
        {
            _logger.LogInformation("Seeding demo data");

            var cust1 = new Customer
            {
                Name = "Ebenezer Monney",
                Email = "contact@ebenmonney.com",
                Gender = Gender.Male,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            var cust2 = new Customer
            {
                Name = "Itachi Uchiha",
                Email = "uchiha@narutoverse.com",
                PhoneNumber = "+81123456789",
                Address = "Some fictional Address, Street 123, Konoha",
                City = "Konoha",
                Gender = Gender.Male,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            var cust3 = new Customer
            {
                Name = "John Doe",
                Email = "johndoe@anonymous.com",
                PhoneNumber = "+18585858",
                Address =
                    """
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio.
                    Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet
                    """,
                City = "Lorem Ipsum",
                Gender = Gender.Male,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            var cust4 = new Customer
            {
                Name = "Jane Doe",
                Email = "Janedoe@anonymous.com",
                PhoneNumber = "+18585858",
                Address =
                    """
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio.
                    Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet
                    """,
                City = "Lorem Ipsum",
                Gender = Gender.Male,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            var prodCat1 = new ProductCategory
            {
                Name = "None",
                Description =
                    "Default category. " +
                    "Products that have not been assigned a category",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            var prod1 = new Product
            {
                Name = "BMW M6",
                Description =
                    "Yet another masterpiece from the world's best car manufacturer",
                BuyingPrice = 109775,
                SellingPrice = 114234,
                UnitsInStock = 12,
                IsActive = true,
                ProductCategory = prodCat1,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            var prod2 = new Product
            {
                Name = "Nissan Patrol",
                Description = "A true man's choice",
                BuyingPrice = 78990,
                SellingPrice = 86990,
                UnitsInStock = 4,
                IsActive = true,
                ProductCategory = prodCat1,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            var order1 = new Order
            {
                Discount = 500,
                Cashier = await _context.Users.OrderBy(u => u.UserName)
                    .FirstAsync(),
                Customer = cust1,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                OrderDetails = new List<OrderDetail>
                {
                    new()
                    {
                        UnitPrice = prod1.SellingPrice, Quantity = 1,
                        Product = prod1
                    },
                    new()
                    {
                        UnitPrice = prod2.SellingPrice, Quantity = 1,
                        Product = prod2
                    }
                }
            };

            var order2 = new Order
            {
                Cashier = await _context.Users.OrderBy(u => u.UserName)
                    .FirstAsync(),
                Customer = cust2,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                OrderDetails = new List<OrderDetail>
                {
                    new()
                    {
                        UnitPrice = prod2.SellingPrice, Quantity = 1,
                        Product = prod2
                    }
                }
            };

            _context.Customers.Add(cust1);
            _context.Customers.Add(cust2);
            _context.Customers.Add(cust3);
            _context.Customers.Add(cust4);

            _context.Products.Add(prod1);
            _context.Products.Add(prod2);

            _context.Orders.Add(order1);
            _context.Orders.Add(order2);

            await _context.SaveChangesAsync();

            _logger.LogInformation("Seeding demo data completed");
        }
    }


    private async Task SeedDbMigrateDatabasesAsync()
    {
        // ------------------------------------------------------------------ //
        // _dataContextInUse = _dataContextMySql;
        // ------------------------------------------------------------------ //

        // ------------------------------------------------------------------ //
        // verify if the database exists and if not create it
        // ------------------------------------------------------------------ //


        try
        {
            // TODO: tem bug sem dar erro no debug
            await _context.Database.MigrateAsync();
            // await _mySqlLocal.Database.MigrateAsync();
            // await _mySqlOnline.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            // Registe a exceção ou faça o tratamento adequado aqui.
            _logger.LogError(ex,
                "Ocorreu um erro durante a migração do banco de dados MySQL.");
            // throw; // Re-lança a exceção para que o programa saiba que algo deu errado.


            //
            await _context.Database.EnsureDeletedAsync();

            // Cria os Migrations ao correr o Seed
            await _context.Database.MigrateAsync();

            // Não cria os Migrations
            await _context.Database.EnsureCreatedAsync();
        }


        try
        {
            // TODO: tem bug sem dar erro no debug
            //await _dataContextSqLite.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            // Registe a exceção ou faça o tratamento adequado aqui.
            _logger.LogError(ex,
                "Ocorreu um erro durante a migração do banco de dados SQLite.");
            // throw; // Re-lança a exceção para que o programa saiba que algo deu errado.

            //
            //await _dataContextSqLite.Database.EnsureDeletedAsync();

            // Cria os Migrations ao correr o Seed
            //await _dataContextSqLite.Database.MigrateAsync();

            // Não cria os Migrations
            //await _dataContextSqLite.Database.EnsureCreatedAsync();
        }


        try
        {
            // TODO: tem bug sem dar erro no debug
            // await _dataContextMsSql.Database.MigrateAsync();
            // await _msSqlLocal.Database.MigrateAsync();
            // await _msSqlOnline.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            // Registe a exceção ou faça o tratamento adequado aqui.
            _logger.LogError(ex,
                "Ocorreu um erro durante a migração do banco de dados MsSQL.");
            // throw; // Re-lança a exceção para que o programa saiba que algo deu errado.


            //
            //await _dataContextMsSql.Database.EnsureDeletedAsync();

            // Cria os Migrations ao correr o Seed
            //await _dataContextMsSql.Database.MigrateAsync();

            // Não cria os Migrations
            //await _dataContextMsSql.Database.EnsureCreatedAsync();
        }


        try
        {
            // TODO: tem bug sem dar erro no debug
            //await _dataContextInUse.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            // Registe a exceção ou faça o tratamento adequado aqui.
            _logger.LogError(ex,
                "Ocorreu um erro durante a migração do banco de dados MySQL.");

            // Re-lança a exceção para que o programa saiba que algo deu errado.
            throw;
        }


        // ------------------------------------------------------------------ //
        // ------------------------------------------------------------------ //
        // ------------------------------------------------------------------ //


        await _context.Database.MigrateAsync();
        await _context.Database.EnsureCreatedAsync();
    }


    private Task SeedDbGenerateCreateScript()
    {
        var directory = ".\\data\\SQL\\";

        Directory.CreateDirectory(directory);


        // ------------------------------------------------------------------ //


        // Gravar o script de criação de banco de dados 1
        //var value1 = _dataContextSqLite.Database.GenerateCreateScript();
        //File.WriteAllText(Path.Join(directory, "create_script_SQLite.sql"), value1);

        // Gravar o script de criação de banco de dados 2
        //var value2 = _dataContextMySql.Database.GenerateCreateScript();
        //File.WriteAllText(Path.Join(directory, "create_script_MySQL.sql"), value2);

        // Gravar o script de criação de banco de dados 3
        //var value3 = _dataContextMsSql.Database.GenerateCreateScript();
        //File.WriteAllText(Path.Join(directory, "create_script_MSSql.sql"), value3);

        // Gravar o script de criação de banco de dados 4
        var value4 = _context.Database.GenerateCreateScript();
        File.WriteAllText(Path.Join(directory, "create_script_MySql.sql"),
            value4);


        // ------------------------------------------------------------------ //

        return Task.CompletedTask;
    }
}