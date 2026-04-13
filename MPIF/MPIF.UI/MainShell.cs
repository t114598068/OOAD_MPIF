using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MPIF.Application;
using MPIF.Contracts;

namespace MPIF.UI
{
    public partial class MainShell : Form
    {
        private readonly ModuleAppService _moduleService;
        private readonly IUserContext _userContext;

        // 由 Program.cs (Composition Root) 注入
        public MainShell(ModuleAppService moduleService, IUserContext context)
        {
            InitializeComponent();
            _moduleService = moduleService;
            _userContext = context;
        }

        private void MainShell_Load(object sender, EventArgs e)
        {
            LoadModulesToTree();
        }

        private void LoadModulesToTree()
        {
            // 1. 轉發請求給 Controller (Application Service) 取得模組實例
            List<IModule> authorizedModules = _moduleService.GetAuthorizedModules(_userContext.UserID, _userContext);

            tvModules.Nodes.Clear();
            TreeNode rootNode = new TreeNode("系統模組清單");

            // 2. 將模組物件封裝進 TreeNode
            foreach (var mod in authorizedModules)
            {
                TreeNode node = new TreeNode(mod.ModuleName);
                // 關鍵：將實作了 IModule 的物件存在 Tag 屬性中
                node.Tag = mod;
                rootNode.Nodes.Add(node);
            }

            tvModules.Nodes.Add(rootNode);
            rootNode.Expand();
        }

        private void tvModules_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 3. 當使用者選取節點，檢查 Tag 是否為 IModule
            if (e.Node.Tag is IModule selectedModule)
            {
                SwitchDisplayModule(selectedModule);
            }
        }

        private void SwitchDisplayModule(IModule module)
        {
            // 4. 切換畫面邏輯：清空舊的，放入新的
            panelMain.SuspendLayout(); // 減少閃爍
            try
            {
                panelMain.Controls.Clear();

                // 透過介面取得該模組的 Control (例如一個 UserControl 或 Form)
                Control moduleUI = module.GetControl();

                moduleUI.Dock = DockStyle.Fill;
                // 注意：若 moduleUI 是 Form，需設置 TopLevel = false
                if (moduleUI is Form frm)
                {
                    frm.TopLevel = false;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Visible = true;
                }

                panelMain.Controls.Add(moduleUI);
            }
            finally
            {
                panelMain.ResumeLayout();
            }
        }
    }
}