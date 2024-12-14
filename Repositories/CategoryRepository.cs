using EComputek.Data;
using EComputek.Models;

namespace EComputek.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ApplicationDBContext db;

        public CategoryRepository(ApplicationDBContext db)
        {
            this.db = db;
        }

        public int AddCategory(Category cat)
        {
            int result = 0;
            db.Categories?.Add(cat);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteCategory(int id)
        {
            int result = 0;
            var c = db.Categories.Where(x => x.categoryid == id).SingleOrDefault();
            if (c != null)
            {
                db.Categories.Remove(c);
                result = db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories.Where(x => x.categoryid == id).SingleOrDefault();
        }

        public int UpdateCategory(Category cat)
        {
            int result = 0;
            var c = db.Categories.Where(x => x.categoryid == cat.categoryid).SingleOrDefault();
            if (c != null)
            {
                c.name = cat.name;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
