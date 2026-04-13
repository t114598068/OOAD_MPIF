using MPIF.Contracts;
using MPIF.Domain;

namespace MPIF.Application
{
    /// <summary>
    /// Adapter：將 Domain 的 User 轉換為 Contracts 定義的 IUserContext。
    /// 
    /// 為何不讓 User 直接實作 IUserContext？
    ///   - MPIF.Domain 不應依賴 MPIF.Contracts（Protected Variations）。
    ///   - 若 IUserContext 日後新增欄位（如 Locale、Token），
    ///     只需修改此 Adapter，不動 Domain 的 User。
    ///   - 這是刻意的設計決策，不是多餘的間接層。
    /// </summary>
    public class UserContextAdapter : IUserContext
    {
        public string UserID { get; }
        public string UserName { get; }

        public UserContextAdapter(User user)
        {
            UserID = user.UserID;
            UserName = user.Name;
        }
    }
}