using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lec5Lib
{
    public class DecSHA512 : Decorator
    {
        public DecSHA512(IWriter writer) : base(writer) { }
       public override string? Save(string? message)
        {
            if (message != null)
            {
                byte[] hash = SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(message));
                string hashedMessage = message + Constant.Delimiter + Convert.ToBase64String(hash);
                return writer?.Save(hashedMessage);
            }
            return null;
        }
    }
}
