using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WebAPIClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void RetrieveUsers()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/WebAppSeission1/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/users").Result;
            if(response.IsSuccessStatusCode)
            {
                var users = response.Content.ReadAsAsync<IEnumerable<Users>>().Result;
                usergrid.ItemsSource = users;
                
            }
            else
            {
                MessageBox.Show(response.StatusCode + " with this meesage :" + response.ReasonPhrase);
            }
        }
        private void RetrieveCars()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/WebAppSeission1/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/cars").Result;
            if(response.IsSuccessStatusCode)
            {
                var cars = response.Content.ReadAsAsync<IEnumerable<Cars>>().Result;
                usergrid.ItemsSource = cars;
            }
            else
            {
                MessageBox.Show(response.StatusCode + " With this Message :" + response.ReasonPhrase);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Search_User(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/WebAppSeission1/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var id = txtSearch.Text.Trim();
            var url = "api/users/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if(response.IsSuccessStatusCode)
            {
                var users = response.Content.ReadAsAsync<Users>().Result;
                List<Users> userList = new List<Users>();
                userList.Add(users);
                usergrid.ItemsSource = userList;
            }
            else
            {
                MessageBox.Show(response.StatusCode + " With this Message " + response.ReasonPhrase + "User Not Found");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            RetrieveCars();
        }

        private void Button_AddUser(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Delete_User(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Show_All_Users(object sender, RoutedEventArgs e)
        {
            RetrieveUsers();
        }

        private void Button_Show_all_Cars(object sender, RoutedEventArgs e)
        {
            RetrieveCars();
        }
    }
}
