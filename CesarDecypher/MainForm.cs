using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CesarDecypher.Services;
using CypherLogic.Interfaces;
using CypherLogic.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CesarDecypher
{
    public partial class MainForm : Form
    {
        public List<string> encryptorsNames;
        public CypherController controller;
        public string key;
        public char[] alphabet;
        public string message;
        public string result;
        public FrequencyAnalysator frequencyAnalysator;
        public KeyProcessor keyProcessor;
        string russianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public MainForm()
        {
            alphabet = russianAlphabet.ToArray();
            frequencyAnalysator = new FrequencyAnalysator(alphabet);
            InitializeComponent();
            textBox2.Text = russianAlphabet;
            InitializeDataGridView();
            keyProcessor = new KeyProcessor();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Character";
            dataGridView1.Columns[1].Name = "Value";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DisplayDictionaryInDataGridView()
        {
            dataGridView1.Rows.Clear();

            foreach (var kvp in frequencyAnalysator.FrequencyAnalys)
            {
                dataGridView1.Rows.Add(kvp.Key, kvp.Value);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EncryptMetod.Select();
        }

        private void decrypt_Click(object sender, EventArgs e)
        {
            var decryptor = MakeEncryptor(EncryptMetod.Text);
            result = decryptor.Decrypt(message);
            Result.Text = result;
            frequencyAnalysator = new FrequencyAnalysator(alphabet);
            frequencyAnalysator.GetFrequency(result, alphabet);
            DisplayDictionaryInDataGridView();
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            var encryptor = MakeEncryptor(EncryptMetod.Text);
            result = encryptor.Encrypt(message);
            Result.Text = result;
            frequencyAnalysator = new FrequencyAnalysator(alphabet);
            frequencyAnalysator.GetFrequency(result, alphabet);
            DisplayDictionaryInDataGridView();
        }

        private IEncryptor MakeEncryptor(string selectedMethod)
        {
            switch (selectedMethod) 
            {
                case "Caesar Encryptor":
                    return new Cesar(int.Parse(key), alphabet);
                case "MonoAlphabet Encryptor":
                    return new MonoAlphabet(key.ToArray(), alphabet);
                case "Vigenere Encryptor":
                    return new Vigenere(key, alphabet);
                default:
                    return new Cesar(int.Parse(key), alphabet);
            }
        }

        private void Result_TextChanged(object sender, EventArgs e)
        {
            Result.Text = result;
        }

        private void keyBox_TextChanged(object sender, EventArgs e)
        {
            key = keyBox.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            message = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            alphabet = textBox2.Text.ToString().ToArray();
        }

        private void magicButton_Click(object sender, EventArgs e)
        {
            keyBox.Text = keyProcessor.ProcessKey(alphabet, message).ToString();
        }

        private void buttonFrequency_Click(object sender, EventArgs e)
        {
            var plot = new Form1(frequencyAnalysator.FrequencyAnalys);
            plot.Show();

        }
    }
}
