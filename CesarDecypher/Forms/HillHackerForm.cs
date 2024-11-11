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
            button2.Click += new EventHandler(deletePairButton);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(parts[0][0]);
            groupBox1.Controls.Add(parts[0][1]);
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        List<Tuple<string, string>> ExtractParts()
        {
            try
            {
                var res = new List<Tuple<string, string>>();
                for (int i = 0; i < parts.Count; ++i)
                {
                    res.Add(new Tuple<string, string>(parts[i][0].Text, parts[i][1].Text));
                }
                return res;
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);
                    return null;
            }
            
        }

        void findKeyButton_Click(object sender, EventArgs e)
        {
            try
            {
                hacker = new HillHacker(main.alphabet.ToArray(), ExtractParts(), (int)matrixSizeUpDown.Value);
                var key = Hill.ParseKey(hacker.TryGetkey());
                ////////
                main.keyBox.Text = hacker.TryGetkey();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        void addPairButton_Click(object sender, EventArgs e)
        {
            var button = new Button()
            {
                Width = 22,
                Height = 21,
                Text = "--",
                Location = new Point(261, 51 + buttons.Count * textBoxHeight)
            };
            var textBoxes = new List<TextBox>()
            {
                new TextBox() { Width = 120, Location = new Point(6, 51 + buttons.Count * textBoxHeight)},
                new TextBox(){ Width = 120, Location = new Point(135, 51 + buttons.Count * textBoxHeight)}
            };
            groupBox1.Controls.Add(button);
            groupBox1.Controls.Add(textBoxes[0]);
            groupBox1.Controls.Add(textBoxes[1]);
            button.Click += new EventHandler(deletePairButton);
            buttons[button] = textBoxes;
            parts.Add(textBoxes);
            addPairButton.Location = new Point(6, 88 + (buttons.Count-1) * textBoxHeight);
            FormateTextBoxes();
        }

        void deletePairButton(object sender, EventArgs e)
        {
            if (!(sender is Button)) {
                return;
            }
            var button = (Button)sender;
            var textBoxes = buttons[button];
            groupBox1.Controls.Remove(button);
            groupBox1.Controls.Remove(textBoxes[0]);
            groupBox1.Controls.Remove(textBoxes[1]);
            parts.Remove(textBoxes);
            buttons.Remove(button);
            button.Dispose();
            textBoxes.ForEach(x => x.Dispose());
            FormateTextBoxes();
        }

        void FormateTextBoxes()
        {
            var l = buttons.ToList();
            for (int i = 0; i < l.Count; ++i)
            {
                var button = l[i].Key;
                var textBoxes = l[i].Value;

                button.Location = new Point(261, 51 + i * textBoxHeight);
                textBoxes[0].Location = new Point(6, 51 + i * textBoxHeight);
                textBoxes[1].Location = new Point(135, 51 + i * textBoxHeight);
            }

            addPairButton.Location = new Point(6, 88 + (buttons.Count - 1) * textBoxHeight);
        }
    }
}
