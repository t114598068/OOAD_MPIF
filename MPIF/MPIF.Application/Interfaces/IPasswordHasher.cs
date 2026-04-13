
using MPIF.Domain;

namespace MPIF.Application.Interfaces
{
    /// <summary>
    /// Pure Fabrication：密碼雜湊服務介面。
    /// 
    /// 為何需要此介面？
    ///   - Hash 演算法（SHA256、bcrypt…）屬於技術細節，不屬於任何 Domain 類別。
    ///   - 抽成介面後，AuthAppService 依賴抽象，不依賴具體演算法（Protected Variations）。
    ///   - 測試時可注入假實作，方便 unit test。
    /// </summary>
    public interface IPasswordHasher
    {
        string Hash(string plainText);
    }
}