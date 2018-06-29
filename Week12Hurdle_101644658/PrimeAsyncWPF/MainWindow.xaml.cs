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

namespace PrimeAsyncWPF
{
    static class action
    {
        public static Task<long> FindPrimeNumberAsync(long n)
        {
            return Task.Run(() =>
            {
                int count = 0;
                long a = 2;
                while (count < n)
                {
                    long b = 2;
                    int prime = 1;// to check if found a prime
                    while (b * b <= a)
                    {
                        if (a % b == 0)
                        {
                            prime = 0;
                            break;
                        }
                        b++;
                    }
                    if (prime > 0)
                        count++;
                    a++;
                }
                return (--a);
            });
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
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
                var output = await action.FindPrimeNumberAsync(Convert.ToInt64(Input.Text));
                Output.Text += output; 
        }
    }
}