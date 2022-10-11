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

namespace WebApiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient httpClient;
        public MainWindow()
        {
            httpClient = new HttpClient();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = httpClient.GetAsync($"https://localhost:44357/api/packages?name={txtSeach.t}")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<Package>>()
                .Result;

            lstbxPackages.ItemsSource = result;
        }


    }

    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class CatFact
    {
        public string Fact { get; set; }
        public int Length { get; set; }
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    }
}
