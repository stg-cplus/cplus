using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using ADOX;
using CompetencePlus.PackageDB; //Requires Microsoft ADO Ext. 2.8 for DDL and Security

namespace CompetencePlus.Tools
{
    public class DataBaseCreator
    {
        private  OleDbConnection connection;
        private  OleDbCommand command;
        private  String dataBaseName;
        ///  En mode développement la base de données doit être installé dans le chemin suivant "C:\db_cplus\db_cplus.accdb"
        ///  En mode déploiement la base de données doit être installer dans le répertoire projet
        /// string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\CompétencePlus.accdb;Persist Security Info=True";
        private string connectionString;

        public  DataBaseCreator(String DataBaseName) {
            this.dataBaseName = DataBaseName;
            this.connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= "+ this.dataBaseName + ".accdb;Persist Security Info=True";
        }

        #region Excution des requêtes SQL
        /// <summary>
        /// Exécuter les requêtes SQL : Update, Delete, Insert
        /// </summary>
        /// <param name="Requete">La requête SQL à exécuter</param>
        public  int ExecuteQuery(string Requete)
        {
            connection = new OleDbConnection(connectionString);
            command = connection.CreateCommand();
            command.CommandText = Requete;
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }
        /// <summary>
        /// Exécute la requête SQL : Select
        /// </summary>
        /// <param name="Requete"></param>
        /// <returns></returns>
        public  OleDbDataReader ExecuteReader(string Requete)
        {
            connection = new OleDbConnection(connectionString);
            command = connection.CreateCommand();
            command.CommandText = Requete;
            connection.Open();
            OleDbDataReader read = command.ExecuteReader();
            return read;
        }
        /// <summary>
        /// Fermiture de la connexion aprés l'appelle de la méthode "ExecuteNonQuery"
        /// </summary>
        public  void Close()
        {
            connection.Close();
        }

        #endregion

        #region Version de la base données
        /// <summary>
        /// Trouver le code du la dernier requête exécuter sur la base de donénes
        /// </summary>
        /// <returns></returns>
        public String CodeLastIncrement()
        {
            String max_query = "select max(id) from VersionDB";
            OleDbDataReader read_max = this.ExecuteReader(max_query);
            if (read_max.Read()) {
                int max;
                try{
                    max = read_max.GetInt32(0);
                    this.Close();
                }
                catch (Exception){
                    this.Close();
                    return null;
                }

                String lastInrement_query = "select * from VersionDB where id = " + max;
                OleDbDataReader lastInrement = this.ExecuteReader(lastInrement_query);
                lastInrement.Read();
                String CodeLastIncrement = lastInrement.GetString(1).ToString();
                this.Close();
                return CodeLastIncrement;
            }
            else {
                return null;
            }
        }
        #endregion

        #region Existances des Objets dans la base de données
        /// <summary>
        /// Vérifier l'existence de la base de données
        /// </summary>
        public  bool isDabaseExist()
        {
            try
            {
                connection = new OleDbConnection(connectionString);
                connection.Open();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Vérificer l'existance d'une table
        /// </summary>
        public  bool isTableExist(string NomTable)
        {
            try
            {
                String Requete = "select * from " + NomTable;
                connection = new OleDbConnection(connectionString);
                command = connection.CreateCommand();
                command.CommandText = Requete;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
       


        #region Initiation et création de la base de données
        /// <summary>
        /// Création de la base de données Acces
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool CreateAccessDatabase()
        {
            bool result = false;
            ADOX.Catalog cat = new ADOX.Catalog();
            ADOX.Table table = new ADOX.Table();
            //Create the table and it's fields. 
            table.Name = "Table1";
            table.Columns.Append("Field1");
            table.Columns.Append("Field2");
            try
            {
                cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + this.dataBaseName + ".accdb; Jet OLEDB:Engine Type=5");
                cat.Tables.Append(table);
                //Now Close the database
                ADODB.Connection con = cat.ActiveConnection as ADODB.Connection;
                if (con != null)
                    con.Close();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            cat = null;
            return result;
        }
        /// <summary>
        /// Création de la base de données pour la première fois
        /// </summary>
        /// <returns></returns>
        public bool InitialisationDatabase()
        {
         
            if (!this.isDabaseExist())
            {
                this.CreateAccessDatabase();
            }
            if (!this.isTableExist("VersionDB"))
            {
                String query = "CREATE TABLE VersionDB ( ID AUTOINCREMENT PRIMARY KEY, Version varchar(255));";
                this.ExecuteQuery(query);
            }
            
            this.UpgradeDaTabase();
            return true;
        }

        /// <summary>
        /// Exécuter les requête non déja exécutés
        /// </summary>
        private void UpgradeDaTabase()
        {
            IncrementDB_DAO incrementDB_DAO = new IncrementDB_DAO();
            String requete_erreur = "";
          
          
            // Liste de tous les requêtes
            IEnumerable<IncrementationDB> listQueryDB = new IncrementDB_DAO().SelectFromDB();
            // Liste de tous les requêtes déja exécuté
            IEnumerable<IncrementationDB> listQueryXML = new IncrementDB_DAO().SelectFromXML();
            // Trouvre les requêtes non déja exécuté
            IEnumerable<IncrementationDB> listeQueryNoteExecut = listQueryXML.Except(listQueryDB,new IncrementationDB()).ToList<IncrementationDB>();

            try
            {
                foreach (var increment in listeQueryNoteExecut.OrderBy(i => i.DateCreation))
                {
                    requete_erreur = increment.Increment;
                    this.ExecutIncrementation(increment);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" 
                    + "Erreur dans l'exécution de la requête : \n"
                    + requete_erreur + "\n"
                    +  "Solution : Supprimer la base de données pour une initialisation automatique");
            }
           

        }

        /// <summary>
        /// Exécuter l'incrementation dans la base de données
        /// </summary>
        /// <param name="increment"></param>
        public void ExecutIncrementation(IncrementationDB increment)
        {
            this.ExecuteQuery(increment.Increment);
            string query = "Insert into VersionDB(Version) values('" + increment.Code + "');";
            this.ExecuteQuery(query);
        }
        #endregion
    }
}
