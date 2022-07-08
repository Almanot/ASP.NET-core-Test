using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Test_task_from_Siema__2_.Data.Interfaces;
using Test_task_from_Siema__2_.Data.Mocks;
using Test_task_from_Siema__2_.Data.Models;

namespace Test_task_from_Siema__2_.Controllers
{
    public class ProductController : Controller
    {
        IProducts productDB = new MockProducts();
        [HttpGet]
        public ActionResult GetProducts()
        {
            productDB.GetProducts();
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(string productData)
        {
            string productid = Regex.Match(productData, "id=(.+)").Groups[1].Value;
            if (productid == null) productid = Guid.NewGuid().ToString();
            string productName = Regex.Match(productData, "name=(.+)").Groups[1].Value;
            string productDescription = Regex.Match(productData, "descr=(.+)").Groups[1].Value;

            Product product = new Product { Id = Int32.Parse(productid), Name = productName, Description = productDescription };

            productDB.AddProduct(product);
            return View();
        }

        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            List<Product> products = productDB.GetProducts().ToList();
            Product pr = products.Find(x => x.Id == id);
            if (pr != null)
            {
                productDB.RemoveProduct(pr);
            }
            else
            {
                // message "didnt found id"
            }
            return View();
        }
    }
}
