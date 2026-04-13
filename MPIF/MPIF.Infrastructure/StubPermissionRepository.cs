using System.Collections.Generic;
using MPIF.Application.Interfaces;
using MPIF.Domain;

namespace MPIF.Infrastructure
{
    /// <summary>
    /// Stub 實作：在真實 DB 完成前，用硬寫資料讓流程可以跑通。
    /// 
    /// 換成真實 PermissionRepository 時，只需新增一個實作 IPermissionRepository 的類別，
    /// 並在 Composition Root（MainShell）換掉注入的實例，其他地方完全不動。
    /// 
    /// AssemblyPath 已改為相對路徑，部署時請確認工作目錄正確，
    /// 或改從 appsettings / 設定檔注入路徑。
    /// </summary>
    public class StubPermissionRepository : IPermissionRepository
    {
        public List<SubModule> GetAuthorizedModules(string userID)
        {
            // TODO：實際實作時，在此依 userID 查詢 User 所屬 Group，
            //        再呼叫 group.GetEffectiveModules() 取得含繼承的清單。
            return new List<SubModule>
            {
                new SubModule
                {
                    ModuleID     = "MOD-001",
                    ModuleName   = "財務模組",
                    AssemblyPath = @"C:\Users\kazarin\Pictures\MPIFModule\FinanceModule\FinanceModule\bin\Debug\FinanceModule.exe",
                    EntryForm    = "FinanceModule.EntryForm",
                    Version      = "1.0.0"
                }
            };
        }
    }
}