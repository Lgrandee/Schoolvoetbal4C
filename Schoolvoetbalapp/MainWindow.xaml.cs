using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Schoolvoetbalapp.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Newtonsoft.Json;
using System.Net.Http;
using Windows.Services.Maps;
using System.Net.Http;
using System.Text.Json;
using System.Windows;

using System.Linq;
using Schoolvoetbalapp.Data;
using System.Windows;
using BoekenOnline.Data;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Schoolvoetbalapp
{
    public partial class MainWindow : Window
    {
        private readonly SchoolvoetbalOnlineContext _dbContext;
        private readonly ApiService _apiService;

        public MainWindow()
        {
            InitializeComponent();
            _dbContext = new SchoolvoetbalOnlineContext(); // Use the default constructor
            _apiService = new ApiService();

            // Load data on startup
            LoadData();
        }

        private void LoadData()
        {
            GokkersListView.ItemsSource = _dbContext.Gokkers.ToList();
            WedstrijdenListView.ItemsSource = _dbContext.Wedstrijden.ToList();
        }

        private async void SyncDataButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new SchoolvoetbalOnlineContext()) // Default constructor
            {
                await _apiService.SynchroniseerWedstrijdenMetDatabase(context);
                ContentDialog dialog = new ContentDialog
                {
                    Title = "Wedstrijden gesynchroniseerd!",
                    Content = "Message",
                    CloseButtonText = "OK",
                     XamlRoot = this.RootGrid.XamlRoot
                };
                await dialog.ShowAsync();
            }
        }

        private async void AddStartingAmountButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new SchoolvoetbalOnlineContext()) // Default constructor
            {
                foreach (var gokker in context.Gokkers)
                {
                    gokker.Budget = 50.0; // Assign start budget
                }
                context.SaveChanges();
                ContentDialog dialog = new ContentDialog
                {
                    Title = "Startbedrag ingesteld!",
                    Content = "Message",
                    CloseButtonText = "OK",
                    XamlRoot = this.RootGrid.XamlRoot
                };
                await dialog.ShowAsync();
            }
        }
    }
}
