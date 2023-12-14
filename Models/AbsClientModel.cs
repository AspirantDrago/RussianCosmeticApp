using System;
using System.Security.Cryptography;
using System.Text;

namespace RussianCosmeticApp.Models
{
    abstract class AbsClientModel
    {
        protected int? _id;
        protected string _email;
        protected string _password;
        protected static HashAlgorithm hash = SHA256.Create();

        public string Email
        {
            get { return _email; }
        }

        public AbsClientModel(
            int? id,
            string email,
            string password
            )
        {
            _id = id;
            _email = email;
            _password = password;
        }

        public abstract override string ToString();

        public abstract string GetInfo();

        public static string GetHashPassword(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            bytes = hash.ComputeHash(bytes);
            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }
    }
}
