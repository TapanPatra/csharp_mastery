using Calculator.DataLogger.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;


namespace Calculator.DataLogger.ConsoleApp
{
    public class AppDbContext : DbContext
    {
        public DbSet<CalculationLog> CalculationLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=calculations.db");
        }
    }
}
