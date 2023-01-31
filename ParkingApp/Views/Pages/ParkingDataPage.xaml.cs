using ParkingApp.Context;
using ParkingApp.Model;
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
    /// Логика взаимодействия для ParkingDataPage.xaml
    /// </summary>
    public partial class ParkingDataPage : Page
    {
        public ClientData ClientData { get; set; }
        public Parking Parking { get; set; }
        public List<Parking> Parkings { get; set; }
        public ParkingDataPage(Parking parking)
        {
            InitializeComponent();
            Parking = parking;
            this.DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Parkings = Data.db.Parking.ToList();
            ParkingDataGtid.ItemsSource = Parkings;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private List<Parking> CheckDateParking(List<Parking> collection)
        {
            List<Parking> list = new List<Parking>();
            foreach (Parking item in collection)
            {
                if (item.DateEnd.Date < DateTime.Today)
                {
                    list.Add(item);
                }
            }
            if (list.Any())
            {
                return list;
            }
            else
            {
                return null;
            }
        }
        private void CheckDate_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckDateParking(Data.db.Parking.ToList()) != null)
            {
                ParkingDataGtid.ItemsSource = CheckDateParking(Data.db.Parking.ToList());
            }
            else
            {
                MessageBox.Show("Арендованных парковочных мест НЕТ", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                CheckDate.IsChecked = false;
            }
        }

        private void CheckDate_Unchecked(object sender, RoutedEventArgs e)
        {
            Page_Loaded(null, null);
        }
    }
}
