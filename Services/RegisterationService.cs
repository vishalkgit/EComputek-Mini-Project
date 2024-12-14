using EComputek.Models;
using EComputek.Repositories;

namespace EComputek.Services
{
    public class RegisterationService:IRegisterationService
    {

        private readonly IRegisterationRepository repo;

        public RegisterationService(IRegisterationRepository repo)
        {
            this.repo = repo;
        }

        public int AddUser(Registeration user)
        {
            return repo.AddUser(user);
        }

        public int DeleteUser(int id)
        {
            return repo.DeleteUser(id);
        }

        public IEnumerable<Registeration> GetAllUser()
        {
            return repo.GetAllUser();
        }

        public Registeration GetById(int id)
        {
            return repo.GetById(id);
        }

        public Registeration Login(string email, string password)
        {
            return repo.Login(email, password);
        }

        public int UpdateUser(Registeration user)
        {
            return repo.UpdateUser(user);
        }
    }
}
