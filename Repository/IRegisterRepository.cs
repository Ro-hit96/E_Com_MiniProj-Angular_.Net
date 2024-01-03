using E_ComMIniProj.Model;

namespace E_ComMIniProj.Repository
{
    // Defining the interface named 'IRegisterRepository' within the 'E_ComMIniProj.Repository' namespace
    public interface IRegisterRepository
    {
        // Declaring method for user registration
        Task<int> Registration(Register r);

        // Declaring method to get user login information
        Task<Register> GetLogin(Register r);
    }
}
