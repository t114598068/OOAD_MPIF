using MPIF.Contracts;
using MPIF.Domain;
using MPIF.Application.Interfaces;

namespace MPIF.Application
{
    /// <summary>
    /// 登入使用案例的 Application Service（對應 Larman 的 GRASP Controller）。
    ///
    /// 職責：協調登入流程，不親自執行業務邏輯。
    ///   1. 對密碼做 hash（委派給 IPasswordHasher）。
    ///   2. 從 Repository 取得 User。
    ///   3. 委派給 User.ValidatePassword()（Information Expert）做驗證。
    ///   4. 回傳 IUserContext（Contracts 層），讓 UI 不需要 reference Domain。
    /// </summary>
    public class AuthAppService
    {
        private readonly IUserRepository _userRepo;
        private readonly IPasswordHasher _hasher;

        public AuthAppService(IUserRepository userRepo, IPasswordHasher hasher)
        {
            _userRepo = userRepo;
            _hasher = hasher;
        }

        // ── GRASP Controller：協調，不親自做事 ──────────────────────────────

        /// <summary>
        /// 執行登入。
        /// 成功回傳 IUserContext（UI 只需知道 Contracts，不碰 Domain.User）；
        /// 失敗回傳 null。
        /// </summary>
        public IUserContext Login(string userID, string password)
        {
            string hash = _hasher.Hash(password);

            User user = _userRepo.GetByID(userID);
            if (user == null)
                return null;

            if (!user.ValidatePassword(hash))
                return null;

            // 在 Application 層完成 Domain → Contracts 的轉換，UI 不需要感知 User
            return new UserContextAdapter(user);
        }
    }
}