using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPIF.Contracts
{
    public interface IModule
    {
        string ModuleID { get; }
        string ModuleName { get; }
        Control GetControl();
        void Initialize(IUserContext context);
    }
}