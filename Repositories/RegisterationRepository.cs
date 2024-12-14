using EComputek.Data;
using EComputek.Models;

namespace EComputek.Repositories
{
    public class RegisterationRepository:IRegisterationRepository
    {
        private readonly ApplicationDBContext db;

        public RegisterationRepository(ApplicationDBContext db)
        {
            this.db = db;
        }

        public int AddUser(Registeration user)
        {
            int result = 0;
            db.Registrations.Add(user);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteUser(int id)
        {

            int result = 0;
            var res = db.Registrations.Where(x => x.Userid == id).FirstOrDefault();
            if (res != null)
            {
                db.Registrations.Remove(res);
                result = db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Registeration> GetAllUser()
        {
            return db.Registrations.ToList();
        }

        public Registeration GetById(int id)
        {
            return db.Registrations.Where(x => x.Userid == id).SingleOrDefault();
        }

        public Registeration Login(string email, string password)
        {
            return db.Registrations.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }

        public int UpdateUser(Registeration user)
        {
            int result = 0;
            var res = db.Registrations.Where(x => x.Userid == user.Userid).FirstOrDefault();
            if (res != null)
            {
                res.Userid = user.Userid;
                res.Firstname = user.Firstname;
                res.Lastname = user.Lastname;
                res.PhoneNumber = user.PhoneNumber;
                res.Address = user.Address;
                res.Email = user.Email;
                res.Password = user.Password;
                res.roleid = user.roleid;

                result = db.SaveChanges();
            }
            return result;
        }
    }
}
