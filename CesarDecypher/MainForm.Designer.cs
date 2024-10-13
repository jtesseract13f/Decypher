namespace CesarDecypher
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.keyBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EncryptMetod = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Encrypt = new System.Windows.Forms.Button();
            this.decrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.magicButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonFrequency = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // keyBox
            // 
            this.keyBox.Location = new System.Drawing.Point(270, 31);
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(327, 20);
            this.keyBox.TabIndex = 0;
            this.keyBox.TextChanged += new System.EventHandler(this.keyBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(267, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Key";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // EncryptMetod
            // 
            this.EncryptMetod.FormattingEnabled = true;
            this.EncryptMetod.Items.AddRange(new object[] {
            "Caesar",
            "MonoAlphabet",
            "Vigenere",
            "Tritemius",
            "Hill"});
            this.EncryptMetod.Location = new System.Drawing.Point(12, 31);
            this.EncryptMetod.Name = "EncryptMetod";
            this.EncryptMetod.Size = new System.Drawing.Size(249, 95);
            this.EncryptMetod.TabIndex = 2;
            this.EncryptMetod.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 147);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 291);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Encrypt
            // 
            this.Encrypt.Location = new System.Drawing.Point(267, 147);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(75, 23);
            this.Encrypt.TabIndex = 4;
            this.Encrypt.Text = "Encrypt>>";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // decrypt
            // 
            this.decrypt.Location = new System.Drawing.Point(267, 176);
            this.decrypt.Name = "decrypt";
            this.decrypt.Size = new System.Drawing.Size(75, 23);
            this.decrypt.TabIndex = 5;
            this.decrypt.Text = "Decrypt>>";
            this.decrypt.UseVisualStyleBackColor = true;
            this.decrypt.Click += new System.EventHandler(this.decrypt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Encrypt Method";
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(348, 147);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(249, 291);
            this.Result.TabIndex = 7;
            this.Result.TextChanged += new System.EventHandler(this.Result_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(267, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Alphabet:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(270, 106);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(327, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "abcdefghijklmnopqrstuvwxyz";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // magicButton
            // 
            this.magicButton.Location = new System.Drawing.Point(351, 57);
            this.magicButton.Name = "magicButton";
            this.magicButton.Size = new System.Drawing.Size(75, 23);
            this.magicButton.TabIndex = 10;
            this.magicButton.Text = "Try get key";
            this.magicButton.UseVisualStyleBackColor = true;
            this.magicButton.Click += new System.EventHandler(this.magicButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(625, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(338, 376);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // buttonFrequency
            // 
            this.buttonFrequency.Location = new System.Drawing.Point(623, 29);
            this.buttonFrequency.Name = "buttonFrequency";
            this.buttonFrequency.Size = new System.Drawing.Size(340, 23);
            this.buttonFrequency.TabIndex = 12;
            this.buttonFrequency.Text = "График частотности";
            this.buttonFrequency.UseVisualStyleBackColor = true;
            this.buttonFrequency.Click += new System.EventHandler(this.buttonFrequency_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(270, 57);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Gen key";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonFrequency);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.magicButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.decrypt);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.EncryptMetod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keyBox);
            this.Name = "MainForm";
            this.Text = "Cypher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox keyBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox EncryptMetod;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.Button decrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button magicButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonFrequency;
        private System.Windows.Forms.Button button3;
    }
}

