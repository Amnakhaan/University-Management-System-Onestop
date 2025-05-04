namespace onestop
{
    partial class Admin_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.alogin = new System.Windows.Forms.Label();
            this.aname = new System.Windows.Forms.Label();
            this.apass = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.alog = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(351, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 512);
            this.panel1.TabIndex = 0;
            // 
            // alogin
            // 
            this.alogin.AutoSize = true;
            this.alogin.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alogin.Location = new System.Drawing.Point(585, 58);
            this.alogin.Name = "alogin";
            this.alogin.Size = new System.Drawing.Size(146, 25);
            this.alogin.TabIndex = 1;
            this.alogin.Text = "Admin Login";
            // 
            // aname
            // 
            this.aname.AutoSize = true;
            this.aname.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aname.Location = new System.Drawing.Point(434, 178);
            this.aname.Name = "aname";
            this.aname.Size = new System.Drawing.Size(77, 19);
            this.aname.TabIndex = 2;
            this.aname.Text = "Username";
            // 
            // apass
            // 
            this.apass.AutoSize = true;
            this.apass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apass.Location = new System.Drawing.Point(439, 284);
            this.apass.Name = "apass";
            this.apass.Size = new System.Drawing.Size(72, 19);
            this.apass.TabIndex = 3;
            this.apass.Text = "Password";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(554, 177);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(554, 285);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(227, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // alog
            // 
            this.alog.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alog.Location = new System.Drawing.Point(590, 380);
            this.alog.Name = "alog";
            this.alog.Size = new System.Drawing.Size(116, 28);
            this.alog.TabIndex = 6;
            this.alog.Text = "LOGIN";
            this.alog.UseVisualStyleBackColor = true;
            this.alog.Click += new System.EventHandler(this.alog_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(70, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 220);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.CadetBlue;
            this.button4.Location = new System.Drawing.Point(946, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 23);
            this.button4.TabIndex = 18;
            this.button4.Text = "X";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Admin_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(984, 511);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.alog);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.apass);
            this.Controls.Add(this.aname);
            this.Controls.Add(this.alogin);
            this.Controls.Add(this.panel1);
            this.Name = "Admin_login";
            this.Text = "Admin_login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label alogin;
        private System.Windows.Forms.Label aname;
        private System.Windows.Forms.Label apass;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button alog;
        private System.Windows.Forms.Button button4;
    }
}