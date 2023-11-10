// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context) : base(context)
    {
    }

    private ApplicationDbContext AppContext => (ApplicationDbContext) Context;

    public IEnumerable<Customer> GetTopActiveCustomers(int count)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Customer> GetAllCustomersData()
    {
        return AppContext.Customers
            .Include(c => c.Orders).ThenInclude(o => o.OrderDetails)
            .ThenInclude(d => d.Product)
            .Include(c => c.Orders).ThenInclude(o => o.Cashier)
            .AsSingleQuery()
            .OrderBy(c => c.Name)
            .ToList();
    }
}