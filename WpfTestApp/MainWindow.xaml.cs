using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTestApp
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
        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            TestBtn.IsEnabled = false;
            LogBox.Text = "Started...\n";
            var url = UrlBox.Text;

            var sw = Stopwatch.StartNew();

            var tasks = new List<Task>();
            
            foreach (var i in Enumerable.Range(0, 200))
            {
                var t = new WebClient().DownloadStringTaskAsync(url);
                tasks.Add(t);
            }

            await Task.WhenAll(tasks.ToArray());
            
            sw.Stop();
            LogBox.Text += "end:" + sw.ElapsedMilliseconds;
            TestBtn.IsEnabled = true;
        }
    }
}
