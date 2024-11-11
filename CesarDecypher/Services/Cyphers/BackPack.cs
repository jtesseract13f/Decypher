using CypherLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services.Cyphers
{
    public class BackPack : ICypher
    {
        public string AlghorithmName { get ; set ; }

        public string Decrypt(string message)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string message)
        {

            // как происходит шифровка и дешифровка?
            // на вход поступают биты, байты или строки?
            // как генерировать ключ?
            // Как расшифровывать?
            // Открытый и закрытый ключ
            // что является открытым и закрытым ключем?
            throw new NotImplementedException();
        }
    }
}
