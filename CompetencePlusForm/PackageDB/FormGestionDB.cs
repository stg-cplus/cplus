using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CompetencePlus.PackageDB
{
    public partial class FormGestionDB : Form
    {
        public FormGestionDB()
        {
            InitializeComponent();
        }

        public void refresh()
        {
           
            incrementationDBBindingSource.DataSource = new IncrementDB_BAO().Select();
             

        }
        private void charger(IncrementationDB increment) {

           IncTextBox.Text = increment.Increment;
           //DecTextBox.Text = increment.Decrement;
           textBoxTitre.Text = increment.Titre;
        }
        private void BtExecute_Click(object sender, EventArgs e)
        {
            IncrementationDB inc = new IncrementationDB();
            inc.Increment = IncTextBox.Text;
            //inc.Decrement = DecTextBox.Text;
            inc.Titre = textBoxTitre.Text;
            try
            {
                new IncrementDB_BAO().Add(inc);
                refresh();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            } 
             
           
        }

        private void FormGestionDB_Load(object sender, EventArgs e)
        {
            this.refresh();
           
        }

        private void btSuivant_Click(object sender, EventArgs e)
        {
            incrementationDBBindingSource.MoveNext();
        }

        private void brPrecedent_Click(object sender, EventArgs e)
        {
            incrementationDBBindingSource.MovePrevious();
        }

        private void btCreateTable_Click(object sender, EventArgs e)
        {
           IncrementationDB inc =  new IncrementDB_BAO().TemplteCreateTable();
           this.charger(inc);

        }

        private void IncTextBox_TextChanged(object sender, EventArgs e)
        {
            String[] ls;
            ls =  IncTextBox.Text.Split();
            textBoxTitre.Text = ls[0];
            for (int i = 1; i < 3 && i < (ls.Length-1); i++)
            {
                textBoxTitre.Text += "-" +  ls[i];
            }

        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            IncrementationDB inc = (IncrementationDB)incrementationDBBindingSource.Current;
            new IncrementDB_BAO().Delete(inc);
            this.refresh();
        }

        
    }
}
