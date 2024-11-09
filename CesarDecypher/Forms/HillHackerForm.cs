using CesarDecypher.Services.Cyphers;
using CesarDecypher.Services.KeyHackers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CesarDecypher.Forms
{
    public partial class HillHackerForm : Form
    {
        MainForm main;
        List<List<TextBox>> parts;
        Dictionary<Button, List<TextBox>> buttons;
        HillHacker hacker;
        int textBoxHeight = 30;
        public HillHackerForm(MainForm _main)
        {
            main = _main;
            InitializeComponent();
            parts = new List<List<TextBox>>()
            {
                new List<TextBox>()
                {
                    textBox1,
                    textBox2
                }
            };
            buttons = new Dictionary<Button, List<TextBox>>();
            buttons[button2] = parts[0];
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(parts[0][0]);
            groupBox1.Controls.Add(parts[0][1]);
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        List<Tuple<string, string>> ExtractParts()
        {
            var res = new List<Tuple<string, string>>();
            for (int i = 0; i < parts.Count; ++i)
            {
                res.Add(new Tuple<string, string>(parts[i][0].Text,  parts[i][1].Text));
            }
            return res;
        }

        private void findKeyButton_Click(object sender, EventArgs e)
        {
            hacker = new HillHacker(main.alphabet.ToArray(), ExtractParts(), (int)matrixSizeUpDown.Value);
            var key = Hill.ParseKey(hacker.TryGetkey());
            ////////
            main.keyBox.Text = hacker.TryGetkey();
        }

        private void addPairButton_Click(object sender, EventArgs e)
        {
            var button = new Button()
            {
                Location = new Point(261, 51 + buttons.Count * textBoxHeight),
                Width = 22,
                Height = 21,
                Text = "--"
            };
            var textBoxes = new List<TextBox>()
            {
                new TextBox() { Location = new Point(6, 51 + buttons.Count * textBoxHeight), Width = 120},
                new TextBox(){ Location = new Point(135, 51 + buttons.Count * textBoxHeight), Width = 120}
            };
            groupBox1.Controls.Add(button);
            groupBox1.Controls.Add(textBoxes[0]);
            groupBox1.Controls.Add(textBoxes[1]);
            buttons[button] = textBoxes;
            parts.Add(textBoxes);
            addPairButton.Location = new Point(6, 88 + buttons.Count * textBoxHeight);
        }
    }
}
