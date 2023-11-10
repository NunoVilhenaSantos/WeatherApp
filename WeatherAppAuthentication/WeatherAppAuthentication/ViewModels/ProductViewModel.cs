// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using System;

namespace WeatherAppAuthentication.ViewModels;

public class ProductViewModel
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
    public string ProductCategoryName { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}