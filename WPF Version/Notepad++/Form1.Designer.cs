namespace Notepad__
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
            this.components = new System.ComponentModel.Container();
            this.udSpeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.UDbon = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.wincheck = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.udFOV = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.btnExtend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.udSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UDbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFOV)).BeginInit();
            this.SuspendLayout();
            // 
            // udSpeed
            // 
            this.udSpeed.DecimalPlaces = 1;
            this.udSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udSpeed.Location = new System.Drawing.Point(75, 22);
            this.udSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udSpeed.Name = "udSpeed";
            this.udSpeed.Size = new System.Drawing.Size(43, 20);
            this.udSpeed.TabIndex = 4;
            this.udSpeed.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Slow Down";
            // 
            // UDbon
            // 
            this.UDbon.Location = new System.Drawing.Point(75, 46);
            this.UDbon.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.UDbon.Name = "UDbon";
            this.UDbon.Size = new System.Drawing.Size(43, 20);
            this.UDbon.TabIndex = 9;
            this.UDbon.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Adjust";
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGo.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGo.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ForeColor = System.Drawing.Color.Black;
            this.btnGo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGo.Location = new System.Drawing.Point(92, 3);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(13, 11);
            this.btnGo.TabIndex = 228;
            this.btnGo.Text = "-";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Black;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStop.Location = new System.Drawing.Point(105, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(13, 11);
            this.btnStop.TabIndex = 227;
            this.btnStop.Text = "X";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(80, 16);
            this.textBox1.TabIndex = 230;
            this.textBox1.Text = "AfterBurner";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Gray;
            this.label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(-42, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 1);
            this.label10.TabIndex = 229;
            this.label10.Text = "                                                                                 " +
    "                                                                      ";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(118, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(13, 11);
            this.btnExit.TabIndex = 232;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // wincheck
            // 
            this.wincheck.Enabled = true;
            this.wincheck.Interval = 250;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 235;
            this.label3.Text = "FOV";
            // 
            // udFOV
            // 
            this.udFOV.Location = new System.Drawing.Point(75, 70);
            this.udFOV.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.udFOV.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFOV.Name = "udFOV";
            this.udFOV.Size = new System.Drawing.Size(43, 20);
            this.udFOV.TabIndex = 234;
            this.udFOV.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.DimGray;
            this.label23.Cursor = System.Windows.Forms.Cursors.Default;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(2, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(127, 90);
            this.label23.TabIndex = 231;
            this.label23.Text = "                                                   \r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            // 
            // btnExtend
            // 
            this.btnExtend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnExtend.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExtend.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnExtend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExtend.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtend.ForeColor = System.Drawing.Color.Black;
            this.btnExtend.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExtend.Location = new System.Drawing.Point(51, 85);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(5, 5);
            this.btnExtend.TabIndex = 233;
            this.btnExtend.Text = "-";
            this.btnExtend.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(131, 102);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.udFOV);
            this.Controls.Add(this.btnExtend);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UDbon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.udSpeed);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label23);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.Text = "Benchmark";
            ((System.ComponentModel.ISupportInitialize)(this.udSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UDbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFOV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer wincheck;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown udSpeed;
        public System.Windows.Forms.NumericUpDown UDbon;
        public System.Windows.Forms.NumericUpDown udFOV;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnExtend;
    }
}

