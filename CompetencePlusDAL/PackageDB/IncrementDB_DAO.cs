using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompetencePlus.Outils;

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
    }
}
