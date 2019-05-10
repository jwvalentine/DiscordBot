using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace DiscordBot.Resources.Database
{
    public class SQLiteDbContext : DbContext
    {
        public DbSet<Stone> Stones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder Options)
        {
            string dbLocation = Assembly.GetEntryAssembly().Location.Replace(@"bin\Debug\netcoreapp2.0", @"Data\");
            Options.UseSqlite($"Data Source={dbLocation}Database.sqlite");
        }

    }
}
