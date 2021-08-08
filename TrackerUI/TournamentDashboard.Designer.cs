
namespace TrackerUI
{
    partial class TournamentDashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bCreateTournament = new System.Windows.Forms.Button();
            this.bLoadTournament = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 68);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(153, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tournament Dashboard";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.panel2.Controls.Add(this.bCreateTournament);
            this.panel2.Controls.Add(this.bLoadTournament);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 243);
            this.panel2.TabIndex = 1;
            // 
            // bCreateTournament
            // 
            this.bCreateTournament.Location = new System.Drawing.Point(279, 138);
            this.bCreateTournament.Name = "bCreateTournament";
            this.bCreateTournament.Size = new System.Drawing.Size(150, 40);
            this.bCreateTournament.TabIndex = 3;
            this.bCreateTournament.Text = "Create Tournament";
            this.bCreateTournament.UseVisualStyleBackColor = true;
            // 
            // bLoadTournament
            // 
            this.bLoadTournament.Location = new System.Drawing.Point(108, 138);
            this.bLoadTournament.Name = "bLoadTournament";
            this.bLoadTournament.Size = new System.Drawing.Size(150, 40);
            this.bLoadTournament.TabIndex = 2;
            this.bLoadTournament.Text = "Load Tournament";
            this.bLoadTournament.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(172, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(190, 25);
            this.comboBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(146, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Load Existing Tournament";
            // 
            // TournamentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TournamentDashboard";
            this.Text = "TournamentDashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bCreateTournament;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bLoadTournament;
    }
}