﻿// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using System;
using System.Collections.Generic;

namespace DAL.Models;

public class Product : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public decimal BuyingPrice { get; set; }
    public decimal SellingPrice { get; set; }
    public int UnitsInStock { get; set; }
    public bool IsActive { get; set; }
    public bool IsDiscontinued { get; set; }


    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }


    public int? ParentId { get; set; }
    public Product? Parent { get; set; }


    public int ProductCategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; }

    public ICollection<Product>? Children { get; set; }
    public ICollection<OrderDetail>? OrderDetails { get; set; }
}