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
                var mat = Matrix.Multiply(
                    new List<List<int>>
                    {
                        new List<int>{5, 3},
                        new List<int>{4, 1}
                    },
                    new List<List<int>>
                    {
                        new List<int>{1, 0},
                        new List<int>{0, 1}
                    }
                    );
                var d = mat.Incidence();

                var inv = mat.Determinant().InverseModulo(26);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            try
            {
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new MainForm());
            }
            catch
            {

            }

        }
    }
}
