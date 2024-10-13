using CesarDecypher.Services.Hill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CesarDecypher
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                var matrix = new List<List<int>>() {
                    new List<int>() { 5, 3} ,
                    new List<int>() { 4, 1} ,
                };

                HillKeyGen.ValidateKey(matrix, "abcdefghijklmnopqrstuvwxyz");
            }
            catch (Exception ex) { }
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch
            {

            }

        }
    }
}
