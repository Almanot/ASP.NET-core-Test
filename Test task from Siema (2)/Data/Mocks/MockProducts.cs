using Test_task_from_Siema__2_.Data.Interfaces;
using Test_task_from_Siema__2_.Data.Models;

namespace Test_task_from_Siema__2_.Data.Mocks
{
    public class MockProducts : IProducts
    {

        List<Product> productList = new List<Product>();
        public void AddProduct(Product product)
        {
            productList.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return productList;
        }

        public void RemoveProduct(Product product)
        {
            productList.Remove(product);
        }
    }
}
