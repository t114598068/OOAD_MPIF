using MPIF.Application.Interfaces;
using MPIF.Domain;

namespace MPIF.Infrastructure
{
    /// <summary>
    /// Stub 實作：在真實 DB 完成前，硬寫一筆假使用者讓流程可以跑通。
    /// </summary>
    public class StubUserRepository : IUserRepository
    {
        public User GetByID(string userID)
        {
            if (userID == "admin")
            {
                return new User
                {
                    UserID = "admin",
                    Name = "系統管理員",
                    // SHA-256("admin")
                    PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                    IsActive = true
                };
            }
            return null;
        }
    }
}