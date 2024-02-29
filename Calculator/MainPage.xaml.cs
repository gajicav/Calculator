using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private string currentInput = string.Empty;
        private double currentResult = 0;
        private string currentOperator = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }

        

        private void CopyResultToClipboard()
        {
            try
            {
                Clipboard.SetTextAsync(resultText.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Clipboard Error: {ex.Message}");
            }
        }

   



        private void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            resultText.Text = currentInput;
        }

        private void OnSelectOperator(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentOperator = button.Text;
            currentResult = double.Parse(currentInput);
            currentInput = string.Empty;
        }

        private void OnClear(object sender, EventArgs e)
        {
            currentInput = string.Empty;
            currentResult = 0;
            currentOperator = string.Empty;
            resultText.Text = "0";
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double inputValue = double.Parse(currentInput);

                switch (currentOperator)
                {
                    case "+":
                        currentResult += inputValue;
                        break;
                    case "-":
                        currentResult -= inputValue;
                        break;
                    case "×":
                        currentResult *= inputValue;
                        break;
                    case "÷":
                        if (inputValue != 0)
                            currentResult /= inputValue;
                        else
                            resultText.Text = "Error";
                        break;
                    default:
                        currentResult = inputValue;
                        break;
                }

                resultText.Text = currentResult.ToString();
                currentInput = string.Empty;
                CopyResultToClipboard();


            }
        }

        
    }
}