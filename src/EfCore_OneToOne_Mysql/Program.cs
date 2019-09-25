using EfCore_OneToOne_Mysql.Data;
using EfCore_OneToOne_Mysql.Model;
using Microsoft.Extensions.Configuration;
using System;

namespace EfCore_OneToOne_Mysql
{
    class Program
    {
        private static string _connectionString;
        // Based on the article: https://www.entityframeworktutorial.net/efcore/entity-framework-core-console-application.aspx

        static void Main(string[] args)
        {

            // Enable migrations on Console: https://stackoverflow.com/questions/45782446/unable-to-create-migrations-after-upgrading-to-asp-net-core-2-0
            Initialize();

            Console.WriteLine(DateTime.Now);
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            using (var context = new DataContext(_connectionString))
            {
                var insertStopWatch = new System.Diagnostics.Stopwatch();
                insertStopWatch.Start();
                for (int i = 0; i < 600; i++)
                {
                    var std = new Car()
                    {
                        Make = "Ford",
                        Model = "Fusion",
                        Name = "My Car",
                        Engine = new Engine()
                        {
                            Make = "Volks",
                            Model = "AP1600"
                        },
                    };

                    context.Cars.Add(std);
                    Console.WriteLine("Added another line - " + i);
                }
                insertStopWatch.Stop();
                Console.WriteLine($"Elapsed time inserting values (NO COMMIT YET) : {stopWatch.Elapsed}");
                context.SaveChanges();
            }
            stopWatch.Stop();

            Console.WriteLine(DateTime.Now);
            Console.WriteLine($"Overalll Elapsed time: {stopWatch.Elapsed}");
            // Configure mappings using Fluent API

            // Add migrations to project to create database in case not there

        }

        private static void Initialize()
        {
            //Load settings from configuration file
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();

            //Bind settings to Model
            _connectionString = configuration.GetConnectionString("MysqlConnection");
        }
    }
}
