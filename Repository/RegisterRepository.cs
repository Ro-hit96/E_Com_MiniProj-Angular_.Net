using E_ComMIniProj.Data;
using E_ComMIniProj.Model;
using Microsoft.EntityFrameworkCore;

namespace E_ComMIniProj.Repository
{
    // Implementing the IRegisterRepository interface
    public class RegisterRepository : IRegisterRepository
    {
        // Declaring a private readonly field for the application database context
        private readonly ApplicationDbContext db;

        public RegisterRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Register> GetLogin(Register r)
        {
            var result = await db.registers
                .Where(x => x.email == r.email && x.password == r.password)
                .FirstOrDefaultAsync();

            return result;
        }


        public async Task<int> Registration(Register r)
        {
            r.roleid = 2; // Assuming a default role ID for registration
            db.registers.Add(r);
            int result = await db.SaveChangesAsync();
            return result;
        }
    }
}
