using EComputek.Models;

namespace EComputek.Repositories
{
    public interface IRegisterationRepository
    {
        IEnumerable<Registeration> GetAllUser();

        public Registeration GetById(int id);

        public int AddUser(Registeration user);

        public Registeration Login(string email, string password);

        public int DeleteUser(int id);

        public int UpdateUser(Registeration user);

    }
}
