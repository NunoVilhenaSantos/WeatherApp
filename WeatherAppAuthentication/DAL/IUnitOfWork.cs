// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using DAL.Repositories.Interfaces;

namespace DAL;

public interface IUnitOfWork
{
    ICustomerRepository Customers { get; }
    IProductRepository Products { get; }
    IOrdersRepository Orders { get; }

    int SaveChanges();
}