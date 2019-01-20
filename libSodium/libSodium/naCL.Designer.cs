namespace libSodium
{
    partial class naCL
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
            this.reader = new System.ComponentModel.BackgroundWorker();
            this.udBoneSelector = new System.Windows.Forms.NumericUpDown();
            this.udThreadPerformance = new System.Windows.Forms.NumericUpDown();
            this.udFOV = new System.Windows.Forms.NumericUpDown();
            this.udAimSpeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.configUpdater = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.udMouseSensitivity = new System.Windows.Forms.NumericUpDown();
            this.draw = new System.ComponentModel.BackgroundWorker();
            this.entityLoop = new System.ComponentModel.BackgroundWorker();
            this.btnExtend = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.keyCheck = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.udBoneSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udThreadPerformance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFOV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAimSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMouseSensitivity)).BeginInit();
            this.SuspendLayout();
            // 
            // reader
            // 
            this.reader.WorkerSupportsCancellation = true;
            this.reader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.reader_DoWork);
            // 
            // udBoneSelector
            // 
            this.udBoneSelector.Location = new System.Drawing.Point(81, 19);
            this.udBoneSelector.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.udBoneSelector.Name = "udBoneSelector";
            this.udBoneSelector.Size = new System.Drawing.Size(40, 20);
            this.udBoneSelector.TabIndex = 10;
            this.udBoneSelector.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // udThreadPerformance
            // 
            this.udThreadPerformance.Location = new System.Drawing.Point(81, 45);
            this.udThreadPerformance.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.udThreadPerformance.Name = "udThreadPerformance";
            this.udThreadPerformance.Size = new System.Drawing.Size(40, 20);
            this.udThreadPerformance.TabIndex = 11;
            this.udThreadPerformance.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // udFOV
            // 
            this.udFOV.Location = new System.Drawing.Point(81, 71);
            this.udFOV.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udFOV.Name = "udFOV";
            this.udFOV.Size = new System.Drawing.Size(40, 20);
            this.udFOV.TabIndex = 12;
            this.udFOV.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // udAimSpeed
            // 
            this.udAimSpeed.Location = new System.Drawing.Point(81, 97);
            this.udAimSpeed.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.udAimSpeed.Name = "udAimSpeed";
            this.udAimSpeed.Size = new System.Drawing.Size(40, 20);
            this.udAimSpeed.TabIndex = 13;
            this.udAimSpeed.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Bone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Thread Perf";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "FOV";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Aim Speed";
            // 
            // configUpdater
            // 
            this.configUpdater.Enabled = true;
            this.configUpdater.Interval = 1000;
            this.configUpdater.Tick += new System.EventHandler(this.configUpdater_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Sensitivity";
            // 
            // udMouseSensitivity
            // 
            this.udMouseSensitivity.DecimalPlaces = 1;
            this.udMouseSensitivity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udMouseSensitivity.Location = new System.Drawing.Point(81, 123);
            this.udMouseSensitivity.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udMouseSensitivity.Name = "udMouseSensitivity";
            this.udMouseSensitivity.Size = new System.Drawing.Size(40, 20);
            this.udMouseSensitivity.TabIndex = 18;
            this.udMouseSensitivity.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // draw
            // 
            this.draw.WorkerSupportsCancellation = true;
            this.draw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.draw_DoWork);
            // 
            // entityLoop
            // 
            this.entityLoop.WorkerSupportsCancellation = true;
            this.entityLoop.DoWork += new System.ComponentModel.DoWorkEventHandler(this.entityLoop_DoWork);
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
            this.btnExtend.Location = new System.Drawing.Point(6, 141);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(5, 5);
            this.btnExtend.TabIndex = 246;
            this.btnExtend.Text = "-";
            this.btnExtend.UseVisualStyleBackColor = false;
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
            this.btnExit.Location = new System.Drawing.Point(118, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(13, 11);
            this.btnExit.TabIndex = 245;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Gray;
            this.label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(-42, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 1);
            this.label10.TabIndex = 242;
            this.label10.Text = "                                                                                 " +
    "                                                                      ";
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
            this.btnGo.Location = new System.Drawing.Point(92, 0);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(13, 11);
            this.btnGo.TabIndex = 241;
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
            this.btnStop.Location = new System.Drawing.Point(105, 0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(13, 11);
            this.btnStop.TabIndex = 240;
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
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(80, 16);
            this.textBox1.TabIndex = 243;
            this.textBox1.Text = "libSodium";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDown);
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.DimGray;
            this.label23.Cursor = System.Windows.Forms.Cursors.Default;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(2, 6);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(129, 143);
            this.label23.TabIndex = 244;
            this.label23.Text = "                                                   \r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            // 
            // keyCheck
            // 
            this.keyCheck.Enabled = true;
            this.keyCheck.Interval = 10;
            this.keyCheck.Tick += new System.EventHandler(this.keyCheck_Tick);
            // 
            // naCL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Magenta;
            this.ClientSize = new System.Drawing.Size(134, 151);
            this.Controls.Add(this.btnExtend);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.udMouseSensitivity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.udAimSpeed);
            this.Controls.Add(this.udFOV);
            this.Controls.Add(this.udThreadPerformance);
            this.Controls.Add(this.udBoneSelector);
            this.Controls.Add(this.label23);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "naCL";
            this.Text = "NaCl";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Load += new System.EventHandler(this.naCL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.udBoneSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udThreadPerformance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFOV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAimSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMouseSensitivity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker reader;
        private System.Windows.Forms.NumericUpDown udBoneSelector;
        private System.Windows.Forms.NumericUpDown udThreadPerformance;
        private System.Windows.Forms.NumericUpDown udFOV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown udAimSpeed;
        private System.Windows.Forms.Timer configUpdater;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown udMouseSensitivity;
        private System.ComponentModel.BackgroundWorker draw;
        private System.ComponentModel.BackgroundWorker entityLoop;
        private System.Windows.Forms.Button btnExtend;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Timer keyCheck;
    }
}

