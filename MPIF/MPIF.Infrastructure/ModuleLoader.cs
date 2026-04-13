using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using MPIF.Contracts;
using MPIF.Domain;
using MPIF.Application.Interfaces;

namespace MPIF.Infrastructure
{
    public class ModuleLoader : IModuleLoader
    {
        public List<IModule> LoadModules(List<SubModule> authorizedModules, IUserContext context)
        {
            var result = new List<IModule>();

            foreach (var moduleInfo in authorizedModules)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(moduleInfo.AssemblyPath);
                    var type = assembly.GetType(moduleInfo.EntryForm);
                    if (type == null)
                        throw new Exception($"{moduleInfo.ModuleName} 找不到 EntryForm：{moduleInfo.EntryForm}");

                    var instance = (IModule)Activator.CreateInstance(type);
                    instance.Initialize(context);
                    result.Add(instance);
                }
                catch (Exception ex)
                {
                    // NFR：子模組崩潰不影響主程式，記錄 log 後繼續
                    // SystemLog.Write($"Failed to load {moduleInfo.ModuleName}: {ex.Message}");
                }
            }

            return result;
        }
    }
}