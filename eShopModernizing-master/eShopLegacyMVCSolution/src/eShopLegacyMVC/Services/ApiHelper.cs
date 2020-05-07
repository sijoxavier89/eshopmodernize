using eShopLegacyMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace eShopLegacyMVC.Services
{
    public class ApiHelper
    {

       readonly bool isContainer = bool.Parse(ConfigurationManager.AppSettings["IsContainer"]);
       readonly string containerHost = ConfigurationManager.AppSettings["ContainerHost"];
       readonly string localHost = ConfigurationManager.AppSettings["LocalHost"];


        public ApiHelper()
        {
           
        }

        public CatalogItem FindCatalogItem(int? id)
        {
            CatalogItem catalogItem = null;

            try
            {
              


                using (var client = new HttpClient())
                {
                    if(isContainer)
                    {
                        client.BaseAddress = new Uri(containerHost);
                    }
                    else {
                        client.BaseAddress = new Uri(localHost);
                    }
                   
                    //HTTP GET
                    var responseTask = client.GetAsync("api/values/"+id);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<CatalogItem>();
                        readTask.Wait();

                        catalogItem = readTask.Result;
                    }
                   
                }
            }
            catch(HttpException hex)
            {
                throw hex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return catalogItem;
        }
    }
}