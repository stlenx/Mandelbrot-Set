namespace Mandelbrot_set
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.NumberOfIterations = new System.Windows.Forms.NumericUpDown();
            this.ScaleFactor = new System.Windows.Forms.NumericUpDown();
            this.XScale = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.NumberOfIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.ScaleFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.XScale)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(882, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NumberOfIterations
            // 
            this.NumberOfIterations.Location = new System.Drawing.Point(808, 17);
            this.NumberOfIterations.Maximum = new decimal(new int[] {10000, 0, 0, 0});
            this.NumberOfIterations.Name = "NumberOfIterations";
            this.NumberOfIterations.Size = new System.Drawing.Size(68, 20);
            this.NumberOfIterations.TabIndex = 1;
            this.NumberOfIterations.ThousandsSeparator = true;
            // 
            // ScaleFactor
            // 
            this.ScaleFactor.DecimalPlaces = 5;
            this.ScaleFactor.Location = new System.Drawing.Point(743, 17);
            this.ScaleFactor.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.ScaleFactor.Name = "ScaleFactor";
            this.ScaleFactor.Size = new System.Drawing.Size(59, 20);
            this.ScaleFactor.TabIndex = 2;
            // 
            // XScale
            // 
            this.XScale.Location = new System.Drawing.Point(635, 17);
            this.XScale.Maximum = new decimal(new int[] {999999, 0, 0, 0});
            this.XScale.Name = "XScale";
            this.XScale.Size = new System.Drawing.Size(92, 20);
            this.XScale.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.XScale);
            this.Controls.Add(this.ScaleFactor);
            this.Controls.Add(this.NumberOfIterations);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize) (this.NumberOfIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.ScaleFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.XScale)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.NumericUpDown XScale;

        private System.Windows.Forms.NumericUpDown ScaleFactor;

        private System.Windows.Forms.NumericUpDown NumberOfIterations;

        private System.Windows.Forms.Button button1;

        #endregion
    }
}