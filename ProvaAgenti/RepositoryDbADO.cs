using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAgenti
{
    internal class RepositoryDbADO : IRepository
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProvaAgenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool Aggiungi(Agente item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                //command.CommandText = "insert into dbo.Agente values(@Nome, @Cognome,@CodiceFiscale,@AreaGeografica,@AnnoInizioAttivita)";
                command.CommandText = "insert into dbo.Agente values(@Nome, @Cognome,@AreaGeografica,@AnnoInizioAttivita)";
                command.Parameters.AddWithValue("@Nome", item.Nome);
                command.Parameters.AddWithValue("@Cognome", item.Cognome);
                command.Parameters.AddWithValue("@CodiceFiscale", item.CodiceFiscale);
                command.Parameters.AddWithValue("@AreaGeografica", item.AreaGeografica);
                command.Parameters.AddWithValue("@AnnoInizioAttivita", item.AnnoInizioAttivita);

                int numRighe = command.ExecuteNonQuery();
                if (numRighe == 1)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;
            }
        }
        public List<Agente> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agente";

                SqlDataReader read = command.ExecuteReader();

                List<Agente> agenti = new List<Agente>();

                while (read.Read())
                {
                    string nome = (string)read["Nome"];
                    string cognome = (string)read["Cognome"];
                    string codice = (string)read["CodiceFiscale"];
                    string areaGeografica = (string)read["AreaGeografica"];
                    var annoinizioattivita = (int)read["AnnoInizioAttivita"];

                    Agente agente = new Agente(nome, cognome,codice,areaGeografica, annoinizioattivita);
                    

                    agenti.Add(agente);
                }
                connection.Close();

                return agenti;
            }
        }
            public Agente GetByArea(string area)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from Agente where AreaGeografica = @AreaGeografica";
                    command.Parameters.AddWithValue("@AreaGeografica", area);

                    SqlDataReader reader = command.ExecuteReader();

                    Agente agente = null;

                    while (reader.Read())
                    {
                    string ne = (string)reader["Nome"];
                    string cn = (string)reader["Cognome"];
                    string cf = (string)reader["CodiceFiscale"];
                    string ag = (string)reader["AreaGeografica"];
                    var ai = (int)reader["AnnoInizioAttivita"];

                    agente = new Agente(ne, cn, cf, ag, ai );
                    }
                    connection.Close();
                    return agente;
                }
            }

        public Agente GetByAnniServizio(int anni)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agente where AnnoInizioAttivita = @AnnoInizioAttivita";
                command.Parameters.AddWithValue("@AnnoInizioAttivita", anni);

                SqlDataReader reader = command.ExecuteReader();

                Agente agente = null;

                while (reader.Read())
                {
                    string ne = (string)reader["Nome"];
                    string cn = (string)reader["Cognome"];
                    string cf = (string)reader["CodiceFiscale"];
                    string ag = (string)reader["AreaGeografica"];
                    var ai = (int)reader["AnnoInizioAttivita"];

                    agente = new Agente(ne, cn, cf, ag, ai);
                }
                connection.Close();
                return agente;
            }
        }

        public Agente GetByCodiceFiscale(string codice)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agente where CodiceFiscale = @CodiceFiscale";
                command.Parameters.AddWithValue("@CodiceFiscale", codice);

                SqlDataReader reader = command.ExecuteReader();

                Agente agente = null;

                while (reader.Read())
                {
                    string nm = (string)reader["Nome"];
                    string cm = (string)reader["Cognome"];
                    string cfiscale = (string)reader["CodiceFiscale"];
                    string areag = (string)reader["AreaGeografica"];
                    var annoi = (int)reader["AnnoInizioAttivita"];

                    agente = new Agente(nm, cm, cfiscale, areag, annoi);
                }
                connection.Close();
                return agente;
            }
        }
    }
}
