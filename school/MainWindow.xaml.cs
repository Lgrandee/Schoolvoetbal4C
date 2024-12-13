using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using school;
using school.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using school.Model;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace school
{
    public sealed partial class MainWindow : Window
    {

        //private readonly DataBaseHelper _dbHelper = new();
        private readonly FootballApiService _footballApiService;


        public MainWindow()
        {
            this.InitializeComponent();
            _footballApiService = new FootballApiService();
        }


        private async void FetchTeamsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Team> teams = await _footballApiService.GetTeamsAsync();
                TeamsListView.ItemsSource = teams;
            }
            catch (Exception ex)
            {
                // Handle errors (e.g., show a message box)
            }
        }

            // Inloggen
            //private async void LoginButton_Click(object sender, RoutedEventArgs e)

        private void LoginButton_Click(object sender, RoutedEventArgs e)

        {
            string username = LoginUsernameTextBox.Text;
            string password = LoginPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                LoginErrorTextBlock.Text = "Gebruikersnaam en wachtwoord zijn verplicht.";
                LoginErrorTextBlock.Foreground = new SolidColorBrush(Colors.Red); // Gebruik Colors.Red
                LoginErrorTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                if (username == "test" && password == "1234") // Vervang dit met jouw logica
                {
                    LoginErrorTextBlock.Text = "Inloggen geslaagd!";
                    LoginErrorTextBlock.Foreground = new SolidColorBrush(Colors.Green); // Gebruik Colors.Green
                    LoginErrorTextBlock.Visibility = Visibility.Visible;
                }
                else
                {
                    LoginErrorTextBlock.Text = "Ongeldige gebruikersnaam of wachtwoord.";
                    LoginErrorTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                    LoginErrorTextBlock.Visibility = Visibility.Visible;
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = RegisterUsernameTextBox.Text;
            string password = RegisterPasswordBox.Password;
            string confirmPassword = ConfirmRegisterPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                RegisterErrorTextBlock.Text = "Alle velden zijn verplicht.";
                RegisterErrorTextBlock.Foreground = new SolidColorBrush(Colors.Red); // Gebruik Colors.Red
                RegisterErrorTextBlock.Visibility = Visibility.Visible;
            }
            else if (password != confirmPassword)
            {
                RegisterErrorTextBlock.Text = "Wachtwoorden komen niet overeen.";
                RegisterErrorTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                RegisterErrorTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                RegisterErrorTextBlock.Text = "Registratie geslaagd!";
                RegisterErrorTextBlock.Foreground = new SolidColorBrush(Colors.Green); // Gebruik Colors.Green
                RegisterErrorTextBlock.Visibility = Visibility.Visible;
            }
        }
    }
}