using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eShopLegacyMVC.Models;

namespace eShopLegacyMVC.Services
{
    public class CatalogApiService : ICatalogApiService
    {
        public CatalogItem FindCatalogItem(int? id)
        {
            ApiHelper aph = new ApiHelper();
            var catalogdetails = aph.FindCatalogItem(id);
            return catalogdetails;
        }
    }
}