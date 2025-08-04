namespace CalculatorMobileUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            PerformCalculation((x, y) => x + y);
        }

        private void OnSubtractClicked(object sender, EventArgs e)
        {
            PerformCalculation((x, y) => x - y);
        }

        private void OnMultiplyClicked(object sender, EventArgs e)
        {
            PerformCalculation((x, y) => x * y);
        }

        private void OnDivideClicked(object sender, EventArgs e)
        {
            PerformCalculation((x, y) => y != 0 ? x / y : double.NaN);
        }

        private void PerformCalculation(Func<double, double, double> operation)
        {
            if (double.TryParse(Entry1.Text, out double num1) && double.TryParse(Entry2.Text, out double num2))
            {
                double result = operation(num1, num2);
                ResultLabel.Text = $"Result: {result}";
            }
            else
            {
                ResultLabel.Text = "Invalid Input";
            }
        }

    }
}
