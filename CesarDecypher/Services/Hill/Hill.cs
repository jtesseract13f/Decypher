using CypherLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services.Hill
{
    public class Hill : IEncryptor
    {
        public char[] _alphabet;
        public Dictionary<char, int> _charToInt;
        public string AlghorithmName { get; set; }

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
