

namespace Calculator.DataLogger.ConsoleApp.Models
{
    public class CalculationLog
    {
        public int Id { get; set; }
        public string Operation { get; set; } = "";
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public double Result { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
