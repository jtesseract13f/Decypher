namespace CesarDecypher.Views
{
    partial class KeyGenForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.matrixSize = new System.Windows.Forms.NumericUpDown();
            this.matrixBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.matrixSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Размерность матрицы:";
            // 
            // matrixSize
            // 
            this.matrixSize.Location = new System.Drawing.Point(209, 287);
            this.matrixSize.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.matrixSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.matrixSize.Name = "matrixSize";
            this.matrixSize.Size = new System.Drawing.Size(52, 20);
            this.matrixSize.TabIndex = 2;
            this.matrixSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.matrixSize.ValueChanged += new System.EventHandler(this.matrixSize_ValueChanged);
            // 
            // matrixBox
            // 
            this.matrixBox.Location = new System.Drawing.Point(25, 26);
            this.matrixBox.Name = "matrixBox";
            this.matrixBox.Size = new System.Drawing.Size(236, 234);
            this.matrixBox.TabIndex = 3;
            this.matrixBox.TabStop = false;
            this.matrixBox.Text = "Матрица ключа";
            this.matrixBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // KeyGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 319);
            this.Controls.Add(this.matrixBox);
            this.Controls.Add(this.matrixSize);
            this.Controls.Add(this.label1);
            this.Name = "KeyGenForm";
            this.Text = "KeyGenForm";
            this.Load += new System.EventHandler(this.KeyGenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.matrixSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown matrixSize;
        private System.Windows.Forms.GroupBox matrixBox;
    }
}