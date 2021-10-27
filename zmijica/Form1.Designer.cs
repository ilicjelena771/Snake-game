namespace zmijica
{
    partial class zmijica
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
            this.glava = new System.Windows.Forms.PictureBox();
            this.hrana = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.glava)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrana)).BeginInit();
            this.SuspendLayout();
            // 
            // glava
            // 
            this.glava.BackColor = System.Drawing.Color.Red;
            this.glava.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.glava.Location = new System.Drawing.Point(40, 40);
            this.glava.Name = "glava";
            this.glava.Size = new System.Drawing.Size(20, 20);
            this.glava.TabIndex = 0;
            this.glava.TabStop = false;
            this.glava.Visible = false;
            // 
            // hrana
            // 
            this.hrana.BackColor = System.Drawing.SystemColors.HotTrack;
            this.hrana.Location = new System.Drawing.Point(100, 160);
            this.hrana.Name = "hrana";
            this.hrana.Size = new System.Drawing.Size(20, 20);
            this.hrana.TabIndex = 1;
            this.hrana.TabStop = false;
            this.hrana.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(274, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Zapocni igru";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 541);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(493, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // zmijica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(484, 481);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hrana);
            this.Controls.Add(this.glava);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "zmijica";
            this.Text = "Zmijica";
            this.Load += new System.EventHandler(this.zmijica_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.glava)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrana)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox glava;
        private System.Windows.Forms.PictureBox hrana;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

