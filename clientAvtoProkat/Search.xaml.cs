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
using System.Windows.Shapes;

namespace clientAvtoProkat
{
    /// <summary>
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        List<TextBox> textboxs = new List<TextBox>();
        List<TextBlock> Labels = new List<TextBlock>();
        MainWindow parent;
        public Search(MainWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            textboxs.Add(TextBox3);
            textboxs.Add(TextBox4);
            textboxs.Add(TextBox5);
            textboxs.Add(TextBox6);
            textboxs.Add(TextBox7);
            textboxs.Add(TextBox8);
            textboxs.Add(TextBox9);
            textboxs.Add(TextBox10);
            textboxs.Add(TextBox11);
            Labels.Add(Label3);
            Labels.Add(Label4);
            Labels.Add(Label5);
            Labels.Add(Label6);
            Labels.Add(Label7);
            Labels.Add(Label8);
            Labels.Add(Label9);
            Labels.Add(Label10);
            Labels.Add(Label11);
            Labels.Add(Label12);
            Labels.Add(Label13);

            foreach (var item in textboxs)
            {
                item.Visibility = Visibility.Hidden;
            }
            foreach (var item in Labels)
            {
                item.Visibility = Visibility.Hidden;
            }
            CB1.Visibility = Visibility.Hidden;
            CB2.Visibility = Visibility.Hidden;
            for (int i = 0; i < 9; i++)
            {
                textboxs[i].Visibility = Visibility.Visible;
                textboxs[i].Margin = new Thickness(80, 39 + 30 * (i + 1), 790, 462 - 30 * (i ));
            }
            for (int i = 0; i < 11; i++)
            {
                Labels[i].Visibility = Visibility.Visible;
                Labels[i].Margin = new Thickness(7, 39 + 30 * (i + 1), 790, 462 - 30 * (i ));
            }
            NameLabel.Text = "Марка";
            Label3.Text = "Модель";
            Label4.Text = "Цвет";
            Label5.Text = "Пробег";
            Label6.Text = "Год";
            Label7.Text = "Ценна за день";
            Label8.Text = "Залог";
            Label9.Text = "Номер";
            Label10.Text = "Вин";
            Label11.Text = "Город";
            CB1.Visibility = Visibility.Visible;
            CB2.Visibility = Visibility.Visible;
            CB1.Margin = new Thickness(80, 39 + 30 * (9 + 1), 790, 462 - 30 * (9 ));
            CB2.Margin = new Thickness(80, 39 + 30 * (10 + 1), 790, 462 - 30 * (10 ));
            Label12.Text = "Дети";
            Label13.Text = "Заграница";

        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            IEnumerable<Car> SearchCar = from i in parent.listCar select i;
            if (NameTextBox.Text!="")
            {
                SearchCar = from i in SearchCar where i.Mark == NameTextBox.Text select i;
            }
            if (TextBox3.Text!="")
            {
                SearchCar = from i in SearchCar where i.Model == TextBox3.Text select i;
            }
            if (TextBox4.Text!="")
            {
                SearchCar = from i in SearchCar where i.Colour == TextBox4.Text select i;
            }
            if (TextBox5.Text != "")
            {
                SearchCar = from i in SearchCar where i.CarMileage <= int.Parse(TextBox5.Text) select i;
            }
            if (TextBox6.Text != "")
            {
                SearchCar = from i in SearchCar where i.Year >= int.Parse(TextBox6.Text) select i;
            }
            if (TextBox7.Text != "")
            {
                SearchCar = from i in SearchCar where i.CarPriseDay <= int.Parse(TextBox7.Text) select i;
            }
            if (TextBox8.Text != "")
            {
                SearchCar = from i in SearchCar where i.Zalog <= int.Parse(TextBox8.Text) select i;
            }
            if (TextBox9.Text != "")
            {
                SearchCar = from i in SearchCar where i.Nomer.ToString() == TextBox9.Text select i;
            }
            if (TextBox10.Text != "")
            {
                SearchCar = from i in SearchCar where i.CarVinKuzov.ToString() == TextBox10.Text select i;
            }
            if (TextBox11.Text != "")
            {
                SearchCar = from i in SearchCar where i.City == TextBox11.Text select i;
            }
            if (CB1.IsChecked==true)
            {
                SearchCar = from i in SearchCar where i.Child == CB1.IsChecked select i;
            }
            if (CB2.IsChecked == true)
            {
                SearchCar = from i in SearchCar where i.CarAbroad == CB2.IsChecked select i;
            }
            DT.ItemsSource = SearchCar;
        }
    }
}
