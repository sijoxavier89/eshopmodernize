using eShopLegacyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace eShopLegacyMVC.Services
{
    public class ApiHelper
    {
      


        public ApiHelper()
        {
           
        }

        public CatalogItem FindCatalogItem(int? id)
        {
            CatalogItem catalogItem = null;

            try
            {
                //using (HttpClient client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri("http://localhost:54162/");
                //    client.DefaultRequestHeaders.Accept.Clear();
                //    client.DefaultRequestHeaders.Accept.Add(
                //        new MediaTypeWithQualityHeaderValue("application/json"));
                //    client.Timeout = TimeSpan.FromSeconds(10000);


                //    HttpResponseMessage response = await client.GetAsync("api/values/" + id);

                //    if (response.IsSuccessStatusCode)
                //    {
                //        catalogItem = await response.Content.ReadAsAsync<CatalogItem>();
                //    }
                //}


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54162/");
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