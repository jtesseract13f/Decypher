namespace CesarDecypher.Forms
{
    partial class HillHackerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addPairButton = new System.Windows.Forms.Button();
            this.findKeyButton = new System.Windows.Forms.Button();
            this.matrixSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.matrixSizeLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matrixSizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.addPairButton);
            this.groupBox1.Location = new System.Drawing.Point(17, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 396);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фрагменты текста";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(261, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 21);
            this.button2.TabIndex = 5;
            this.button2.Text = "--";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(135, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Зашифрованный текст";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Исходный текст";
            // 
            // addPairButton
            // 
            this.addPairButton.Location = new System.Drawing.Point(6, 88);
            this.addPairButton.Name = "addPairButton";
            this.addPairButton.Size = new System.Drawing.Size(249, 23);
            this.addPairButton.TabIndex = 0;
            this.addPairButton.Text = "Добавить пару значений";
            this.addPairButton.UseVisualStyleBackColor = true;
            this.addPairButton.Click += new System.EventHandler(this.addPairButton_Click);
            // 
            // findKeyButton
            // 
            this.findKeyButton.Location = new System.Drawing.Point(312, 415);
            this.findKeyButton.Name = "findKeyButton";
            this.findKeyButton.Size = new System.Drawing.Size(155, 23);
            this.findKeyButton.TabIndex = 1;
            this.findKeyButton.Text = "Найти матрицу ключа";
            this.findKeyButton.UseVisualStyleBackColor = true;
            this.findKeyButton.Click += new System.EventHandler(this.findKeyButton_Click);
            // 
            // matrixSizeUpDown
            // 
            this.matrixSizeUpDown.Location = new System.Drawing.Point(195, 418);
            this.matrixSizeUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.matrixSizeUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.matrixSizeUpDown.Name = "matrixSizeUpDown";
            this.matrixSizeUpDown.Size = new System.Drawing.Size(92, 20);
            this.matrixSizeUpDown.TabIndex = 2;
            this.matrixSizeUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // matrixSizeLabel
            // 
            this.matrixSizeLabel.AutoSize = true;
            this.matrixSizeLabel.Location = new System.Drawing.Point(20, 420);
            this.matrixSizeLabel.Name = "matrixSizeLabel";
            this.matrixSizeLabel.Size = new System.Drawing.Size(160, 13);
            this.matrixSizeLabel.TabIndex = 3;
            this.matrixSizeLabel.Text = "Размерность матрицы ключа:";
            // 
            // HillHackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 450);
            this.Controls.Add(this.matrixSizeLabel);
            this.Controls.Add(this.matrixSizeUpDown);
            this.Controls.Add(this.findKeyButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "HillHackerForm";
            this.Text = "HillHackerForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matrixSizeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addPairButton;
        private System.Windows.Forms.Button findKeyButton;
        private System.Windows.Forms.NumericUpDown matrixSizeUpDown;
        private System.Windows.Forms.Label matrixSizeLabel;
    }
}