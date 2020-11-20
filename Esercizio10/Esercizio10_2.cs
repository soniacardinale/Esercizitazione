using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Esercizio10
{
    public class Esercizio10_2
    {
        const string connectionString = @"Persist Security Info=False; Integrated Security=True; Initial Catalog=PoliziaDB; Server=WINAPHDFXGCXX6X\SQLEXPRESS";
        public static void InserimentoNuovoAgente()
        {
            //Creare una connessione
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Inserire i dati
                Console.WriteLine("Inserire i dati dell'agente.\r\nNome:  ");
                string Nome = Console.ReadLine();

                Console.WriteLine("Cognome:  ");
                string Cognome = Console.ReadLine();

                Console.WriteLine("CF:  ");
                string CF = Console.ReadLine();

                //Controllo lunghezza del CF
                if (CF.Length < 16)
                {
                    Console.WriteLine("CF errato, inserire 16 caratteri");
                    Console.WriteLine("CF:  ");
                    CF = Console.ReadLine();
                }

                Console.WriteLine("Data di Nascita:  ");
                string Data_di_Nascita = Console.ReadLine();

                Console.WriteLine("Anni di Servizio:  ");
                string anni = Console.ReadLine();
                int Anni_di_Servizio = int.Parse(anni); //conversione da stringa a intero

                connection.Open();

                //Creazione command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO Agente_di_Polizia VALUES (@Nome, @Cognome, @CF, @Data_di_Nascita, @Anni_di_Servizio)";

                //Creazione parametri
                SqlParameter NomeParam = new SqlParameter();
                NomeParam.ParameterName = "@Nome";
                NomeParam.Value = Nome;
                command.Parameters.Add(NomeParam);


                SqlParameter cognomeParam = new SqlParameter();
                cognomeParam.ParameterName = "@Cognome";
                cognomeParam.Value = Cognome;
                command.Parameters.Add(cognomeParam);

                SqlParameter cfParam = new SqlParameter();
                cfParam.ParameterName = "@CF";
                cfParam.Value = CF;
                command.Parameters.Add(cfParam);

                SqlParameter dataParam = new SqlParameter();
                dataParam.ParameterName = "@Data_di_Nascita";
                dataParam.Value = Data_di_Nascita;
                command.Parameters.Add(dataParam);

                SqlParameter anniservizioParam = new SqlParameter();
                anniservizioParam.ParameterName = "@Anni_di_Servizio";
                anniservizioParam.Value = Anni_di_Servizio;
                command.Parameters.Add(anniservizioParam);

                //Eseguo il command senza mostare in console
                command.ExecuteNonQuery();

                //Chiudere la connessione
                connection.Close();


            }
        }
    }
}