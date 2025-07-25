using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CalculatorWebUI.Services;


namespace CalculatorWebUI.Pages
{
    public class CalculatorModel : PageModel
    {
        [BindProperty]
        public double A { get; set; }

        [BindProperty]
        public double B { get; set; }

        [BindProperty]
        public string Operation { get; set; }

        public double? Result { get; set; }
        public string ErrorMessage { get; set; }

        public void OnPost()
        {
            var calc = new Calculator();

            try
            {
                Result = Operation switch
                {
                    "Add" => calc.Add(A, B),
                    "Subtract" => calc.Subtract(A, B),
                    "Multiply" => calc.Multiply(A, B),
                    "Divide" => calc.Divide(A, B),
                    _ => throw new InvalidOperationException("Unknown operation")
                };
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
