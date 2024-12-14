using EComputek.Models;

namespace EComputek.Services
{
    public interface IProductService
    {


        IEnumerable<Product> GetAllProduct();

        Product GetProductById(int id);

        Product GetProductByName(string name);

        int AddProduct(Product prod);


        int UpdateProduct(Product prod);

        int DeleteProductById(Product prod);
    }
}
