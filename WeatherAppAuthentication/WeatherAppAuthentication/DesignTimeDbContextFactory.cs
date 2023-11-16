// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using System.IO;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WeatherAppAuthentication;

public class DesignTimeDbContextFactory :
    IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", true)
            .Build();

        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

        // builder.UseSqlServer(
        //     configuration["ConnectionStrings:DefaultConnection"],
        //     b => b.MigrationsAssembly("WeatherAppAuthentication"));

        builder.UseMySQL(
            configuration["ConnectionStrings:MySQL-Local"],
            b => b.MigrationsAssembly("WeatherAppAuthentication"));


        builder.UseOpenIddict();


        return new ApplicationDbContext(builder.Options);
    }
}