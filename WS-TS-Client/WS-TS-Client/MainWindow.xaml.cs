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

namespace WS_TS_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string message = "Message From Client";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WS_SendMessage(object sender, RoutedEventArgs e)
        {
            //ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            //message = client.GetData(7);
            Logs.Text += $"{DateTime.Now.ToString(@"MM\/dd\/yyyy HH:mm:ss.ff")} {message}\n";
            View.ScrollToBottom();
        }

        private void TS_SendMessage(object sender, RoutedEventArgs e)
        {
            View.ScrollToBottom();
        }

        private async void Start_Communication(object sender, RoutedEventArgs e)
        {
            StartCommunication.IsEnabled = false;
            TransportService.Service1Client client = new TransportService.Service1Client();

            Logs.Text += $"{DateTime.Now.ToString(@"MM\/dd\/yyyy HH:mm:ss.ff")} {"Creating Transports waiting 10 secs"}\n";
            StartCommunication.IsEnabled = await client.StartCrossCommunicationAsync();
            Logs.Text += $"{DateTime.Now.ToString(@"MM\/dd\/yyyy HH:mm:ss.ff")} {"Finished"}\n";

            View.ScrollToBottom();
        }
    }
}
