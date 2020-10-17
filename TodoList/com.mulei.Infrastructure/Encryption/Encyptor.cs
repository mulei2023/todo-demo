using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Mulei.Infrastructure.Encryption
{
    public class Encyptor
    {
        public readonly string Salt="d93nd39svnf73hjgj";
        public static string Encrypt(string val)
        {
            //todo:actually, the encrypt should use RSA or MD5 together with salt.
            return val;
        }

    }
}
