using E_ComMIniProj.Model;

namespace E_ComMIniProj.Service
{
    // Defining the interface named 'IRegisterService' within the 'E_ComMIniProj.Service' namespace
    public interface IRegisterService
    {
        // Declaring method for user registration
        Task<int> Registration(Register r);

        // Declaring method to get user login information
        Task<Register> GetLogin(Register r);
    }
}
