using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ScalesWPF
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {

        public string Num { get; set; }
        public int BRUTTO { get; set; }
        public int ContainerWeight { get; set; }
        public int NETTO { get; set; }
        public DateTime ContDate { get; set; }
        public DateTime BRUTTODate { get; set; }



        public AddWindow()
        {
            InitializeComponent();

        }
        

        private void Accept_Button_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(TextBoxNum.Text) || string.IsNullOrEmpty(TextBoxBRUTTO.Text) || string.IsNullOrEmpty(TextBoxContainerWeight.Text) || string.IsNullOrEmpty(TextBoxNETTO.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
            }
            else
            {
                try
                {
                    Num = TextBoxNum.Text;
                    BRUTTO = Convert.ToInt32(TextBoxBRUTTO.Text);
                    ContainerWeight = Convert.ToInt32(TextBoxContainerWeight.Text);
                    NETTO = Convert.ToInt32(TextBoxNETTO.Text);
                    ContDate = ContainerDate.DisplayDate;
                    BRUTTODate = BRUTTO_Date.DisplayDate;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($"Ошибка заполнения! {ex.Message}");
                }

                if (BRUTTO != (NETTO + ContainerWeight))
                {
                    MessageBox.Show("Ошибка заполнения массы!");
                }
                else { Window.GetWindow(this)?.Close(); }
            }




        }
    }
}
