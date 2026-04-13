using System;
using System.Security.Cryptography;
using System.Text;
using MPIF.Application.Interfaces;

namespace MPIF.Infrastructure
{
    /// <summary>
    /// IPasswordHasher 的具體實作（SHA-256）。
    /// 屬於 Infrastructure 層，AppService 透過介面依賴它，不直接耦合到此類別。
    /// 
    /// 生產環境建議換成 bcrypt / Argon2 等帶 salt 的演算法。
    /// </summary>
    public class Sha256PasswordHasher : IPasswordHasher
    {
        public string Hash(string plainText)
        {
            // C# 7.3：用 using() 區塊，不能用 using var（C# 8+）
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                // C# 7.3：Convert.ToHexString() 是 .NET 5+，改用 BitConverter
                return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}