using DatingApplication.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DatingApplication.Server.IService
{
    public interface IDatingAppUserService
    {
        DatingAppUser Save(DatingAppUser oDatingAppUser);
        DatingAppUser GetSavedDatingUser();
    }
}
