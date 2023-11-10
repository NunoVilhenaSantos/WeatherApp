// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private ICustomerRepository _customers;
    private IOrdersRepository _orders;
    private IProductRepository _products;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public ICustomerRepository Customers
    {
        get
        {
            _customers ??= new CustomerRepository(_context);

            return _customers;
        }
    }

    public IProductRepository Products
    {
        get
        {
            _products ??= new ProductRepository(_context);

            return _products;
        }
    }

    public IOrdersRepository Orders
    {
        get
        {
            _orders ??= new OrdersRepository(_context);

            return _orders;
        }
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}