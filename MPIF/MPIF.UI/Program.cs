using System;
using System.Windows.Forms;
using MPIF.Application;
using MPIF.Infrastructure;
using MPIF.Contracts;

namespace MPIF.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // --- 依賴注入 (Dependency Injection) ---
            var hasher = new Sha256PasswordHasher();
            var userRepo = new StubUserRepository();
            var authService = new AuthAppService(userRepo, hasher);

            var permRepo = new StubPermissionRepository();
            var loader = new ModuleLoader();
            var moduleService = new ModuleAppService(permRepo, loader);

            // --- 執行登入流程 ---
            // 這裡採用簡單的流程控制：先開登入視窗，成功後再開主視窗
            using (var loginForm = new LoginForm(authService))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // 登入成功，從 LoginForm 取得 Context
                    IUserContext userContext = loginForm.UserContext;

                    // 啟動主殼層
                    System.Windows.Forms.Application.Run(new MainShell(moduleService, userContext));
                }
            }
        }
    }
}