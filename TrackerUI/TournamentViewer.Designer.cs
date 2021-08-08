
namespace TrackerUI
{
    partial class TournamentViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentViewer));
            this.lTName = new System.Windows.Forms.Label();
            this.lRound = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cbUnplayedOnly = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lteamOne = new System.Windows.Forms.Label();
            this.lTeamTwo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTeamOne = new System.Windows.Forms.TextBox();
            this.tbTeamTwo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lTName
            // 
            this.lTName.AutoSize = true;
            this.lTName.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lTName.Location = new System.Drawing.Point(301, 23);
            this.lTName.Margin = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.lTName.Name = "lTName";
            this.lTName.Size = new System.Drawing.Size(73, 22);
            this.lTName.TabIndex = 1;
            this.lTName.Text = "TName";
            // 
            // lRound
            // 
            this.lRound.AutoSize = true;
            this.lRound.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lRound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lRound.Location = new System.Drawing.Point(33, 28);
            this.lRound.Margin = new System.Windows.Forms.Padding(10, 15, 10, 10);
            this.lRound.Name = "lRound";
            this.lRound.Size = new System.Drawing.Size(71, 22);
            this.lRound.TabIndex = 2;
            this.lRound.Text = "Round";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(107, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 25);
            this.comboBox1.TabIndex = 3;
            // 
            // cbUnplayedOnly
            // 
            this.cbUnplayedOnly.AutoSize = true;
            this.cbUnplayedOnly.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbUnplayedOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cbUnplayedOnly.Location = new System.Drawing.Point(107, 60);
            this.cbUnplayedOnly.Margin = new System.Windows.Forms.Padding(5);
            this.cbUnplayedOnly.Name = "cbUnplayedOnly";
            this.cbUnplayedOnly.Size = new System.Drawing.Size(136, 24);
            this.cbUnplayedOnly.TabIndex = 4;
            this.cbUnplayedOnly.Text = "Unplayed Only";
            this.cbUnplayedOnly.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(33, 99);
            this.listBox1.Margin = new System.Windows.Forms.Padding(10);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(209, 140);
            this.listBox1.TabIndex = 5;
            // 
            // lteamOne
            // 
            this.lteamOne.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lteamOne.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lteamOne.Location = new System.Drawing.Point(257, 169);
            this.lteamOne.Margin = new System.Windows.Forms.Padding(5);
            this.lteamOne.Name = "lteamOne";
            this.lteamOne.Size = new System.Drawing.Size(125, 25);
            this.lteamOne.TabIndex = 8;
            this.lteamOne.Text = "<team one>";
            this.lteamOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lTeamTwo
            // 
            this.lTeamTwo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTeamTwo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lTeamTwo.Location = new System.Drawing.Point(395, 169);
            this.lTeamTwo.Margin = new System.Windows.Forms.Padding(5);
            this.lTeamTwo.Name = "lTeamTwo";
            this.lTeamTwo.Size = new System.Drawing.Size(125, 25);
            this.lTeamTwo.TabIndex = 9;
            this.lTeamTwo.Text = "<team two>";
            this.lTeamTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(363, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "-VS-";
            // 
            // tbTeamOne
            // 
            this.tbTeamOne.Location = new System.Drawing.Point(418, 99);
            this.tbTeamOne.Name = "tbTeamOne";
            this.tbTeamOne.Size = new System.Drawing.Size(64, 23);
            this.tbTeamOne.TabIndex = 12;
            // 
            // tbTeamTwo
            // 
            this.tbTeamTwo.Location = new System.Drawing.Point(288, 99);
            this.tbTeamTwo.Name = "tbTeamTwo";
            this.tbTeamTwo.Size = new System.Drawing.Size(64, 23);
            this.tbTeamTwo.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = "Score";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(418, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(288, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lTName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 68);
            this.panel1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(175, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tournament :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.panel2.Controls.Add(this.lRound);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.tbTeamOne);
            this.panel2.Controls.Add(this.tbTeamTwo);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.cbUnplayedOnly);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.lteamOne);
            this.panel2.Controls.Add(this.lTeamTwo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 273);
            this.panel2.TabIndex = 18;
            // 
            // TournamentViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(534, 341);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TournamentViewer";
            this.Text = "Tournament Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lTName;
        private System.Windows.Forms.Label lRound;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox cbUnplayedOnly;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lteamOne;
        private System.Windows.Forms.Label lTeamTwo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTeamOne;
        private System.Windows.Forms.TextBox tbTeamTwo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
    }
}