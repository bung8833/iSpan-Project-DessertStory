using ISpan.Project_02_DessertStory.Customer.Models.Services.Interfaces;
using System.Security.Cryptography;

namespace ISpan.Project_02_DessertStory.Customer.Models.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 128 / 8; //鹽的長度，一般使用SHA256時，建議的最短長度為 128 bits
        private const int KeySize = 256 / 8; //因為使用SHA256，所以KeySize為256bits/8=32bytes
        private const int Interations = 10000;//迭代次數，循環加密
        private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;//雜湊算法的名稱
        private const char Delimiter = ';';//分隔符號

        /// <summary>
        /// What:將密碼進行雜湊運算
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string Hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password,salt,Interations,_hashAlgorithmName,KeySize);
            //轉成 Base64 編碼
            return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }


        /// <summary>
        /// What:將使用者輸入的密碼雜湊後與資料庫中雜湊後的密碼比對驗證
        /// How: 驗證雜湊後的結果是否相同
        /// </summary>
        /// <param name="passwordHash">資料庫中雜湊後的密碼</param>
        /// <param name="inputPassword">使用者輸入的密碼</param>
        /// <returns></returns>
        public bool Verify(string passwordHash, string inputPassword)
        {
            var element = passwordHash.Split(Delimiter);
            var salt = Convert.FromBase64String(element[0]);
            var hash = Convert.FromBase64String(element[1]);

            var hashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, Interations, _hashAlgorithmName, KeySize);
            return CryptographicOperations.FixedTimeEquals(hash, hashInput);

            /*CryptographicOperations.FixedTimeEquals 是 .NET 6 中的一個靜態方法，
            用於比較兩個數組是否相等。它主要用於比較安全敏感的值，例如密碼哈希或加密金鑰。
            FixedTimeEquals 方法會針對相等和不相等的情況花費相同的時間，
            以防止將基於時間的攻擊用於猜測敏感數據的值。
            如果這兩個數組是相等的，則該方法返回 true；否則返回 false。
            在比較過程中，它將遍歷整個數組，並且無論數組是否相等，它的執行時間都會相同。*/
        }
    }
}
