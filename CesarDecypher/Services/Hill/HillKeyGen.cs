using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services.Hill
{
    public class HillKeyGen
    {
        
        public HillKeyGen() { }
        public int[,] GenKeyForHill(int matrixSize)
        {
            int[,] keyMatrix = new int[matrixSize, matrixSize];

            // TO DO : GEY KEN
            return keyMatrix;
        }

        public void ValidateKey()
        {
            // validate key 
            // TO DO: find determinant of matrix and check them
            // find A Mutually Prime Number Modulo
        }
    }
}
