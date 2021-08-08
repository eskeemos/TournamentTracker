
namespace TrackerUI
{
    partial class PrizeCreate
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
            this.label5 = new System.Windows.Forms.Label();
            this.tbPlaceNumber = new System.Windows.Forms.TextBox();
            this.bCreatePrize = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPrizePercentage = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPrizeAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPlaceName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(95, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "Place Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(168, 148);
            this.label5.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 22);
            this.label5.TabIndex = 20;
            this.label5.Text = "-or-";
            // 
            // tbPlaceNumber
            // 
            this.tbPlaceNumber.Location = new System.Drawing.Point(262, 30);
            this.tbPlaceNumber.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.tbPlaceNumber.Name = "tbPlaceNumber";
            this.tbPlaceNumber.Size = new System.Drawing.Size(133, 23);
            this.tbPlaceNumber.TabIndex = 29;
            // 
            // bCreatePrize
            // 
            this.bCreatePrize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.bCreatePrize.Location = new System.Drawing.Point(180, 224);
            this.bCreatePrize.Name = "bCreatePrize";
            this.bCreatePrize.Size = new System.Drawing.Size(154, 43);
            this.bCreatePrize.TabIndex = 33;
            this.bCreatePrize.Text = "Create Prize";
            this.bCreatePrize.UseVisualStyleBackColor = true;
            this.bCreatePrize.Click += new System.EventHandler(this.bCreatePrize_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 68);
            this.panel1.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(214, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 22);
            this.label6.TabIndex = 1;
            this.label6.Text = "Create Prize";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(138, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "label7";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbPrizePercentage);
            this.panel2.Controls.Add(this.bCreatePrize);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.tbPrizeAmount);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tbPlaceName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbPlaceNumber);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 289);
            this.panel2.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label2.Location = new System.Drawing.Point(95, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 22);
            this.label2.TabIndex = 34;
            this.label2.Text = "Prize Percentage";
            // 
            // tbPrizePercentage
            // 
            this.tbPrizePercentage.Location = new System.Drawing.Point(262, 185);
            this.tbPrizePercentage.Name = "tbPrizePercentage";
            this.tbPrizePercentage.Size = new System.Drawing.Size(133, 23);
            this.tbPrizePercentage.TabIndex = 35;
            this.tbPrizePercentage.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label10.Location = new System.Drawing.Point(95, 113);
            this.label10.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 22);
            this.label10.TabIndex = 32;
            this.label10.Text = "Prize Amount";
            // 
            // tbPrizeAmount
            // 
            this.tbPrizeAmount.Location = new System.Drawing.Point(262, 112);
            this.tbPrizeAmount.Name = "tbPrizeAmount";
            this.tbPrizeAmount.Size = new System.Drawing.Size(133, 23);
            this.tbPrizeAmount.TabIndex = 33;
            this.tbPrizeAmount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label8.Location = new System.Drawing.Point(95, 70);
            this.label8.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 22);
            this.label8.TabIndex = 30;
            this.label8.Text = "Place Name";
            // 
            // tbPlaceName
            // 
            this.tbPlaceName.Location = new System.Drawing.Point(262, 71);
            this.tbPlaceName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.tbPlaceName.Name = "tbPlaceName";
            this.tbPlaceName.Size = new System.Drawing.Size(133, 23);
            this.tbPlaceName.TabIndex = 31;
            // 
            // PrizeCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 357);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PrizeCreate";
            this.Text = "PrizeCreate";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPlaceNumber;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPrizeAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbPlaceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bCreatePrize;
        private System.Windows.Forms.TextBox tbPrizePercentage;
    }
}