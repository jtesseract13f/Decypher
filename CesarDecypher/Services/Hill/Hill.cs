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
        //TO DO: How to determinate key? array of chars? array of strings? array of numbers?
        public string AlghorithmName { get; set; }
        public char[] alphabet;
        
        public Hill(char[] _alphabet)
        {
            AlghorithmName = "Hill";
            alphabet = _alphabet;
        }
        public bool CheckKey()
        {
            return true;
        }

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
