namespace CompetencePlus.PackageDB
{
    partial class FormGestionDB
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
            this.IncTextBox = new System.Windows.Forms.TextBox();
            this.DecTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtExecute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IncTextBox
            // 
            this.IncTextBox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncTextBox.Location = new System.Drawing.Point(170, 65);
            this.IncTextBox.Multiline = true;
            this.IncTextBox.Name = "IncTextBox";
            this.IncTextBox.Size = new System.Drawing.Size(358, 126);
            this.IncTextBox.TabIndex = 0;
            // 
            // DecTextBox
            // 
            this.DecTextBox.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.DecTextBox.Location = new System.Drawing.Point(170, 230);
            this.DecTextBox.Multiline = true;
            this.DecTextBox.Name = "DecTextBox";
            this.DecTextBox.Size = new System.Drawing.Size(358, 126);
            this.DecTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(170, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Increment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Decrement";
            // 
            // BtExecute
            // 
            this.BtExecute.Location = new System.Drawing.Point(211, 372);
            this.BtExecute.Name = "BtExecute";
            this.BtExecute.Size = new System.Drawing.Size(75, 23);
            this.BtExecute.TabIndex = 4;
            this.BtExecute.Text = "Execute";
            this.BtExecute.UseVisualStyleBackColor = true;
            this.BtExecute.Click += new System.EventHandler(this.BtExecute_Click);
            // 
            // FormGestionDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 411);
            this.Controls.Add(this.BtExecute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DecTextBox);
            this.Controls.Add(this.IncTextBox);
            this.Name = "FormGestionDB";
            this.Text = "GestionDB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IncTextBox;
        private System.Windows.Forms.TextBox DecTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtExecute;
    }
}