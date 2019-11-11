using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace database
{
	class Item_22
	{
		private const string DatabaseServer = @"(localdb)\MSSQLLocalDB";
		private const string MasterDatabase = "master";
		private const string DatabaseName = "Cinema";
		private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;
												Initial Catalog=Cinema;
												Integrated Security=True;
												Connect Timeout=30;
												Encrypt=False;
												TrustServerCertificate=False;
												ApplicationIntent=ReadWrite;
												MultiSubnetFailover=False";
		static async Task XMain(string[] args)
		{
			await CreateDBAsync();

			using (var connection = new SqlConnection(ConnectionString))
			{
				connection.Open();
				await PrintMovies(connection);

				//Evitar técnica de SQL Injection
				Console.Write("Digite o Id do filme a ser alterado: ");
				string filmeId = Console.ReadLine();
				Console.Write("Digite o novo título do filme: ");
				string novoTitulo = Console.ReadLine();
				string query = "UPDATE Filmes SET Titulo=@NEWTITLE WHERE Id=@MOVIEID";
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@NEWTITLE", novoTitulo);
				command.Parameters.AddWithValue("@MOVIEID", filmeId);
				int result = command.ExecuteNonQuery();

				Console.WriteLine("Número de linhas alteradas: {0}", result);
				await PrintMovies(connection);
			}

			Console.ReadKey();
		}

		static async Task PrintMovies(SqlConnection connection)
		{
			string query = @"SELECT d.Nome AS Diretor, f.Titulo
							FROM Filmes AS f
							INNER JOIN Diretores AS d
							ON f.DiretorId = d.Id";
			SqlCommand command = new SqlCommand(query, connection);
			SqlDataReader reader = command.ExecuteReader();
			while (await reader.ReadAsync())
			{
				var director = reader["Diretor"].ToString();
				var movietitle = reader["Titulo"].ToString();
				Console.WriteLine("Diretor: {0} - Título: {1}", director, movietitle);
			}
			reader.Close();
		}

		private static async Task CreateDBAsync()
		{
			await CreateDatabaseAsync();
			await CreateTablesAsync();
			await InsertDataAsync();
		}

		private static async Task CreateDatabaseAsync()
		{
			string sql = $@"IF EXISTS (SELECT * FROM sys.databases WHERE name = N'{DatabaseName}')
                    BEGIN
                        DROP DATABASE [{DatabaseName}]
                    END;
                    CREATE DATABASE [{DatabaseName}];";
			await ExecuteCommandAsync(sql, MasterDatabase);
		}

		private static async Task CreateTablesAsync()
		{
			string sql = $@"CREATE TABLE [dbo].[Diretores] (
                        [Id]   INT           IDENTITY (1, 1) NOT NULL,
                        [Nome] VARCHAR (255) NOT NULL
                    );
                    CREATE TABLE [dbo].[Filmes] (
                        [Id]        INT           IDENTITY (1, 1) NOT NULL,
                        [DiretorId] INT           NOT NULL,
                        [Titulo]    VARCHAR (255) NOT NULL,
                        [Ano]       INT           NOT NULL,
                        [Minutos]   INT           NOT NULL
                    );";
			await ExecuteCommandAsync(sql, DatabaseName);
		}

		private static async Task InsertDataAsync()
		{
			string sql = @"
                    INSERT Diretores (Nome) VALUES ('Quentin Jerome Tarantino');
                    INSERT Diretores (Nome) VALUES ('James Cameron');
                    INSERT Diretores (Nome) VALUES ('Tim Burton');

                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (1, 'Pulp Fiction', 1994,	154);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (1, 'Django Livre', 2012,	165);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (1, 'Kill Bill Volume 1', 2003,	111);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (2, 'Avatar', 2009,	162);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (2, 'Titanic', 1997,	194);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (2, 'O Exterminador', 1984,	107);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'O Estranho Mundo de Jack', 1993,	76);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'Alice no País das Maravilhas', 2010,	108);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'A Noiva Cadáver', 2005,	77);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'A Fantástica Fábrica de Chocolate', 2005,	115);";
			await ExecuteCommandAsync(sql, DatabaseName);
		}

		private static async Task ExecuteCommandAsync(string command, string database)
		{
			if (string.IsNullOrWhiteSpace(DatabaseServer))
			{
				throw new Exception("Database Server precisa ser definido");
			}

			SqlConnection connection = new SqlConnection($"Server={DatabaseServer};Integrated security=SSPI;database={database}");
			SqlCommand comm = new SqlCommand(command, connection);

			try
			{
				connection.Open();
				await comm.ExecuteNonQueryAsync();
				Console.WriteLine("Script executado com sucesso.");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				if (connection.State == System.Data.ConnectionState.Open)
				{
					connection.Close();
				}
			}

		}
	}
}
