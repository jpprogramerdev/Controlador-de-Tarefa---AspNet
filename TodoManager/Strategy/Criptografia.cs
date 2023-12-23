using System.Security.Cryptography;
using System.Text;

namespace TodoManager.Strategy {
    public static class Criptografia {
        public static string GerarHash(this string senha) {
            var hash = SHA1.Create();
            var enconding = new ASCIIEncoding();
            var array = enconding.GetBytes(senha);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach(var c in array) {
                strHexa.Append(c.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}
