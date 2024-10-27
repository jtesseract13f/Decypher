using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Interfaces
{
    public interface IKeyGenerator
    {
        char[] alphabet {  get; }
        string GenerateKey(int length);
    }
}
