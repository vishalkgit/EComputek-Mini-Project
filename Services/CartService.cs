using EComputek.Models;
using EComputek.Repositories;

namespace EComputek.Services
{
    public class CartService:ICartService
    {
        private readonly ICartRepository repo;

        public CartService(ICartRepository repo)
        {
            this.repo = repo;
        }

        public int AddtoCart(Cart cart)
        {
            return repo.AddtoCart(cart);
        }

        public int Delete(int id)
        {
            return repo.Delete(id);
        }

        public int DeleteAll(IEnumerable<Cart> carts)
        {
            return repo.DeleteAll(carts);
        }

        public IEnumerable<Cart> GetCartById(int id)
        {
            return repo.GetCartById(id);
        }

        public IEnumerable<Cart> GetCarts()
        {
            return repo.GetCarts();
        }

        public int savedb()
        {
            return repo.savedb();
        }

        public int Update(Cart cart)
        {
            return repo.Update(cart);
        }
    }
}
