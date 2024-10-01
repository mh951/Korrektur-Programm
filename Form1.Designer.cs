namespace Korrektur_Programm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Schriften = new System.Windows.Forms.ComboBox();
            this.BreiteUndDruck = new System.Windows.Forms.Button();
            this.DruckPos = new System.Windows.Forms.Button();
            this.Beenden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(40, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(904, 81);
            this.label1.TabIndex = 0;
            this.label1.Text = "Korrekturporgramm für Schriften";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(-3, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1130, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "_________________________________________________________________________________" +
    "_______________________________________________________________________________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(238, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gewählte Schrift";
            // 
            // Schriften
            // 
            this.Schriften.FormattingEnabled = true;
            this.Schriften.Items.AddRange(new object[] {
            "LSchrift 1",
            "LSchrift 2",
            "LSchrift 3",
            "QSchrift 1",
            "QSchrift 2",
            "QSchrift 3"});
            this.Schriften.Location = new System.Drawing.Point(399, 372);
            this.Schriften.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Schriften.Name = "Schriften";
            this.Schriften.Size = new System.Drawing.Size(138, 28);
            this.Schriften.TabIndex = 3;
            // 
            // BreiteUndDruck
            // 
            this.BreiteUndDruck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BreiteUndDruck.Location = new System.Drawing.Point(383, 477);
            this.BreiteUndDruck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BreiteUndDruck.Name = "BreiteUndDruck";
            this.BreiteUndDruck.Size = new System.Drawing.Size(169, 57);
            this.BreiteUndDruck.TabIndex = 4;
            this.BreiteUndDruck.Text = "Druck Position";
            this.BreiteUndDruck.UseVisualStyleBackColor = true;
            this.BreiteUndDruck.Click += new System.EventHandler(this.BreiteUndDruck_Click);
            // 
            // DruckPos
            // 
            this.DruckPos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DruckPos.Location = new System.Drawing.Point(167, 477);
            this.DruckPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DruckPos.Name = "DruckPos";
            this.DruckPos.Size = new System.Drawing.Size(169, 57);
            this.DruckPos.TabIndex = 5;
            this.DruckPos.Text = "Breite und Druck";
            this.DruckPos.UseVisualStyleBackColor = true;
            this.DruckPos.Click += new System.EventHandler(this.DruckPos_Click);
            // 
            // Beenden
            // 
            this.Beenden.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Beenden.Location = new System.Drawing.Point(602, 477);
            this.Beenden.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Beenden.Name = "Beenden";
            this.Beenden.Size = new System.Drawing.Size(169, 57);
            this.Beenden.TabIndex = 6;
            this.Beenden.Text = "Beenden";
            this.Beenden.UseVisualStyleBackColor = true;
            this.Beenden.Click += new System.EventHandler(this.Beenden_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 600);
            this.Controls.Add(this.Beenden);
            this.Controls.Add(this.DruckPos);
            this.Controls.Add(this.BreiteUndDruck);
            this.Controls.Add(this.Schriften);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Korrektur";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox Schriften;
        private Button BreiteUndDruck;
        private Button DruckPos;
        private Button Beenden;
    }
}