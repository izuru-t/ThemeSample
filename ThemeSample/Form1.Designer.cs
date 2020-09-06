namespace ThemeSample
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
            this.button2 = new Kanami.Windows.Froms.Controls.Button();
            this.button3 = new Kanami.Windows.Froms.Controls.Button();
            this.button4 = new Kanami.Windows.Froms.Controls.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 79);
            this.button1.TabIndex = 0;
            this.button1.Text = "普通のボタン";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(39, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 100);
            this.button2.TabIndex = 1;
            this.button2.Text = "Themeありボタン１";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(39, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(198, 100);
            this.button3.TabIndex = 2;
            this.button3.Text = "Themeありボタン２";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(678, 382);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 56);
            this.button4.TabIndex = 3;
            this.button4.Text = "終了";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Kanami.Windows.Froms.Controls.Button button2;
        private Kanami.Windows.Froms.Controls.Button button3;
        private Kanami.Windows.Froms.Controls.Button button4;
    }
}