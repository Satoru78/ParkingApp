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
    /// Логика взаимодействия для ParkingAddPage.xaml
    /// </summary>
    public partial class ParkingAddPage : Page
    {
        public Parking Parking { get; set; }
        public List<ClientData> ClientDatas { get; set; }
        public ParkingAddPage(Parking parking)
        {
            InitializeComponent();
            Parking = parking;
            ClientDatas = Data.db.ClientData.ToList();
            this.DataContext = this;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Parking.ID == 0)
                {
                    Data.db.Parking.Add(Parking);
                }
                Data.db.SaveChanges();
                MessageBox.Show("Данные сохранены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Произошла ошибка");
            }
        }
    }
}
