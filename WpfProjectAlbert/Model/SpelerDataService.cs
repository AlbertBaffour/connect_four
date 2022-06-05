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
    class SpelerDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
    ConfigurationManager.ConnectionStrings["azure"].ConnectionString;


        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

    
        public int RegisterPlayer1(Speler speler)
        {
            // SQL statement insert
            string sql = "Insert into Speler (GebruikerId,SpelId,SchijfId ) values (@gebruikerId,@spelId,@schijfId);"+
                 "SELECT CAST(SCOPE_IDENTITY() as int)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            var newId = db.QuerySingle<int>(sql, new
            {
              speler.GebruikerId,
                speler.SpelId,
                speler.SchijfId
               
            });
            return newId;
        }
        public int RegisterPlayer2(Speler speler)
        {
            // SQL statement insert
            string sql = "Insert into Speler (SpelId,SchijfId ) values (@spelId,@schijfId);"+
                 "SELECT CAST(SCOPE_IDENTITY() as int)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            var newId = db.QuerySingle<int>(sql, new
            {
                speler.SpelId,
                speler.SchijfId
               
            });
            return newId;
        }
    }
}

