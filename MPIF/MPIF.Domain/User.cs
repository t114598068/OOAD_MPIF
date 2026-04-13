
namespace MPIF.Domain
{
    /// <summary>
    /// Domain entity：使用者帳號。
    /// 按照 Information Expert，User 自己持有帳號資訊，
    /// 因此驗證密碼的責任歸屬於此類別，而非外層的 AppService。
    /// </summary>
    public class User
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }

        // ── Information Expert ──────────────────────────────────────────────
        // User 持有 PasswordHash 與 IsActive，所以由 User 自己判斷登入是否合法。
        // AuthAppService 不再需要直接讀取 PasswordHash，降低耦合。

        /// <summary>
        /// 驗證傳入的 hash 是否與帳號吻合，且帳號必須啟用。
        /// </summary>
        public bool ValidatePassword(string passwordHash)
            => IsActive && PasswordHash == passwordHash;
    }
}
