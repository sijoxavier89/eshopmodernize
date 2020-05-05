using eShopLegacyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopLegacyMVC.Services
{
   public  interface ICatalogApiService
    {
        CatalogItem FindCatalogItem(int? id);
    }
}
