using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HealthCareAppointment.HealthCare_BLL.AccountModels;
using HealthCareAppointment.HealthCare_BLL.Repositories;

namespace HealthCareAppointment.HealthCare_DAL.Repositories
{
    public class RegisterRepository : Repository<UserRegisters>, IRegisterRepository
    {
        public RegisterRepository(ApplicationDbContext context)
            : base(context)
        {
        }
        public IEnumerable<UserRegisters> GetRegisters(int Id)
        {
            return ApplicationDbContext.UserRegisters.Where(n=>n.Id == Id).ToList();
        }

        public UserRegisters ValidateLoginUsers(UserRegisters UserLoginDetails)
        {
            return ApplicationDbContext.UserRegisters.Where(n => n.UserName == UserLoginDetails.UserName && n.Password == UserLoginDetails.Password).FirstOrDefault();
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}