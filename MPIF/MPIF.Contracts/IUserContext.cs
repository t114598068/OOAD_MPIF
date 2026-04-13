using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIF.Contracts
{
    public interface IUserContext
    {
        string UserID { get; }
        string UserName { get; }
    }
}