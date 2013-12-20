namespace U2_Passkey_Converter
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAPI = new System.Windows.Forms.TextBox();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.buttonDat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTracker = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Resume.dat";
            // 
            // textBoxDat
            // 
            this.textBoxDat.Font = new System.Drawing.Font("Microsoft YaHei", 18F);
            this.textBoxDat.Location = new System.Drawing.Point(12, 43);
            this.textBoxDat.Name = "textBoxDat";
            this.textBoxDat.Size = new System.Drawing.Size(540, 39);
            this.textBoxDat.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "API";
            // 
            // textBoxAPI
            // 
            this.textBoxAPI.Font = new System.Drawing.Font("Microsoft YaHei", 18F);
            this.textBoxAPI.Location = new System.Drawing.Point(12, 119);
            this.textBoxAPI.Name = "textBoxAPI";
            this.textBoxAPI.Size = new System.Drawing.Size(590, 39);
            this.textBoxAPI.TabIndex = 3;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Font = new System.Drawing.Font("Microsoft YaHei", 18F);
            this.buttonConvert.Location = new System.Drawing.Point(466, 240);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(136, 45);
            this.buttonConvert.TabIndex = 4;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // buttonDat
            // 
            this.buttonDat.Font = new System.Drawing.Font("Microsoft YaHei", 18F);
            this.buttonDat.Location = new System.Drawing.Point(558, 43);
            this.buttonDat.Name = "buttonDat";
            this.buttonDat.Size = new System.Drawing.Size(44, 39);
            this.buttonDat.TabIndex = 5;
            this.buttonDat.Text = "...";
            this.buttonDat.UseVisualStyleBackColor = true;
            this.buttonDat.Click += new System.EventHandler(this.buttonDat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tracker";
            // 
            // textBoxTracker
            // 
            this.textBoxTracker.Font = new System.Drawing.Font("Microsoft YaHei", 18F);
            this.textBoxTracker.Location = new System.Drawing.Point(12, 195);
            this.textBoxTracker.Name = "textBoxTracker";
            this.textBoxTracker.Size = new System.Drawing.Size(590, 39);
            this.textBoxTracker.TabIndex = 7;
            this.textBoxTracker.Text = "https://tracker.dmhy.org/announce.php?secure=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 289);
            this.Controls.Add(this.textBoxTracker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonDat);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.textBoxAPI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDat);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "U2 Passkey Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAPI;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Button buttonDat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTracker;
    }
}

