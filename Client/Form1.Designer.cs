﻿namespace Client
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
            this.button2 = new System.Windows.Forms.Button();
            this.buttonAuth = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelToken = new System.Windows.Forms.Label();
            this.buttonTheory = new System.Windows.Forms.Button();
            this.buttonTests = new System.Windows.Forms.Button();
            this.buttonJournal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(304, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonAuth
            // 
            this.buttonAuth.Location = new System.Drawing.Point(350, 12);
            this.buttonAuth.Name = "buttonAuth";
            this.buttonAuth.Size = new System.Drawing.Size(75, 40);
            this.buttonAuth.TabIndex = 2;
            this.buttonAuth.Text = "Войти в систему";
            this.buttonAuth.UseVisualStyleBackColor = true;
            this.buttonAuth.Click += new System.EventHandler(this.buttonAuth_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(350, 69);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(75, 41);
            this.buttonLogOut.TabIndex = 3;
            this.buttonLogOut.Text = "Выйти из системы";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.ForeColor = System.Drawing.Color.Red;
            this.labelLogin.Location = new System.Drawing.Point(23, 12);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(0, 20);
            this.labelLogin.TabIndex = 4;
            // 
            // labelToken
            // 
            this.labelToken.AutoSize = true;
            this.labelToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelToken.ForeColor = System.Drawing.Color.Red;
            this.labelToken.Location = new System.Drawing.Point(23, 39);
            this.labelToken.Name = "labelToken";
            this.labelToken.Size = new System.Drawing.Size(0, 20);
            this.labelToken.TabIndex = 5;
            // 
            // buttonTheory
            // 
            this.buttonTheory.Location = new System.Drawing.Point(27, 78);
            this.buttonTheory.Name = "buttonTheory";
            this.buttonTheory.Size = new System.Drawing.Size(99, 23);
            this.buttonTheory.TabIndex = 6;
            this.buttonTheory.Text = "Теория";
            this.buttonTheory.UseVisualStyleBackColor = true;
            this.buttonTheory.Visible = false;
            this.buttonTheory.Click += new System.EventHandler(this.buttonTheory_Click);
            // 
            // buttonTests
            // 
            this.buttonTests.Location = new System.Drawing.Point(27, 107);
            this.buttonTests.Name = "buttonTests";
            this.buttonTests.Size = new System.Drawing.Size(99, 23);
            this.buttonTests.TabIndex = 7;
            this.buttonTests.Text = "Тестирование";
            this.buttonTests.UseVisualStyleBackColor = true;
            this.buttonTests.Click += new System.EventHandler(this.buttonTests_Click);
            // 
            // buttonJournal
            // 
            this.buttonJournal.Location = new System.Drawing.Point(27, 136);
            this.buttonJournal.Name = "buttonJournal";
            this.buttonJournal.Size = new System.Drawing.Size(99, 23);
            this.buttonJournal.TabIndex = 8;
            this.buttonJournal.Text = "Журнал";
            this.buttonJournal.UseVisualStyleBackColor = true;
            this.buttonJournal.Visible = false;
            this.buttonJournal.Click += new System.EventHandler(this.buttonJournal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 258);
            this.Controls.Add(this.buttonJournal);
            this.Controls.Add(this.buttonTests);
            this.Controls.Add(this.buttonTheory);
            this.Controls.Add(this.labelToken);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.buttonAuth);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonAuth;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelToken;
        private System.Windows.Forms.Button buttonTheory;
        private System.Windows.Forms.Button buttonTests;
        private System.Windows.Forms.Button buttonJournal;
    }
}

