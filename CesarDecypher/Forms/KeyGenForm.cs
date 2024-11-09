using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CesarDecypher.Views
{
    public partial class KeyGenForm : Form
    {
        int textBoxWidth = 35;
        int textBoxHeight = 25;
        private List<List<TextBox>> matrix;
        //private System.Windows.Forms.Label label2;
        public KeyGenForm()
        {
            InitializeComponent();
        }

        private void KeyGenForm_Load(object sender, EventArgs e)
        {

            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void matrixSize_ValueChanged(object sender, EventArgs e)
        {
            matrix = new List<List<TextBox>>();
            matrixBox.Controls.Clear();
            for (int i = 0; i < matrixSize.Value; ++i)
            {
                matrix.Add(new List<TextBox>());
                for (int j = 0; j < matrixSize.Value; ++j)
                {
                    var textBox = new TextBox()
                    {
                        Text = "0",
                        Width = textBoxWidth,
                        Height = textBoxHeight,
                        Location = new Point((textBoxWidth+5)*j, 20 + textBoxHeight*i),
                    };
                    matrix[i].Add(textBox);
                    matrixBox.Controls.Add(textBox);
                }
            }
        }
    }
}
