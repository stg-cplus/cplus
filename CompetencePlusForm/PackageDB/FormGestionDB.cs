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

        private void BtExecute_Click(object sender, EventArgs e)
        {
            IncrementationDB inc = new IncrementationDB();
            inc.Id = 0;
            inc.Code = DateTime.Today.ToString()+"/";
            inc.Increment = IncTextBox.Text;
            inc.Decrement = DecTextBox.Text;
            new IncrementDB_DAO().Add(inc);
            new IncrementDB_DAO().Create(IncTextBox.Text);
           
        }
    }
}
