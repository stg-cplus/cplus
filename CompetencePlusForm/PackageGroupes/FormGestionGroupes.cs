using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CompetencePlus.PackageFilieres;

namespace CompetencePlus.PackageGroupes
{
    public partial class FormGestionGroupes : Form
    {
        public FormGestionGroupes()
        {
            InitializeComponent();
        }
        public void refresh() {
            groupeBindingSource.DataSource = null;
            groupeBindingSource.DataSource = new GroupeBAO().Select();
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            FormGroupe f = new FormGroupe();
            f.ShowDialog();
            this.refresh();

        }

        private void FormGestionGroupes_Load(object sender, EventArgs e)
        {
            this.refresh();
            filiereBindingSource.DataSource = null;
            filiereBindingSource.DataSource = new FiliereBAO().Select();
        
                Groupe groupe = (Groupe)groupeBindingSource.Current;
                if (groupe != null)
                {
                    NomLabel.Text = groupe.Nom;
                    CodeLabel.Text = groupe.Code;
                }
          
        }

        private void groupeDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                Groupe g = (Groupe)groupeBindingSource.Current;
                NomLabel.Text = g.Nom;
                CodeLabel.Text = g.Code;
                if (e.ColumnIndex == 3)
                {
                    FormUpdateGroupe f = new FormUpdateGroupe();
                    f.Update(g);
                    f.ShowDialog();
                    this.refresh();
                }
                if (e.ColumnIndex == 4 && MessageBox.Show("voulez vous supprimer cette groupe", "Information dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    new GroupeBAO().Delete(g.Id);
                    this.refresh();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BtFirst_Click(object sender, EventArgs e)
        {
            groupeBindingSource.Position = 0;
            try
            {
                Groupe g = (Groupe)groupeBindingSource.Current;
                NomLabel.Text = g.Nom;
                CodeLabel.Text = g.Code;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtPrevious_Click(object sender, EventArgs e)
        {
            groupeBindingSource.Position = groupeBindingSource.Position-1;
            try
            {
                Groupe g = (Groupe)groupeBindingSource.Current;
                NomLabel.Text = g.Nom;
                CodeLabel.Text = g.Code;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            groupeBindingSource.Position = groupeBindingSource.Position + 1;
            try
            {
                Groupe g = (Groupe)groupeBindingSource.Current;
                NomLabel.Text = g.Nom;
                CodeLabel.Text = g.Code;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtLast_Click(object sender, EventArgs e)
        {
            groupeBindingSource.Position = groupeBindingSource.Count;
            try
            {
                Groupe g = (Groupe)groupeBindingSource.Current;
                NomLabel.Text = g.Nom;
                CodeLabel.Text = g.Code;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtResearch_Click(object sender, EventArgs e)
        {
            Groupe g = new Groupe();
            g.Nom = NomTextBox.Text;
            g.Code = CodeTextBox.Text;
            g.Filiere = (Filiere)filiereBindingSource.Current;
            g.Description = DescriptionTextBox.Text;
           groupeBindingSource.DataSource= new GroupeBAO().FindByGroup(g);
        }
    }
}
