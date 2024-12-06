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
        // Database helper instantie
        private readonly DatabaseHelper _dbHelper = new();
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
            private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginUsernameTextBox.Text;
            string password = LoginPasswordBox.Password;

            var user = await _dbHelper.GetUserAsync(username, password);

            if (user != null)
            {
                LoginErrorTextBlock.Visibility = Visibility.Collapsed;
                ContentDialog successDialog = new ContentDialog
                {
                    Title = "Ingelogd",
                    Content = $"Welkom, {username}!",
                    CloseButtonText = "OK",
                    XamlRoot = this.Content.XamlRoot
                };
                await successDialog.ShowAsync();
            }
            else
            {
                LoginErrorTextBlock.Text = "Ongeldige gebruikersnaam of wachtwoord.";
                LoginErrorTextBlock.Visibility = Visibility.Visible;
            }
        }

        // Registreren
        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = RegisterUsernameTextBox.Text;
            string password = RegisterPasswordBox.Password;
            string confirmPassword = ConfirmRegisterPasswordBox.Password;

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
            else if (await _dbHelper.GetUserByUsernameAsync(username) != null)
            {
                RegisterErrorTextBlock.Text = "Gebruikersnaam bestaat al.";
                RegisterErrorTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                await _dbHelper.AddUserAsync(new User { Username = username, Password = password });
                RegisterErrorTextBlock.Visibility = Visibility.Collapsed;

                ContentDialog successDialog = new ContentDialog
                {
                    Title = "Succes",
                    Content = "Registratie succesvol! Je kunt nu inloggen.",
                    CloseButtonText = "OK",
                    XamlRoot = this.Content.XamlRoot
                };
                await successDialog.ShowAsync();
            }
        }
    }
}