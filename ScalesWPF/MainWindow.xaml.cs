using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ScalesWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadDataFromDatabase();
        }


        public ObservableCollection<Cars> CarsData { get; set; } = new ObservableCollection<Cars>();
        private CarsDB cdb = new CarsDB();


        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
            if (addWindow.Num != "" || addWindow.BRUTTO != 0)
            {
                Cars cr = new Cars(addWindow.Num, addWindow.BRUTTO, addWindow.ContainerWeight, addWindow.NETTO, addWindow.ContDate, addWindow.BRUTTODate);
                CarsData.Add(cr);
                cdb.AddCar(cr);
            }

        }

        private void Button_Change_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            var selectedItem = (Cars)CarGrid.SelectedItem;
            addWindow.ShowDialog();

            if (selectedItem != null)
            {
                string num = selectedItem.Num;
                DateTime CarDateCont = selectedItem.ContainerDate;
                var foundItem = CarsData.FirstOrDefault(car => car.Num == num && car.ContainerDate == CarDateCont);
                if (foundItem != null)
                {
                    foundItem.BRUTTO = addWindow.BRUTTO;
                    foundItem.ContainerWeight = addWindow.ContainerWeight;
                    foundItem.NETTO = addWindow.NETTO;
                    foundItem.BRUTTODate = addWindow.BRUTTODate;

                    cdb.ChangeCar(num, foundItem.BRUTTO, foundItem.ContainerWeight, foundItem.NETTO, CarDateCont.ToUniversalTime(), foundItem.BRUTTODate.ToUniversalTime());
                    CarGrid.Items.Refresh();
                }


            }
        }

        private void LoadDataFromDatabase()
        {
            List<Cars> allCars = cdb.GetAllCars();
            foreach (Cars car in allCars)
            {
                CarsData.Add(car);
            }
        }
    }
}
