using EComputek.Models;
using EComputek.Repositories;

namespace EComputek.Services
{
    public class ProductService:IProductService 
    {

        private readonly IProductRepository repo;

        public ProductService(IProductRepository repo)
        {
            this.repo = repo;
        }

        public int AddProduct(Product prod)
        {
            return repo.AddProduct(prod);
        }

        public int DeleteProductById(Product prod)
        {
            return repo.DeleteProductById(prod);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return repo.GetAllProduct();
        }

        public Product GetProductById(int id)
        {
            return repo.GetProductById(id);
        }

        public Product GetProductByName(string name)
        {
            return repo.GetProductByName(name);
        }

        public int UpdateProduct(Product prod)
        {
            return repo.UpdateProduct(prod);
        }
    }
}
