using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

using school;

using Microsoft.VisualBasic.FileIO;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace school
{
    public sealed partial class MainWindow : Window
    {
        // Database helper instantie
        private readonly DatabaseHelper _dbHelper = new();

        public MainWindow()
        {
            this.InitializeComponent();
        }


        // Inloggen
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginUsernameTextBox.Text;
            string password = LoginPasswordBox.Password;

            var user = await _dbHelper.GetUser Async(username, password);

            if (user != null)
            {
                // Succesvol ingelogd
            }
            else
            {
                // Foutmelding tonen
            }
        }

        // Registreren
        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Verkrijg gebruikersinvoer
            string username = RegisterUsernameTextBox.Text;
            string password = RegisterPasswordBox.Password;
            string confirmPassword = ConfirmRegisterPasswordBox.Password;

            // Validatie en toevoegen van de gebruiker
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                RegisterErrorTextBlock.Text = "Vul alle velden in.";
                RegisterErrorTextBlock.Visibility = Visibility.Visible;
            }
            else if (password != confirmPassword)
            {
                RegisterErrorTextBlock.Text = "Wachtwoorden komen niet overeen.";
                RegisterErrorTextBlock.Visibility = Visibility.Visible;
            }
            else if (await _dbHelper.GetUser ByUsernameAsync(username) != null)
    {
                RegisterErrorTextBlock.Text = "Gebruikersnaam bestaat al.";
                RegisterErrorTextBlock.Visibility = Visibility.Visible;
            }
             else
            {
                await _dbHelper.AddUser Async(new User { Username = username, Password = password });
                RegisterErrorTextBlock.Visibility = Visibility.Collapsed;
                // Succesbericht tonen
            }
        }
        private void GoToBettingPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Betting));
        }

        private void GoToLeaderboardPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Leaderboard));
        }
    }

}
