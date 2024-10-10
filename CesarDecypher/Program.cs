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
                    new List<int>() { 1, 2, 300} ,
                    new List<int>() { 6, 50, 40} ,
                    new List<int>() { 7, 8, 9} ,
                };
                Matrix m = new Matrix(matrix);

                m.FindDeterminant();
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
