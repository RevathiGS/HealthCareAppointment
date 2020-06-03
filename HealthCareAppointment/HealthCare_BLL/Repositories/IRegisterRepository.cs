using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthCareAppointment.HealthCare_BLL.AccountModels;

namespace HealthCareAppointment.HealthCare_BLL.Repositories
{
    public interface IRegisterRepository : IRepository<UserRegisters>
    {
        IEnumerable<UserRegisters> GetRegisters(int Id);

        UserRegisters ValidateLoginUsers(UserRegisters UserLoginDetails);
    }
}