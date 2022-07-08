using Test_task_from_Siema__2_.Data.Models;

namespace Test_task_from_Siema__2_.Data.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        void RemoveProduct(Product product);
    }
}
