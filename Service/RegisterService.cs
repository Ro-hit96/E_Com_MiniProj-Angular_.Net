using E_ComMIniProj.Model;
using E_ComMIniProj.Repository;

namespace E_ComMIniProj.Service
{
    // Implementing the IRegisterService interface
    public class RegisterService : IRegisterService
    {
        // Declaring a private readonly field for the register repository
        private readonly IRegisterRepository repo;

        // Constructor injecting the register repository
        public RegisterService(IRegisterRepository repo)
        {
            this.repo = repo;
        }

        // Implementing the method to get user login information
        public async Task<Register> GetLogin(Register r)
        {
            return await repo.GetLogin(r);
        }

        // Implementing the method for user registration
        public async Task<int> Registration(Register u)
        {
            return await repo.Registration(u);
        }
    }
}
