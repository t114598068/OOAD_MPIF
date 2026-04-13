using System.Collections.Generic;
using System.Linq;

namespace MPIF.Domain
{
    /// <summary>
    /// Domain entity：使用者群組，管理所屬子模組的存取權限。
    /// 按照 Information Expert，Group 擁有 PermittedModules，
    /// 因此「判斷是否有某模組權限」的責任歸屬於此類別。
    /// </summary>
    public class Group
    {
        public string GroupID { get; set; }
        public string GroupName { get; set; }

        /// <summary>向上繼承的父群組（null 代表頂層）。</summary>
        public Group Parent { get; set; }

        public List<SubModule> PermittedModules { get; set; } = new List<SubModule>();

        // ── Information Expert ──────────────────────────────────────────────
        // Group 持有 PermittedModules 並知道 Parent，
        // 因此由 Group 自己負責回答「是否有某模組的存取權」。
        // 使用遞迴向上查找，支援群組繼承鏈。

        /// <summary>
        /// 判斷此群組（或其任一祖先群組）是否允許存取指定模組。
        /// </summary>
        public bool HasPermission(string moduleID)
        {
            // 先查自己
            if (PermittedModules.Any(m => m.ModuleID == moduleID))
                return true;

            // 再遞迴查父群組（支援繼承鏈）
            return Parent?.HasPermission(moduleID) ?? false;
        }

        /// <summary>
        /// 取得此群組（含所有祖先）合併後的授權模組清單（去重複）。
        /// Repository 可呼叫此方法，而不需要自行處理繼承邏輯。
        /// </summary>
        public IEnumerable<SubModule> GetEffectiveModules()
        {
            var result = new Dictionary<string, SubModule>();

            // 先收集祖先的（父層優先），再讓子層覆蓋
            foreach (var m in Parent?.GetEffectiveModules() ?? Enumerable.Empty<SubModule>())
                result[m.ModuleID] = m;

            foreach (var m in PermittedModules)
                result[m.ModuleID] = m;

            return result.Values;
        }
    }
}