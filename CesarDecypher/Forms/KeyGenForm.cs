using CesarDecypher.Infrasturcture;
using CesarDecypher.Services.Cyphers;
using CesarDecypher.Services.KeyGens;
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
        MainForm main;

        private List<List<TextBox>> matrix;
        public KeyGenForm(MainForm _main)
        {
            main = _main;
            InitializeComponent();
        }

        private void KeyGenForm_Load(object sender, EventArgs e)
        {
            matrix = new List<List<TextBox>>();
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
                        Location = new Point((textBoxWidth + 5) * j, 20 + textBoxHeight * i),
                    };
                    matrix[i].Add(textBox);
                    matrixBox.Controls.Add(textBox);
                }
            }
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

        private void genKeyMatrix_Click(object sender, EventArgs e)
        {
            var keyGen = new HillKeyGen(main.alphabet.ToArray());
            var keyString = keyGen.GenerateKey((int)matrixSize.Value);
            var keyMatrix = Hill.ParseKey(keyString);

            for (int i = 0; i < keyMatrix.Count; ++i)
            {
                for (int j = 0; j <  keyMatrix[i].Count; ++j)
                {
                    matrix[i][j].Text = keyMatrix[i][j].ToString();
                }
            }

        }

        private void setKeyButton_Click(object sender, EventArgs e)
        {
            var matrixInt = matrix.Select(x => x.Select(y => int.Parse(y.Text)).ToList()).ToList();
            main.key = matrixInt.MatrixToString();
            main.keyBox.Text = matrixInt.MatrixToString();
        }
    }
}
