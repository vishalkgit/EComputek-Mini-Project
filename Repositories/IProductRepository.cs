using EComputek.Models;

namespace EComputek.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct();

        Product GetProductById(int id);

        Product GetProductByName(string name);

        int AddProduct(Product prod);


        int UpdateProduct(Product prod);

        int DeleteProductById(Product prod);

    }
}
