using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lec5Lib
{
    public class DecMD5 : Decorator
    {
        public DecMD5(IWriter writer): base(writer) { }
        public override string? Save(string? message)
        {
            if (message != null)
            {
                byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(message));
                string hashedMessage = message + Constant.Delimiter + Convert.ToBase64String(hash);
                return writer?.Save(hashedMessage);
            }

            return null;
        }
    }
}
