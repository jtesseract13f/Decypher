using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CesarDecypher.Forms;
using CesarDecypher.Infrasturcture;
using CesarDecypher.Services;
using CesarDecypher.Services.Cyphers;
using CesarDecypher.Services.KeyGens;
using CesarDecypher.Views;
using CypherLogic.Interfaces;
using CypherLogic.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CesarDecypher
{
    public partial class MainForm : Form
    {
        public List<string> encryptorsNames;
        public string key;
        public char[] alphabet;
        public string message;
        public string result;
        public FrequencyAnalysator frequencyAnalysator;
        public KeyProcessor keyProcessor;
        string russianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private const int WM_VSCROLL = 0x115;
        private const int SB_THUMBPOSITION = 4;
        readonly Dictionary<char, double> letterFrequencies = new Dictionary<char, double>
            {
                { 'a', 8.17 },
                { 'b', 1.49 },
                { 'c', 2.78 },
                { 'd', 4.25 },
                { 'e', 12.70 },
                { 'f', 2.23 },
                { 'g', 2.02 },
                { 'h', 6.09 },
                { 'i', 6.97 },
                { 'j', 0.15 },
                { 'k', 0.77 },
                { 'l', 4.03 },
                { 'm', 2.41 },
                { 'n', 6.75 },
                { 'o', 7.51 },
                { 'p', 1.93 },
                { 'q', 0.10 },
                { 'r', 5.99 },
                { 's', 6.33 },
                { 't', 9.06 },
                { 'u', 2.76 },
                { 'v', 0.98 },
                { 'w', 2.36 },
                { 'x', 0.15 },
                { 'y', 1.97 },
                { 'z', 0.07 }
            };
        readonly Dictionary<char, double> russianLetterFrequencies = new Dictionary<char, double>
            {
                { 'о', 10.983 },
                { 'е', 8.483 },
                { 'а', 7.998 },
                { 'и', 7.367 },
                { 'н', 6.7 },
                { 'т', 6.318 },
                { 'с', 5.473 },
                { 'р', 4.746 },
                { 'в', 4.533 },
                { 'л', 4.343 },
                { 'к', 3.486 },
                { 'м', 3.203 },
                { 'д', 2.977 },
                { 'п', 2.804 },
                { 'у', 2.615 },
                { 'я', 2.001 },
                { 'ы', 1.898 },
                { 'ь', 1.735 },
                { 'г', 1.687 },
                { 'з', 1.641 },
                { 'б', 1.592 },
                { 'ч', 1.45 },
                { 'й', 1.208 },
                { 'х', 0.966 },
                { 'ж', 0.94 },
                { 'ш', 0.718 },
                { 'ю', 0.638 },
                { 'ц', 0.486 },
                { 'щ', 0.361 },
                { 'э', 0.331 },
                { 'ф', 0.267 },
                { 'ъ', 0.037 },
                { 'ё', 0.013 }
            };
        public MainForm()
        {
            alphabet = russianAlphabet.ToArray();
            frequencyAnalysator = new FrequencyAnalysator(alphabet);
            InitializeComponent();
            textBox2.Text = russianAlphabet;
            textBox1.ScrollBars = ScrollBars.Vertical;
            Result.ScrollBars = ScrollBars.Vertical;
            InitializeDataGridView();
            keyProcessor = new KeyProcessor();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.ColumnCount = 4;
            
            dataGridView1.Columns[0].Name = "Буква текста";
            dataGridView1.Columns[1].Name = "Частота";

            dataGridView1.Columns[2].Name = "Буква алфавита";
            dataGridView1.Columns[3].Name = "Частота";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DisplayDictionaryInDataGridView()
        {
            dataGridView1.Rows.Clear();
            int ind = 0;
            var fr = russianLetterFrequencies.OrderByDescending(x => x.Value).ToArray();
            var fra = frequencyAnalysator.FrequencyAnalys.OrderByDescending(x => x.Value).ToArray();
            foreach (var kvp in fra)
            {
                dataGridView1.Rows.Add(kvp.Key, Math.Round(kvp.Value*100000)/1000, fr[ind].Key, fr[ind].Value);
                ++ind;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EncryptMetod.Select();
        }

        private void decrypt_Click(object sender, EventArgs e)
        {
            try
            {
                var decryptor = this.MakeEncryptor(EncryptMetod.Text);
                result = decryptor.Decrypt(message);
                Result.Text = result;
                frequencyAnalysator = new FrequencyAnalysator(alphabet);
                frequencyAnalysator.GetFrequency(result, alphabet);
                DisplayDictionaryInDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            try
            {
                var encryptor = this.MakeEncryptor(EncryptMetod.Text);
                result = encryptor.Encrypt(message);
                Result.Text = result;
                frequencyAnalysator = new FrequencyAnalysator(alphabet);
                frequencyAnalysator.GetFrequency(result, alphabet);
                DisplayDictionaryInDataGridView();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }



        private void Result_TextChanged(object sender, EventArgs e)
        {
            Result.Text = result;
        }

        private void keyBox_TextChanged(object sender, EventArgs e)
        {
            key = keyBox.Text.ToLower();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            message = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            alphabet = textBox2.Text.ToString().ToLower().ToArray();
        }

        private void magicButton_Click(object sender, EventArgs e)
        {
            var hacker = new HillHackerForm(this);
            hacker.Show();
        }

        private void buttonFrequency_Click(object sender, EventArgs e)
        {
            var plot = new FrequencyPlot(frequencyAnalysator.FrequencyAnalys);
            plot.Show();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            switch (EncryptMetod.Text)
            {
                case "Caesar":
                    keyBox.Text = (rand.Next() % alphabet.Length).ToString();
                    break;
                case "MonoAlphabet":
                    string shuffledAlphabet = new string(alphabet.OrderBy(c => rand.Next()).ToArray());
                    keyBox.Text = shuffledAlphabet;
                    break;
                case "Vigenere":
                    string shuffledVAlphabet = new string(alphabet.OrderBy(c => rand.Next()).ToArray());
                    keyBox.Text = shuffledVAlphabet;
                    break;
                case "Tritemius":
                    string shuffledTAlphabet = new string(alphabet.OrderBy(c => rand.Next()).ToArray()).Replace(alphabet.First(), alphabet.Last());
                    keyBox.Text = shuffledTAlphabet.ToString();
                    break;
                case "Hill":
                    var keyGenForm = new KeyGenForm(this);
                    keyGenForm.Show();
                    break;
                default:
                    keyBox.Text = (rand.Next() % alphabet.Length).ToString();
                    break;
            }
            
        }
    }
}
