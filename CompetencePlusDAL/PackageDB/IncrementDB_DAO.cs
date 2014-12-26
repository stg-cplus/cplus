using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompetencePlus.Outils;
using System.Data.OleDb;
using System.Xml.Serialization;
using System.IO;

namespace CompetencePlus.PackageDB
{
   public class IncrementDB_DAO
    {

       public void Add(IncrementationDB Incrementation) {
           // Exécution de la requête
           this.Create(Incrementation);

           // Aprés l'exécution de la requête - l'enregistrement dans un fichiers
           XmlSerializer xs = new XmlSerializer(typeof(IncrementationDB));
           using (StreamWriter wr = new StreamWriter("db_query/" + Incrementation.Code + ".xml"))
           {
               xs.Serialize(wr, Incrementation);
           }
       }
       public void Create(IncrementationDB increment)
       {
           // Exécution de la requête
           MyConnection.ExecuteNonQuery(increment.Increment);
           // Modification de la version de la base de données
           string query = "Insert into VersionDB(Version) values('" + increment.Code + "');";
           MyConnection.ExecuteNonQuery(query);
 
       }
       public IncrementationDB findByCode(string code) {
           XmlSerializer xs = new XmlSerializer(typeof(IncrementationDB));
           StreamReader rd = new StreamReader(@"db_query/" + code + ".xml");
           IncrementationDB incrementation = xs.Deserialize(rd) as IncrementationDB;
           return incrementation;
       }

    

       public void Delete(IncrementationDB incrementation)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"db_query/");
            System.IO.File.Delete(@"db_query/" + incrementation.Code  + ".xml");
        }

       public IEnumerable<IncrementationDB> Select()
        {

            List<IncrementationDB> List = new List<IncrementationDB>();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"db_query/");
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.xml", System.IO.SearchOption.TopDirectoryOnly).OrderByDescending(f => f.Name);
            foreach (var file in fileList)
            {

                XmlSerializer xs = new XmlSerializer(typeof(IncrementationDB));
                StreamReader rd = new StreamReader("db_query/" + file.Name);
                IncrementationDB incrementation = xs.Deserialize(rd) as IncrementationDB;
                rd.Dispose();
                List.Add(incrementation);
              
            }
       
            return List.OrderByDescending(i => i.DateCreation).ToList<IncrementationDB>();
        }

        public IncrementationDB TemplteCreateTable()
        {
            XmlSerializer xs = new XmlSerializer(typeof(IncrementationDB));
            StreamReader rd = new StreamReader(@"db_query/Templates/CREATE-TABLE.xml");
            IncrementationDB incrementation = xs.Deserialize(rd) as IncrementationDB;
            return incrementation;
        }

        public bool Initialisation()
        {
            // Vérification de l'existance de la base de données
            if (!MyConnection.isDabaseExist()) { 
                // Création de la base de données 
                MyConnection.CreateNewAccessDatabase("db_cplus.accdb");
               // throw new Exception(@"La base de données n'existe pas dans le chemin 'C:\db_cplus\db_cplus.accdb' ");
            }

            // Vérification de l'existence de la table VersionDB
            if (!MyConnection.isTableExist("VersionDB"))
            {
                String query = "CREATE TABLE VersionDB ( ID AUTOINCREMENT PRIMARY KEY, Version varchar(255));";
                MyConnection.ExecuteNonQuery(query);
            }

            // Update de la base de données depuis les requêtes SQL
            this.UpgradeDaTabase();
            return true;
        }

        private void UpgradeDaTabase()
        {

            String CodeLastIncrement = this.CodeLastIncrement();
            IEnumerable<IncrementationDB> ListeIncrement;
            if (CodeLastIncrement != null)
            {
                IncrementationDB LastIncrement = this.findByCode(CodeLastIncrement);
                ListeIncrement = this.Select().Where(i => i.DateCreation > LastIncrement.DateCreation);
            }
            else {
                ListeIncrement = this.Select();
            }


            foreach (var increment in ListeIncrement.OrderBy(i=>i.DateCreation))
            {
                this.Create(increment);
            }

        }

       private String CodeLastIncrement(){
            String max_query = "select max(id) from VersionDB";
            OleDbDataReader read_max = MyConnection.ExecuteReader(max_query);
           
            if (read_max.Read())
            {
                int max;
                try
                {
                      max = read_max.GetInt32(0);
                }
                catch (Exception)
                {

                    return null;
                }
               
                String lastInrement_query = "select * from VersionDB where id = " + max;
                OleDbDataReader lastInrement = MyConnection.ExecuteReader(lastInrement_query);
                lastInrement.Read();
                String CodeLastIncrement = lastInrement.GetString(1).ToString();
                return CodeLastIncrement;
            }
            else {
                return null;
            }
       }
    }
}
