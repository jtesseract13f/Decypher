using CypherLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services.Hill
{
    public class HillCypher
    {
        public char[] alphabet;
        public HillCypher(char[] _alphabet)
        {
            alphabet = _alphabet;
        }
        public bool CheckKey()
        {
            return true;
        }
        public string Encrypt(string message)
        {
            return "";
        }
    }
}
