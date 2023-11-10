// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using System.Collections.Generic;
using DAL.Models;

namespace DAL.Repositories.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    IEnumerable<Customer> GetTopActiveCustomers(int count);
    IEnumerable<Customer> GetAllCustomersData();
}