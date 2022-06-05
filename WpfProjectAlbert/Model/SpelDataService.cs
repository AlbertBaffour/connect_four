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
    class SpelDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
    ConfigurationManager.ConnectionStrings["azure"].ConnectionString;


        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);


        public int RegisterGame(Spel spel)
        {
            // SQL statement insert
            string sql = "Insert into Spel (begintijd,gebruikerId ) values (@begintijd,@gebruikerId);" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            var newId = db.QuerySingle<int>(sql, new
            {
                spel.Begintijd,
                spel.GebruikerId

            });
            return newId;
        }
        public void UpdateSpel(Spel spel)
        {
            // SQL statement update 
            string sql = "Update Spel set Eindtijd = @eindtijd, Winnaar= @winnaar where Id = @Id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                spel.Eindtijd,
                spel.Winnaar,
                spel.Id
            });
        }
        public int[] GetWins(int gebruikerId)
        {
            int won = 0;
            int lost = 0;
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Spel  where gebruikerId='" + gebruikerId + "';";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            IEnumerable<Spel> games = db.Query<Spel>(sql);
            foreach (var i in games)
            {
                if (i.Winnaar == 1)
                {
                    won++;

                }
                else
                {
                    if (i.Winnaar == 0)
                    {
                        lost++;
                    }
                }
            }
            int[] intList = { won, lost };
            return intList;
        }
    }
}
