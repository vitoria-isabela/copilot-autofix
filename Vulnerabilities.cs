using System;
using System.Data.SqlClient;
using System.IO;

namespace Vulnerabilidades
{
    class Program
    {
        // Example 1: SQL Injection
        static void ExemploSqlInjection(string usuario)
        {
            // Vulnerable: direct concatenation of user input
            string connectionString = "Data Source=servidor;Initial Catalog=banco;Integrated Security=True";
            string query = "SELECT * FROM Usuarios WHERE Nome = '" + usuario + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["Nome"]);
                }
            }
        }

        // Example 2: Sensitive information exposure in exceptions
        static void ExemploInformacaoSensivel()
        {
            try
            {
                File.ReadAllText("arquivo_que_nao_existe.txt");
            }
            catch (Exception ex)
            {
                // Vulnerable: displays detailed error information to the user
                Console.WriteLine("Error: " + ex.ToString());
            }
        }

        // Example 3: Insecure use of temporary files
        static void ExemploArquivoTemporario()
        {
            // Vulnerable: predictable filename
            string tempFile = "temp.txt";
            File.WriteAllText(tempFile, "temporary data");
            Console.WriteLine("Temporary file created: " + tempFile);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Examples of vulnerabilities in C#");
            ExemploSqlInjection("usuario' OR '1'='1");
            ExemploInformacaoSensivel();
            ExemploArquivoTemporario();
        }
    }
}
