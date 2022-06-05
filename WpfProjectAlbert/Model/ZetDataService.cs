using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectAlbert.Model
{
    class ZetDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
          ConfigurationManager.ConnectionStrings["azure"].ConnectionString;


        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

       
        public void RegisterMove(Zet zet)
        {
            // SQL statement insert
            string sql = "Insert into Zet (Kolom,Rij,SchijfId,SpelId,SpelerId) values (@kolom,@rij,@schijfId,@spelId,@spelerId )";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
               zet.Kolom,
               zet.Rij,
               zet.SchijfId,
               zet.SpelId,
               zet.SpelerId

            });
        }
    }
}
