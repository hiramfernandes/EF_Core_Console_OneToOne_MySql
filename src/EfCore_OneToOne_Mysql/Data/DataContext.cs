using EfCore_OneToOne_Mysql.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCore_OneToOne_Mysql.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;

        public DataContext(DbContextOptions options) : base (options)
        {

        }

        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Engine> Engines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connectionString))
                _connectionString = "server=localhost;Port=3306;uid=valet;pwd=vpass;database=ef_test;sslMode=none";
            optionsBuilder.UseMySql(_connectionString);
        }
    }
}
