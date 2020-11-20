using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Esercizio10
{
    public class Esercizio10_1
    {
        const string connectionString = @"Persist Security Info=False; Integrated Security=True; Initial Catalog=PoliziaDB; Server=WINAPHDFXGCXX6X\SQLEXPRESS";
        public static void AgentiInArea()
        {
            //Creare una connessione
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               //Inserimento da console
                Console.WriteLine("Codice Area interessata: ");
                string area = Console.ReadLine();

                //Aprire una connessione
                connection.Open();

                //creare il command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT distinct Nome, Cognome, CF, Data_di_Nascita, Anni_di_Servizio FROM Gestione_Assegnazioni INNER JOIN Agente_di_Polizia ON Gestione_Assegnazioni.AgenteID = Agente_di_Polizia.ID INNER JOIN  Area_Metropolitana ON Gestione_Assegnazioni.AreaID = Area_Metropolitana.ID WHERE Area_Metropolitana.Codice_Area = @Area ";
                //Creare Parametro
                SqlParameter areaParam = new SqlParameter();
                areaParam.ParameterName = "Area";
                areaParam.Value = area;
                command.Parameters.Add(areaParam);

               

                //Eseguire Command
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dei dati
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}",
                        reader["Nome"],
                        reader["Cognome"],
                        reader["CF"],
                        reader["Data_di_nascita"],
                        reader["Anni_di_Servizio"]);
                }

                //Chiudere connessione
                reader.Close(); //chiudiamo il reader
                connection.Close();



            }
        }
    }
}
