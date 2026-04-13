using System.Collections.Generic;
using MPIF.Application.Interfaces;
using MPIF.Contracts;
using MPIF.Domain;

namespace MPIF.Application
{
    public class ModuleAppService
    {
        private readonly IPermissionRepository _permRepo;
        private readonly IModuleLoader _loader;

        public ModuleAppService(IPermissionRepository permRepo, IModuleLoader loader)
        {
            _permRepo = permRepo;
            _loader = loader;
        }

        // 對外只回傳 List<IModule>，SubModule 只在內部流通
        public List<IModule> GetAuthorizedModules(string userID, IUserContext context)
        {
            List<SubModule> authorizedModules = _permRepo.GetAuthorizedModules(userID);
            return _loader.LoadModules(authorizedModules, context);
        }
    }
}