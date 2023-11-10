﻿// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class OrdersRepository : Repository<Order>, IOrdersRepository
{
    public OrdersRepository(DbContext context) : base(context)
    {
    }

    private ApplicationDbContext AppContext => (ApplicationDbContext) Context;
}