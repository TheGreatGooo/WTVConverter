namespace WTVConverter
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.fromText = new System.Windows.Forms.TextBox();
            this.toText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backupText = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.fromButton = new System.Windows.Forms.Button();
            this.toButton = new System.Windows.Forms.Button();
            this.errorButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.optionsPnl = new System.Windows.Forms.Panel();
            this.optionsBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.autostartupChk = new System.Windows.Forms.CheckBox();
            this.saveOptnsBtn = new System.Windows.Forms.Button();
            this.optionsPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalExtent = 1600;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(12, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(883, 238);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Run Process Adhoc";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fromText
            // 
            this.fromText.Location = new System.Drawing.Point(340, 8);
            this.fromText.Name = "fromText";
            this.fromText.ReadOnly = true;
            this.fromText.Size = new System.Drawing.Size(259, 20);
            this.fromText.TabIndex = 2;
            this.fromText.Text = "F:\\Recorded TV";
            // 
            // toText
            // 
            this.toText.Location = new System.Drawing.Point(340, 47);
            this.toText.Name = "toText";
            this.toText.ReadOnly = true;
            this.toText.Size = new System.Drawing.Size(259, 20);
            this.toText.TabIndex = 3;
            this.toText.Text = "F:\\share\\convert";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Recorded TV Folder";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destination Folder (incase of ComSkip or similar)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Destination Folder for files which have errors during conversion";
            // 
            // backupText
            // 
            this.backupText.Location = new System.Drawing.Point(340, 87);
            this.backupText.Name = "backupText";
            this.backupText.ReadOnly = true;
            this.backupText.Size = new System.Drawing.Size(259, 20);
            this.backupText.TabIndex = 7;
            this.backupText.Text = "F:\\share\\backup";
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fromButton
            // 
            this.fromButton.Location = new System.Drawing.Point(605, 6);
            this.fromButton.Name = "fromButton";
            this.fromButton.Size = new System.Drawing.Size(75, 23);
            this.fromButton.TabIndex = 8;
            this.fromButton.Text = "Choose..";
            this.fromButton.UseVisualStyleBackColor = true;
            this.fromButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // toButton
            // 
            this.toButton.Location = new System.Drawing.Point(605, 45);
            this.toButton.Name = "toButton";
            this.toButton.Size = new System.Drawing.Size(75, 23);
            this.toButton.TabIndex = 9;
            this.toButton.Text = "Choose..";
            this.toButton.UseVisualStyleBackColor = true;
            this.toButton.Click += new System.EventHandler(this.toButton_Click);
            // 
            // errorButton
            // 
            this.errorButton.Location = new System.Drawing.Point(605, 85);
            this.errorButton.Name = "errorButton";
            this.errorButton.Size = new System.Drawing.Size(75, 23);
            this.errorButton.TabIndex = 10;
            this.errorButton.Text = "Choose..";
            this.errorButton.UseVisualStyleBackColor = true;
            this.errorButton.Click += new System.EventHandler(this.errorButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Log";
            // 
            // optionsPnl
            // 
            this.optionsPnl.Controls.Add(this.saveOptnsBtn);
            this.optionsPnl.Controls.Add(this.autostartupChk);
            this.optionsPnl.Controls.Add(this.label5);
            this.optionsPnl.Controls.Add(this.label1);
            this.optionsPnl.Controls.Add(this.fromText);
            this.optionsPnl.Controls.Add(this.errorButton);
            this.optionsPnl.Controls.Add(this.fromButton);
            this.optionsPnl.Controls.Add(this.backupText);
            this.optionsPnl.Controls.Add(this.toButton);
            this.optionsPnl.Controls.Add(this.label3);
            this.optionsPnl.Controls.Add(this.label2);
            this.optionsPnl.Controls.Add(this.toText);
            this.optionsPnl.Location = new System.Drawing.Point(127, 311);
            this.optionsPnl.Name = "optionsPnl";
            this.optionsPnl.Size = new System.Drawing.Size(692, 177);
            this.optionsPnl.TabIndex = 12;
            this.optionsPnl.Visible = false;
            // 
            // optionsBtn
            // 
            this.optionsBtn.Location = new System.Drawing.Point(820, 272);
            this.optionsBtn.Name = "optionsBtn";
            this.optionsBtn.Size = new System.Drawing.Size(75, 23);
            this.optionsBtn.TabIndex = 13;
            this.optionsBtn.Text = "Options";
            this.optionsBtn.UseVisualStyleBackColor = true;
            this.optionsBtn.Click += new System.EventHandler(this.optionsBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Start automatically on application startup";
            // 
            // autostartupChk
            // 
            this.autostartupChk.AutoSize = true;
            this.autostartupChk.Location = new System.Drawing.Point(340, 117);
            this.autostartupChk.Name = "autostartupChk";
            this.autostartupChk.Size = new System.Drawing.Size(15, 14);
            this.autostartupChk.TabIndex = 12;
            this.autostartupChk.UseVisualStyleBackColor = true;
            this.autostartupChk.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // saveOptnsBtn
            // 
            this.saveOptnsBtn.Location = new System.Drawing.Point(250, 142);
            this.saveOptnsBtn.Name = "saveOptnsBtn";
            this.saveOptnsBtn.Size = new System.Drawing.Size(105, 23);
            this.saveOptnsBtn.TabIndex = 13;
            this.saveOptnsBtn.Text = "Save Options";
            this.saveOptnsBtn.UseVisualStyleBackColor = true;
            this.saveOptnsBtn.Click += new System.EventHandler(this.saveOptnsBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 307);
            this.Controls.Add(this.optionsBtn);
            this.Controls.Add(this.optionsPnl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Convert";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.optionsPnl.ResumeLayout(false);
            this.optionsPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox fromText;
        private System.Windows.Forms.TextBox toText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox backupText;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button fromButton;
        private System.Windows.Forms.Button toButton;
        private System.Windows.Forms.Button errorButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel optionsPnl;
        private System.Windows.Forms.Button optionsBtn;
        private System.Windows.Forms.CheckBox autostartupChk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveOptnsBtn;
    }
}

