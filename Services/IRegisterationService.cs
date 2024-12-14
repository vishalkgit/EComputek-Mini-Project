using EComputek.Models;

namespace EComputek.Services
{
    public interface IRegisterationService
    {
        IEnumerable<Registeration> GetAllUser();

        public Registeration GetById(int id);

        public int AddUser(Registeration user);

        public Registeration Login(string email, string password);

        public int DeleteUser(int id);

        public int UpdateUser(Registeration user);
    }
}
