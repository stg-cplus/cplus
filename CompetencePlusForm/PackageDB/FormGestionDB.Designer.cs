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
            this.components = new System.ComponentModel.Container();
            this.IncTextBox = new System.Windows.Forms.TextBox();
            this.DecTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtExecute = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btSuivant = new System.Windows.Forms.Button();
            this.incrementationDBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.incrementationDBBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // IncTextBox
            // 
            this.IncTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.incrementationDBBindingSource, "Increment", true));
            this.IncTextBox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncTextBox.Location = new System.Drawing.Point(6, 46);
            this.IncTextBox.Multiline = true;
            this.IncTextBox.Name = "IncTextBox";
            this.IncTextBox.Size = new System.Drawing.Size(386, 126);
            this.IncTextBox.TabIndex = 0;
            // 
            // DecTextBox
            // 
            this.DecTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.incrementationDBBindingSource, "Decrement", true));
            this.DecTextBox.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.DecTextBox.Location = new System.Drawing.Point(6, 198);
            this.DecTextBox.Multiline = true;
            this.DecTextBox.Name = "DecTextBox";
            this.DecTextBox.Size = new System.Drawing.Size(386, 122);
            this.DecTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Increment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Decrement";
            // 
            // BtExecute
            // 
            this.BtExecute.Location = new System.Drawing.Point(446, 360);
            this.BtExecute.Name = "BtExecute";
            this.BtExecute.Size = new System.Drawing.Size(75, 23);
            this.BtExecute.TabIndex = 4;
            this.BtExecute.Text = "Execute";
            this.BtExecute.UseVisualStyleBackColor = true;
            this.BtExecute.Click += new System.EventHandler(this.BtExecute_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.incrementationDBBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(20, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(210, 301);
            this.dataGridView1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 337);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Versions";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.IncTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.DecTextBox);
            this.groupBox2.Location = new System.Drawing.Point(270, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 337);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Requête";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(293, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Version précident";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btSuivant
            // 
            this.btSuivant.Location = new System.Drawing.Point(552, 360);
            this.btSuivant.Name = "btSuivant";
            this.btSuivant.Size = new System.Drawing.Size(116, 23);
            this.btSuivant.TabIndex = 9;
            this.btSuivant.Text = "Version suivant";
            this.btSuivant.UseVisualStyleBackColor = true;
            // 
            // incrementationDBBindingSource
            // 
            this.incrementationDBBindingSource.DataSource = typeof(CompetencePlus.PackageDB.IncrementationDB);
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            // 
            // FormGestionDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 398);
            this.Controls.Add(this.btSuivant);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtExecute);
            this.Name = "FormGestionDB";
            this.Text = "GestionDB";
            this.Load += new System.EventHandler(this.FormGestionDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.incrementationDBBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox IncTextBox;
        private System.Windows.Forms.TextBox DecTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtExecute;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btSuivant;
        private System.Windows.Forms.BindingSource incrementationDBBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
    }
}