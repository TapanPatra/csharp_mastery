using CoreLib;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Calculator _calculator = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private double GetInput(TextBox box) => double.Parse(box.Text);

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _calculator.Add(GetInput(Input1), GetInput(Input2));
                ResultText.Text = $"Result: {result}";
            }
            catch (Exception ex)
            {
                ResultText.Text = $"Error: {ex.Message}";
            }
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _calculator.Subtract(GetInput(Input1), GetInput(Input2));
                ResultText.Text = $"Result: {result}";
            }
            catch (Exception ex)
            {
                ResultText.Text = $"Error: {ex.Message}";
            }
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _calculator.Multiply(GetInput(Input1), GetInput(Input2));
                ResultText.Text = $"Result: {result}";
            }
            catch (Exception ex)
            {
                ResultText.Text = $"Error: {ex.Message}";
            }
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _calculator.Divide(GetInput(Input1), GetInput(Input2));
                ResultText.Text = $"Result: {result}";
            }
            catch (Exception ex)
            {
                ResultText.Text = $"Error: {ex.Message}";
            }
        }
    }
}
