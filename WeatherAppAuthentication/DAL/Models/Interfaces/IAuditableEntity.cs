// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using System;

namespace DAL.Models.Interfaces;

public interface IAuditableEntity
{
    string CreatedBy { get; set; }

    string UpdatedBy { get; set; }


    DateTime CreatedDate { get; set; }

    DateTime UpdatedDate { get; set; }
}