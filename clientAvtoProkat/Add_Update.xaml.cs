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
using System.Net.Http;
using System.Net.Http.Headers;

namespace clientAvtoProkat
{
    /// <summary>
    /// Логика взаимодействия для Add_Update.xaml
    /// </summary>
    public partial class Add_Update : Window
    {
        int add;
        int table;
        List<TextBox> textboxs=new List<TextBox>();
        List<TextBlock> Labels = new List<TextBlock>();
        MainWindow parent;
        public Add_Update(int add, int table, MainWindow parent)
        {
            InitializeComponent();
            this.add = add;
            this.table = table;
            this.parent = parent;
            if (add == 1)
            {
                IDCombo.Visibility = Visibility.Hidden;
            }
            else
            {
                if (add==0)
                {
                    ADDbutton.Content = "Update";
                    this.Title= "Update";
                }
                else
                {
                    ADDbutton.Content = "Delete";
                    this.Title = "Delete";
                }
                    IDTextBox.Visibility = Visibility.Hidden;
                    switch (table)
                    {
                        case 0:
                            foreach (var item in parent.listCar)
                            {
                                IDCombo.Items.Add(item.CarID);
                            }
                            break;
                        case 1:
                            foreach (var item in parent.listZakaz)
                            {
                                IDCombo.Items.Add(item.ZakazID);
                            }
                            break;
                        case 2:
                            foreach (var item in parent.listСlient)
                            {
                                IDCombo.Items.Add(item.ClientID);
                            }
                            break;
                        case 3:
                            foreach (var item in parent.listEmployee)
                            {
                                IDCombo.Items.Add(item.EmplID);
                            }
                            break;
                        case 4:
                            foreach (var item in parent.listPost)
                            {
                                IDCombo.Items.Add(item.PostID);
                            }
                            break;
                        default:
                            break;
                    }
            }
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
            if (add==2)
            {
                NameTextBox.IsEnabled = false;
                foreach (var item in textboxs)
                {
                    item.IsEnabled = false;
                }
            }
            foreach (var item in textboxs)
            {
                item.Visibility = Visibility.Hidden;
            }
            foreach (var item in Labels)
            {
                item.Visibility = Visibility.Hidden;
            }
            date1.Visibility = Visibility.Hidden;
            date2.Visibility = Visibility.Hidden;
            CB1.Visibility = Visibility.Hidden;
            CB2.Visibility = Visibility.Hidden;
            switch (table)
            {
                case 0:
                    for (int i = 0; i < 9; i++)
                    {
                        textboxs[i].Visibility = Visibility.Visible;
                        textboxs[i].Margin = new Thickness(80, 39 + 30 * (i + 1), 20, 462 - 30 * (i + 1));
                    }
                    for (int i = 0; i < 11; i++)
                    {
                        Labels[i].Visibility = Visibility.Visible;
                        Labels[i].Margin = new Thickness(7, 39 + 30 * (i + 1), 264, 462 - 30 * (i + 1));
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
                    CB1.Margin = new Thickness(80, 39 + 30 * (9 + 1), 20, 462 - 30 * (9 + 1));
                    CB2.Margin = new Thickness(80, 39 + 30 * (10 + 1), 20, 462 - 30 * (10 + 1));
                    Label12.Text = "Дети";
                    Label13.Text = "Заграница";
                    break;
                case 1:
                    for (int i = 0; i < 4; i++)
                    {
                        textboxs[i].Visibility = Visibility.Visible;
                        textboxs[i].Margin = new Thickness(80, 39 + 30 * (i + 1), 20, 462 - 30 * (i + 1));
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        Labels[i].Visibility = Visibility.Visible;
                        Labels[i].Margin = new Thickness(7, 39 + 30 * (i + 1), 264, 462 - 30 * (i + 1));
                    }
                    Label3.Text = "Акт выдачи";
                    Label4.Text = "Акт приема";
                    Label5.Text = "ID клиента";
                    Label6.Text = "ID машины";
                    NameLabel.Text = "ID работника";
                    Label7.Text = "Начало";
                    Label8.Text = "Конец";
                    Label9.Text = "Оплата";
                    date1.Visibility = Visibility.Visible;
                    date1.Margin = new Thickness(80, 39 + 30 * (4 + 1), 20, 462 - 30 * (4 + 1));
                    date2.Visibility = Visibility.Visible;
                    date2.Margin = new Thickness(80, 39 + 30 * (5 + 1), 20, 462 - 30 * (5 + 1));
                    CB1.Visibility = Visibility.Visible;
                    CB1.Margin = new Thickness(80, 39 + 30 * (6 + 1), 20, 462 - 30 * (6 + 1));
                    break;
                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        textboxs[i].Visibility = Visibility.Visible;
                        textboxs[i].Margin = new Thickness(80, 39 + 30 * (i + 1), 20, 462 - 30 * (i + 1));
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        Labels[i].Visibility = Visibility.Visible;
                        Labels[i].Margin = new Thickness(7, 39 + 30 * (i + 1), 264, 462 - 30 * (i + 1));
                    }
                    Label3.Text = "Паспорт";
                    Label4.Text = "Водительское";
                    Label5.Text = "Телефон";
                    Label6.Text = "Дата";
                    date1.Visibility = Visibility.Visible;
                    date1.Margin= new Thickness(80, 39 + 30 * (3 + 1), 20, 462 - 30 * (3 + 1));
                    break;
                case 3:
                    for (int i = 0; i < 2; i++)
                    {
                        textboxs[i].Visibility = Visibility.Visible;
                        textboxs[i].Margin = new Thickness(80, 39 + 30*(i+1), 20, 462 - 30 * (i + 1));
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        Labels[i].Visibility = Visibility.Visible;
                        Labels[i].Margin = new Thickness(7, 39 + 30 * (i + 1), 264, 462 - 30 * (i + 1));
                    }
                    Label3.Text = "PostID";
                    Label4.Text = "Телефон";
                    break;
                default:
                    break;
            }
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            Car c = new Car();
            Zakaz z = new Zakaz();
            Client cl = new Client();
            Employee em = new Employee();
            Post p = new Post();
            switch (table)
            {
                case 0:
                    c.CarID= int.Parse(IDTextBox.Text);
                    c.Mark = NameTextBox.Text;
                    c.Model = TextBox3.Text;
                    c.Colour = TextBox4.Text;
                    c.CarMileage = int.Parse(TextBox5.Text);
                    c.Year = int.Parse(TextBox6.Text);
                    c.CarPriseDay = int.Parse(TextBox7.Text);
                    c.Zalog = int.Parse(TextBox8.Text);
                    c.Nomer = TextBox9.Text;
                    c.CarVinKuzov = TextBox10.Text;
                    c.City = TextBox11.Text;
                    c.CarAbroad = CB1.IsChecked;
                    c.Child = CB2.IsChecked;
                    break;
                case 1:
                    z.ZakazID= int.Parse(IDTextBox.Text);
                    z.EmplID= int.Parse(NameTextBox.Text);
                    z.AktVidachi = int.Parse(TextBox3.Text);
                    z.AktPriema= int.Parse(TextBox4.Text);
                    z.ClientID= int.Parse(TextBox5.Text);
                    z.CarID= int.Parse(TextBox6.Text);
                    z.ZakazStart = new DateTime(date1.SelectedDate.Value.Ticks);
                    z.ZakazEnd = new DateTime(date2.SelectedDate.Value.Ticks);
                    z.Check = CB1.IsChecked;
                    break;
                case 2:
                    cl.ClientID= int.Parse(IDTextBox.Text);
                    cl.ClientName = NameTextBox.Text;
                    cl.ClientPassport = TextBox3.Text;
                    cl.ClientNumDrive = TextBox4.Text;
                    cl.ClientTel = TextBox5.Text;
                    cl.ClientDate = new DateTime(date1.SelectedDate.Value.Ticks);
                    break;
                case 3:
                    em.EmplID= int.Parse(IDTextBox.Text);
                    em.EmplName= NameTextBox.Text;
                    em.PostID = int.Parse(TextBox3.Text);
                    em.EmplTel = TextBox4.Text;
                    break;
                case 4:
                    p.PostID =int.Parse(IDTextBox.Text);
                    p.Post1 = NameTextBox.Text;
                    break;
                default:
                    break;
            }
            if (add==1)
            {
                switch (table)
                {
                    case 0:
                        parent.CreateProduct(c, "Cars");
                        parent.listCar.Add(c);
                        parent.CarShowTable();
                        break;
                    case 1:
                        List<Zakaz> zk = new List<Zakaz>();
                        foreach (var item in parent.listZakaz)
                        {
                            if (item.CarID==z.CarID)
                            {
                                zk.Add(item);
                            }
                        }
                        bool f = true;
                        foreach (var item in zk)
                        {
                            if (item.ZakazEnd < z.ZakazEnd)
                            {
                                if (item.ZakazEnd>z.ZakazStart)
                                {
                                    f=false;
                                }
                            }
                            else
                            {
                                if (item.ZakazStart<z.ZakazEnd)
                                {
                                    f=false;
                                }
                            }
                        }
                        if (f)
                        {
                            parent.CreateProduct(z, "Zakazs");
                            parent.listZakaz.Add(z);
                            parent.ZakazShowTable();
                        }
                        break;
                    case 2:
                        parent.CreateProduct(cl, "Clients");
                        parent.listСlient.Add(cl);
                        parent.ClientShowTable();
                        break;
                    case 3:
                        parent.CreateProduct(em, "Employees");
                        parent.listEmployee.Add(em);
                        parent.EmployeeShowTable();
                        break;
                    case 4:
                        parent.CreateProduct(p, "Posts");
                        parent.listPost.Add(p);
                        parent.PostShowTable();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (table)
                {
                    case 0:
                        if (add == 2)
                        {
                            parent.DeleteProduct("Cars", c.CarID);
                            parent.listCar.Remove(c);
                        }
                        else
                        {
                            parent.UpdateProduct(c, "Cars", c.CarID);
                            parent.listCar[parent.listCar.FindIndex(x => x.CarID == c.CarID)] = c;
                        }
                        parent.CarShowTable();
                        break;
                    case 1:
                        if (add == 2)
                        {
                            parent.DeleteProduct("Zakazs", z.ZakazID);
                            parent.listZakaz.Remove(z);
                        }
                        else
                        {
                            parent.UpdateProduct(z, "Zakazs", z.ZakazID);
                            parent.listZakaz[parent.listZakaz.FindIndex(x => x.ZakazID == z.ZakazID)] = z;
                        }
                        parent.ZakazShowTable();
                        break;
                    case 2:
                        if (add == 2)
                        {
                            parent.DeleteProduct("Clients", cl.ClientID);
                            parent.listСlient.Remove(cl);
                        }
                        else
                        {
                            parent.UpdateProduct(cl, "Clients", cl.ClientID);
                            parent.listСlient[parent.listСlient.FindIndex(x => x.ClientID == cl.ClientID)] = cl;
                        }
                        parent.ClientShowTable();
                        break;
                    case 3:
                        if (add == 2)
                        {
                            parent.DeleteProduct("Employees", em.EmplID);
                            parent.listEmployee.Remove(em);
                        }
                        else
                        {
                            parent.UpdateProduct(em, "Employees", em.EmplID);
                            parent.listEmployee[parent.listEmployee.FindIndex(x => x.EmplID == em.EmplID)] = em;
                        }
                        parent.EmployeeShowTable();
                        break;
                    case 4:
                        if (add == 2)
                        {
                            parent.DeleteProduct("Posts", p.PostID);
                            parent.listPost.Remove(p);
                        }
                        else
                        {
                            parent.UpdateProduct(p, "Posts", p.PostID);
                            parent.listPost[parent.listPost.FindIndex(x => x.PostID == p.PostID)] = p;
                        }
                        parent.PostShowTable();
                        break;
                    default:
                        break;
                }
            }
            this.Close();
        }

        private void IDCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (table)
            {
                case 0:
                    foreach (var item in parent.listCar)
                    {
                        if (item.CarID.ToString()==IDCombo.SelectedItem.ToString())
                        {
                            IDTextBox.Text = item.CarID.ToString();
                            NameTextBox.Text = item.Mark;
                            TextBox3.Text = item.Model;
                            TextBox4.Text = item.Colour;
                            TextBox5.Text = item.CarMileage.ToString();
                            TextBox6.Text = item.Year.ToString();
                            TextBox7.Text = item.CarPriseDay.ToString();
                            TextBox8.Text = item.Zalog.ToString();
                            TextBox9.Text = item.Nomer;
                            TextBox10.Text = item.CarVinKuzov;
                            TextBox11.Text = item.City;
                            CB1.IsChecked = item.CarAbroad;
                            CB2.IsChecked = item.Child;

                            break;
                        }
                    }
                    break;
                case 1:
                    foreach (var item in parent.listZakaz)
                    {
                        if (item.ZakazID.ToString() == IDCombo.SelectedItem.ToString())
                        {
                            IDTextBox.Text = item.ZakazID.ToString();
                            NameTextBox.Text = item.EmplID.ToString();
                            TextBox3.Text = item.AktVidachi.ToString();
                            TextBox4.Text = item.AktPriema.ToString();
                            TextBox5.Text = item.ClientID.ToString();
                            TextBox6.Text = item.CarID.ToString();
                            date1.SelectedDate = item.ZakazStart;
                            date2.SelectedDate = item.ZakazEnd;
                            CB1.IsChecked = item.Check;
                            break;
                        }
                    }
                    break;
                case 2:
                    foreach (var item in parent.listСlient)
                    {
                        if (item.ClientID.ToString() == IDCombo.SelectedItem.ToString())
                        {
                            IDTextBox.Text = item.ClientID.ToString();
                            NameTextBox.Text = item.ClientName;
                            TextBox3.Text = item.ClientPassport;
                            TextBox4.Text = item.ClientNumDrive;
                            TextBox5.Text = item.ClientTel;
                            date1.SelectedDate = item.ClientDate;
                            break;
                        }
                    }
                    break;
                case 3:
                    foreach (var item in parent.listEmployee)
                    {
                        if (item.EmplID.ToString() == IDCombo.SelectedItem.ToString())
                        {
                            IDTextBox.Text = item.EmplID.ToString();
                            NameTextBox.Text = item.EmplName.ToString();
                            TextBox3.Text = item.PostID.ToString();
                            TextBox4.Text = item.EmplTel;
                            break;
                        }
                    }
                    break;
                case 4:
                    foreach (var item in parent.listPost)
                    {
                        if (item.PostID.ToString() == IDCombo.SelectedItem.ToString())
                        {
                            IDTextBox.Text = item.PostID.ToString();
                            NameTextBox.Text = item.Post1.ToString();
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
