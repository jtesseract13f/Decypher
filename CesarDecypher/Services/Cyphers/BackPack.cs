using CypherLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services.Cyphers
{
    internal class BackPack : ICypher
    {
        public string AlghorithmName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Decrypt(string message)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string message)
        {
            throw new NotImplementedException();

        }
    }
}
