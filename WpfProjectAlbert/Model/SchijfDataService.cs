using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectAlbert.Model
{
    class SchijfDataService
    { 
            // Ophalen ConnectionString uit App.config
            private static string connectionString =
              ConfigurationManager.ConnectionStrings["local"].ConnectionString;


            // Stap 1 Dapper
            // Aanmaken van een object uit de IDbConnection class en 
            // instantiëren van een SqlConnection.
            // Dit betekent dat de connectie met de database automatisch geopend wordt.
            private static IDbConnection db = new SqlConnection(connectionString);

            public Schijf GetSchijf(int id)
            {
            Schijf s = new Schijf();
            string sql = "SELECT * from Schijf  where Id=" + id +";";

            var schijf = db.Query<Schijf>(sql);

            foreach (var attr in schijf)
            {
                s.Id = attr.Id;
              s.FillColor=attr.FillColor;
            }
            return s;
            }
        public List<Schijf> GetSchijfjes()
        {
             // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Schijf;";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van contactpersonen
            return (List<Schijf>)db.Query<Schijf>(sql);
        }

    }
}
