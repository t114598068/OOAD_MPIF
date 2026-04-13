using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPIF.Contracts;
using MPIF.Domain;

namespace MPIF.Application.Interfaces
{
    public interface IModuleLoader
    {
        List<IModule> LoadModules(List<SubModule> authorizedModules, IUserContext context);
    }
}
