namespace MPIF.Domain
{
    /// <summary>
    /// 子模組描述資料（值物件 / DTO）。
    /// SubModule 本身不包含業務邏輯，僅作為模組識別與載入資訊的載體，
    /// 由 Group.PermittedModules 集合持有。
    /// </summary>
    public class SubModule
    {
        public string ModuleID { get; set; }
        public string ModuleName { get; set; }

        /// <summary>組件(.dll / .exe)的路徑，建議使用相對路徑或從設定檔注入。</summary>
        public string AssemblyPath { get; set; }

        public string Version { get; set; }
        public string EntryForm { get; set; }
    }
}