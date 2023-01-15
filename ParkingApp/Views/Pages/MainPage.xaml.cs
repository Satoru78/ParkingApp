using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParkingApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ClientDataBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientAddPage(new Model.ClientData()));
        }

        private void ParkingBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ParkingAddPage(new Model.Parking()));
        }

        private void ParkingDataListBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ParkingDataPage(new Model.Parking()));
        }

        private void ArchiveBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ArchivePage());
        }
    }
}
