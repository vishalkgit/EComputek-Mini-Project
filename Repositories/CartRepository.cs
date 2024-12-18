using EComputek.Data;
using EComputek.Models;

namespace EComputek.Repositories
{
    public class CartRepository:ICartRepository
    {

        private readonly ApplicationDBContext db;

        public CartRepository(ApplicationDBContext db)
        {
            this.db = db;   
        }

        public int AddtoCart(Cart cart)
        {
            int result = 0;
            db.Carts.Add(cart);
            result = db.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            int result = 0;
            var res = db.Carts.Where(x => x.Cartid == id).SingleOrDefault();
            if (res != null)
            {
                db.Carts.Remove(res);
                result = db.SaveChanges();
            }
            return result;
        }

        public int DeleteAll(IEnumerable<Cart> carts)
        {
            int result = 0;
            db.Carts.RemoveRange(carts);
            result = db.SaveChanges();
            return result;
        }

        public IEnumerable<Cart> GetCartById(int id)
        {
            var res = from c in db.Carts
                      join u in db.Registerations on c.Userid equals u.Userid
                      join p in db.Products
                      on c.Productid equals p.Productid
                      where c.Userid == id
                      select new Cart
                      {
                          Cartid = c.Cartid,
                          Userid = c.Userid,
                          Productid = c.Productid,
                          Quantity = c.Quantity,
                          Price = p.Price,
                          Name = p.Name,
                          Imageurl = p.Imageurl,
                          Total = p.Price * c.Quantity
                      };
            return res;
        }

        public IEnumerable<Cart> GetCarts()
        {
            var res = from c in db.Carts
                      join u in db.Registerations on c.Userid equals u.Userid
                      join p in db.Products
                      on c.Productid equals p.Productid
                      select new Cart
                      {
                          Cartid = c.Cartid,
                          Userid = c.Userid,
                          Productid = c.Productid,
                          Quantity = c.Quantity,
                          Price = p.Price,
                          Imageurl = p.Imageurl,
                          Total = p.Price * c.Quantity,
                          Name = p.Name
                      };
            return res;
        }

        public int savedb()
        {
            return db.SaveChanges();
        }

        public int Update(Cart cart)
        {
            int result = 0;

            var res = db.Carts.Where(x => x.Userid == cart.Userid).SingleOrDefault();

            if (res != null)
            {
                res.Productid = cart.Productid;
                res.Userid = cart.Userid;
                res.Quantity = cart.Quantity;

                result = db.SaveChanges();
            }
            return result;
        }
    }
}
