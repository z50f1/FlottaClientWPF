using FlottaClientWPF.DTOs;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FlottaClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient _client = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5000")
        };


        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginDTO loginDTO = new LoginDTO()
            {
                LoginName = tbxLoginName.Text,
                Password = tbxPassword.Text
            };

            string url = "api/Login";
            string loginString = JsonSerializer.Serialize(loginDTO, JsonSerializerOptions.Default);
            var body = new StringContent(loginString, Encoding.UTF8, "application/json");
            var result = await _client.PostAsync(url, body);
            tbkToken.Text = await result.Content.ReadAsStringAsync();
        }
    }
}