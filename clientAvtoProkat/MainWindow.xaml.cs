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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace clientAvtoProkat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient client = new HttpClient();
        static HttpClient client2 = new HttpClient();
        int NumClient = 0;
        public List<Client> listСlient;
        public List<Car> listCar;
        public List<Zakaz> listZakaz;
        public List<Employee> listEmployee;
        public List<Post> listPost;
        int table;
        public MainWindow()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:4902/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client2.BaseAddress = new Uri("http://localhost:4903/");
            client2.DefaultRequestHeaders.Accept.Clear();
            client2.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            CarShowTable();
            ClientShowTable();
            EmployeeShowTable();
            PostShowTable();
            ZakazShowTable();
        }
            static async Task RunAsync()
        {
            /*System.Net.ServicePointManager.Expect100Continue = false;
            try
            {
                Post post= new Post();
                post.PostID = 2;
                post.Post1 = "rfrf";
                await CreateProduct(post, "Posts");
            }
            catch (Exception)
            {

                throw;
            }*/
            //await DeleteProduct("Posts", 3);
            /*Post post = new Post();
            post.PostID = 2;
            post.Post1 = "Босс";
            await UpdateProduct("Posts",2,post);*/
        }
        public async Task CreateProduct(object post,string table)
        {
            HttpResponseMessage response;
            if (NumClient == 0)
            {
                response = client.PostAsJsonAsync(
                    "api/" + table, post).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                }
            }
            else
            {
                NumClient = 1;
                response = client2.PostAsJsonAsync(
                        "api/" + table, post).Result;
                response.EnsureSuccessStatusCode();
            }
        }
        public async Task DeleteProduct(string table,int id)
        {
            HttpResponseMessage response;
            if (NumClient == 0)
            {
                response = client.DeleteAsync(
                    "api/" + table + $"/{id}").Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                }
            }
            else
            {
                NumClient = 1;
                response = client2.DeleteAsync(
                        "api/" + table + $"/{id}").Result;
                response.EnsureSuccessStatusCode();
            }
        }
        public async Task<HttpContent> GetProduct(string table, int id)
        {
            HttpResponseMessage response;
            if (NumClient == 0)
            {
                response = client.GetAsync(
                   "api/" + table + $"/{id}").Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                    return response.Content;
                }
            }
            NumClient = 1;
            response = client2.GetAsync(
                   "api/" + table + $"/{id}").Result;
            return response.Content;
        }
        public async Task<HttpContent> GetProducts(string table)
        {
            HttpResponseMessage response;
            if (NumClient == 0)
            {
                response = client.GetAsync(
                    "api/" + table).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Content;
                }
            }
            NumClient = 1;
            response = client2.GetAsync(
                "api/" + table).Result;
            return response.Content;
        }
        public async Task UpdateProduct(object prod,string table, int id)
        {
            HttpResponseMessage response;
            if (NumClient == 0)
            {
                response = client.PutAsJsonAsync(
                    "api/" + table + $"/{id}", prod).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                }
            }
            else
            {
                NumClient = 1;
                response = client2.GetAsync(
                    "api/" + table).Result;
            }

        }
        private void ok(object sender, RoutedEventArgs e)
        {
            RunAsync().GetAwaiter().GetResult();
        }
        private void ClientShowTable(object sender, RoutedEventArgs e)
        {
            var httpget = GetProducts("Clients");
            listСlient = httpget.Result.ReadAsAsync<List<Client>>().Result;
            DT.ItemsSource = listСlient;
            table = 2;
        }
        public void ClientShowTable()
        {
            var httpget = GetProducts("Clients");
            listСlient = httpget.Result.ReadAsAsync<List<Client>>().Result;
            DT.ItemsSource = listСlient;
            table = 2;
        }

        private void CarShowTable(object sender, RoutedEventArgs e)
        {
            var httpget = GetProducts("Cars");
            listCar = httpget.Result.ReadAsAsync<List<Car>>().Result;
            DT.ItemsSource = listCar;
            table = 0;
        }
        public void CarShowTable()
        {
            var httpget = GetProducts("Cars");
            listCar = httpget.Result.ReadAsAsync<List<Car>>().Result;
            DT.ItemsSource = listCar;
            table = 0;
        }

        private void ZakazShowTable(object sender, RoutedEventArgs e)
        {
            var httpget = GetProducts("Zakazs");
            listZakaz = httpget.Result.ReadAsAsync<List<Zakaz>>().Result;
            DT.ItemsSource = listZakaz;
            table = 1;
        }
        public void ZakazShowTable()
        {
            var httpget = GetProducts("Zakazs");
            listZakaz = httpget.Result.ReadAsAsync<List<Zakaz>>().Result;
            DT.ItemsSource = listZakaz;
            table = 1;
        }

        private void EmployeeShowTable(object sender, RoutedEventArgs e)
        {
            var httpget = GetProducts("Employees");
            listEmployee = httpget.Result.ReadAsAsync<List<Employee>>().Result;
            DT.ItemsSource = listEmployee;
            table = 3;
        }
        public void EmployeeShowTable()
        {
            var httpget = GetProducts("Employees");
            listEmployee = httpget.Result.ReadAsAsync<List<Employee>>().Result;
            DT.ItemsSource = listEmployee;
            table = 3;
        }

        private void PostShowTable(object sender, RoutedEventArgs e)
        {
            var httpget = GetProducts("Posts");
            listPost = httpget.Result.ReadAsAsync<List<Post>>().Result;
            DT.ItemsSource = listPost;
            table = 4;
        }
        public void PostShowTable()
        {
            var httpget = GetProducts("Posts");
            listPost = httpget.Result.ReadAsAsync<List<Post>>().Result;
            DT.ItemsSource = listPost;
            table = 4;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Add_Update add_ = new Add_Update(1, table,this) ;
            add_.Show();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Add_Update add_ = new Add_Update(0, table, this);
            add_.Show();
        }

        private void DeleneButton_Click(object sender, RoutedEventArgs e)
        {
            Add_Update add_ = new Add_Update(2, table, this);
            add_.Show();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Search search = new Search(this);
            search.Show();
        }
    }
}
