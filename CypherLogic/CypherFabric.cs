using CypherLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CypherLogic
{
    public class CypherFabric
    {
        IEncryptor encryptor;

        public CypherFabric(IEncryptor _encryptor)
        {
            encryptor = _encryptor; 
        }
    }
}
