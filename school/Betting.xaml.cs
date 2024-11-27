using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.VisualBasic.FileIO;
using System.Data;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace school
{
    public sealed partial class Betting : Page
    {

        private double currentBalance = 100.0;
        private string correctOutcome = "Win";
        public Betting()
        {
            this.InitializeComponent();
            UpdateBalanceText();
        }

        private void UpdateBalanceText()
        {
            BalanceText.Text = $"${currentBalance:F2}";
        }

        private void PlaceBet_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(BetAmountTextBox.Text, out double betAmount) || betAmount <= 0)
            {
                ResultMessage.Text = "Please enter a valid bet amount.";
                ResultMessage.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Red);
                return;
            }

            if (betAmount > currentBalance)
            {
                ResultMessage.Text = "You do not have enough balance to place this bet.";
                ResultMessage.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Red);
                return;
            }

            string selectedOutcome = null;
            if (WinOption.IsChecked == true) selectedOutcome = "Win";
            if (DrawOption.IsChecked == true) selectedOutcome = "Draw";
            if (LossOption.IsChecked == true) selectedOutcome = "Loss";

            if (string.IsNullOrEmpty(selectedOutcome))
            {
                ResultMessage.Text = "Please select an outcome before placing your bet.";
                ResultMessage.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Red);
                return;
            }

            if (selectedOutcome == correctOutcome)
            {
                currentBalance += betAmount; 
                ResultMessage.Text = $"Congratulations! You won and earned ${betAmount:F2}.";
                ResultMessage.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Green);
            }
            else
            {
                currentBalance -= betAmount;
                ResultMessage.Text = $"Sorry, you lost ${betAmount:F2}. Better luck next time!";
                ResultMessage.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Red);
            }

            UpdateBalanceText();

            BetAmountTextBox.Text = string.Empty;
        }
    }
}

