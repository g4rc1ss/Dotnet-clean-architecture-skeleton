using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
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
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecastResponse>>("WeatherForecast/all");
            Mouse.OverrideCursor = Cursors.Arrow;
            txtWeatherForecast.Text = JsonSerializer.Serialize(response);
        }
    }
}
