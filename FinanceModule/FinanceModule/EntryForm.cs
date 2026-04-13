using System.Windows.Forms;
using MPIF.Contracts;

namespace FinanceModule
{
    // 在設計器拉好介面，然後手動加上介面實作
    public partial class EntryForm : Form, IModule
    {
        private IUserContext _context;

        public string ModuleID => "MOD-001";
        public string ModuleName => "財務報表系統";

        public void Initialize(IUserContext context)
        {
            // 接收來自 Shell 的使用者資訊
            _context = context;
            // 可以在此根據 UserID 決定控制項是否唯讀
        }

        public Control GetControl()
        {
            // 因為 Form 本身就是 Control，直接回傳自己
            return this;
        }

        public EntryForm()
        {
            InitializeComponent();
        }
    }
}