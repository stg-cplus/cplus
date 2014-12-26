using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompetencePlus.Outils;
using System.Data.OleDb;

namespace CompetencePlus.PackageDB
{
   public class IncrementDB_DAO
    {
       public void Add(IncrementationDB IncDB) {

           string Requete = "Insert into IncrementationDB(code,Increment,decrement) values('"+IncDB.Code+"','"+IncDB.Increment+"','"+IncDB.Decrement+"')";
           MyConnection.ExecuteNonQuery(Requete);
       }

        public void Create(string Requete) {

            MyConnection.ExecuteNonQuery(Requete);
        }

        public void Drop(string Requete)
        {
            MyConnection.ExecuteNonQuery(Requete);
        }

        public void Delete(int id)
        {
            String Requete = "Delete from IncrementationDB where id =" + id;
            MyConnection.ExecuteNonQuery(Requete);
        }

        public List<IncrementationDB> Select()
        {
            List<IncrementationDB> List = new List<IncrementationDB>();
            String Requete = "Select * from IncrementationDB ";
            OleDbDataReader read = MyConnection.ExecuteReader(Requete);
            while (read.Read())
            {
                IncrementationDB i = new IncrementationDB();
                i.Id = read.GetInt32(0);
                i.Increment = read.GetString(1);
                i.Decrement = read.GetString(2);

                List.Add(i);


            }
            return List;
        }

        public bool Initialisation()
        {
            // Vérification de l'existance de la base de données
            if (!MyConnection.isDabaseExist()) { 
             throw new Exception(@"La base de données n'existe pas dans le chemin 'C:\db_cplus\db_cplus.accdb' ");
            }

            // Vérification de l'existence de la table IncrementationDB
            if ( !MyConnection.isTableExist("IncrementationDB")){
             String query = "CREATE TABLE IncrementationDB ( ID AUTOINCREMENT PRIMARY KEY, Code varchar(255), Increment varchar(255), Decrement varchar(255) );";
             this.Create(query);
            }
            return true;
        }
    }
}
