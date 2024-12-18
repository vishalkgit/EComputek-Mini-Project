using EComputek.Models;

namespace EComputek.Services
{
    public interface ICartService
    {
        public IEnumerable<Cart> GetCarts();
        public IEnumerable<Cart> GetCartById(int id);

        public int AddtoCart(Cart cart);

        public int Update(Cart cart);

        public int Delete(int id);

        public int DeleteAll(IEnumerable<Cart> carts);
        public int savedb();

    }
}
