using System;
using System.Collections.Generic;

using MPIF.Domain;

namespace MPIF.Application.Interfaces
{
    public interface IPermissionRepository
    {
        List<SubModule> GetAuthorizedModules(string userID);
    }
}