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
using System.Net.Http;

namespace JsonAsyncWPF
{
    static class action
    {
        public static async Task<string> DownloadPageAsync()
        {
            // ... Target page.
            string page = "https://jsonplaceholder.typicode.com/posts/1/comments";

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                return result;
            }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            string data = await action.DownloadPageAsync();
            AsyncReturn.Text += data;
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
                string data = await action.DownloadPageAsync();
                AsyncReturn.Text += data;

        }
    }
}         