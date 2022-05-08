using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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
using Shared.Peticiones.Responses.WeatherForecast;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient;

        public MainWindow(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("clienteLocalhost");
            InitializeComponent();
        }

        private async void Get_WeatherForecast_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecastResponse>>("WeatherForecast/GetWeatherForecast");
            Mouse.OverrideCursor = Cursors.Arrow;
            txtWeatherForecast.Text = JsonSerializer.Serialize(response);
        }
    }
}
