using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPIF.Domain;

namespace MPIF.Application.Interfaces
{
    public interface IUserRepository
    {
        User GetByID(string userID);
    }
}