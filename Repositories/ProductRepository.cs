using EComputek.Data;
using EComputek.Models;

namespace EComputek.Repositories
{
    public class ProductRepository:IProductRepository
    {

        private readonly ApplicationDBContext db;

        public ProductRepository(ApplicationDBContext db)
        {
            this.db = db;
        }

        public int AddProduct(Product prod)
        {
            int result = 0;
            db.Products.Add(prod);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteProductById(Product prod)
        {
            int result = 0;
            var res = db.Products.Where(x => x.Productid == prod.Productid).SingleOrDefault();

            if (res != null)
            {
                db.Products.Remove(res);
                result = db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            var res = (from p in db.Products
                       join c in db.Categories on p.categoryid equals c.categoryid
                       select new Product
                       {
                           Productid = p.Productid,
                           Name = p.Name,
                           Description = p.Description,
                           categoryid = p.categoryid,
                           name = c.name,
                           Price = p.Price,
                           Imageurl = p.Imageurl,
                           StockQuantity = p.StockQuantity
                       }).ToList();
            return res;
        }

        public Product GetProductById(int id)
        {
            var res = (from p in db.Products
                       join c in db.Categories on p.categoryid equals c.categoryid
                       where p.Productid == id
                       select new Product
                       {
                           Productid = p.Productid,
                           Name = p.Name,
                           Description = p.Description,
                           categoryid = p.categoryid,
                           name = c.name,
                           Price = p.Price,
                           Imageurl = p.Imageurl,
                           StockQuantity = p.StockQuantity
                       }).FirstOrDefault();
            return res;
        }

        public Product GetProductByName(string name)
        {
            var res = (from p in db.Products
                       join c in db.Categories on p.categoryid equals c.categoryid
                       where p.Name == name
                       select new Product
                       {

                           Productid = p.Productid,
                           Name = p.Name,
                           Description = p.Description,
                           categoryid = p.categoryid,
                           name = c.name,
                           Price = p.Price,
                           Imageurl = p.Imageurl,
                           StockQuantity = p.StockQuantity
                       }).FirstOrDefault();
            return res;
        }

        public int UpdateProduct(Product prod)
        {
            int result = 0;
            var res = db.Products.Where(x => x.Productid == prod.Productid).SingleOrDefault();

            if (res != null)
            {
                res.Name = prod.Name;
                res.Description = prod.Description;
                res.categoryid = prod.categoryid;
               res.Price = prod.Price;
                res.Imageurl = prod.Imageurl;
                res.StockQuantity = prod.StockQuantity;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
