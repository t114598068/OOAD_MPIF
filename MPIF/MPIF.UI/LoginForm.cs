using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MPIF.Application;
using MPIF.Contracts;

namespace MPIF.UI
{
    public partial class LoginForm : Form
    {
        private readonly AuthAppService _authService;
        public IUserContext UserContext { get; private set; }

        // 透過建構子注入 Service，符合 Larman 的控制器轉發原則
        public LoginForm(AuthAppService authService)
        {
            InitializeComponent(); // 此方法由設計器維護
            _authService = authService;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. 收集 UI 資料
            string id = txtUserID.Text;
            string pwd = txtPassword.Text;

            // 2. 轉發請求給 Controller (Application Service)
            // View 不檢查帳密對不對，那是 Service 的事
            UserContext = _authService.Login(id, pwd);

            if (UserContext != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("登入失敗，請檢查帳號密碼。");
            }
        }
    }
}
