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
    class GebruikerDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
          ConfigurationManager.ConnectionStrings["azure"].ConnectionString;


        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        public Gebruiker GetGebruiker(string gebruikersnaam)
        {
            Gebruiker user =new Gebruiker();

            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Gebruiker  where Gebruikersnaam='" + gebruikersnaam + "';";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van contactpersonen
             IEnumerable<Gebruiker> userFromDB = db.Query<Gebruiker>(sql);
            foreach (var attr in userFromDB)
            {
                user.Id = attr.Id;
                user.Gebruikersnaam = attr.Gebruikersnaam;
                user.Pin = attr.Pin;
                user.Roepnaam = attr.Roepnaam;
                user.Geboortedatum = attr.Geboortedatum;
            }
            return user;
        }
        public void Inschrijven(Gebruiker gebruiker)
        {
            // SQL statement insert
            string sql = "Insert into Gebruiker (Roepnaam,Gebruikersnaam,Pin,Geboortedatum ) values (@roepnaam,@gebruikersnaam,@pin,@geboortedatum )";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                gebruiker.Roepnaam,
                gebruiker.Gebruikersnaam,
                gebruiker.Pin,
                gebruiker.Geboortedatum
            }); 
        }
        public void VerwijderGebruiker( Gebruiker gebruiker)
        {
            gebruiker.Pin = null;
            // SQL statement update , Nullify andere records van de gebruiker
            string sql1 = "Update Spel set GebruikerId = @Pin where GebruikerId = @Id;" +
                "Update Speler set GebruikerId = @Pin where GebruikerId = @Id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql1, new
            {
                gebruiker.Pin,
                gebruiker.Id
            });

            //// SQL statement delete 
            string sql = "Delete Gebruiker where Id = @Id";

            //// Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { gebruiker.Id });
        }
        public void WijzigGebruiker( Gebruiker gebruiker)
        {
            // SQL statement update 
            string sql = "Update Gebruiker set Roepnaam = @Roepnaam, Gebruikersnaam = @Gebruikersnaam, Geboortedatum = @Geboortedatum, Pin = @Pin where Id = @Id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                gebruiker.Roepnaam,
                gebruiker.Gebruikersnaam,
                gebruiker.Geboortedatum,
                gebruiker.Pin,
                gebruiker.Id
            });
        }
     
    }
}
