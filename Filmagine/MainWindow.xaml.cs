using Filmagine.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Filmagine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //readonly DispatcherTimer _timer = new DispatcherTimer();
        public List<Film> Films { get; set; } = new List<Film>()
        {
            new Film
            {
                Title= "aa",
                Genre="bb",
                Poster="ave.jpg",
                Runtime="1,23"
            },
            new Film
            {
                Title= "aa",
                Genre="bb",
                Poster="ave.jpg",
                Runtime="1,23"
            }

        };
        public MainWindow()
        {
            InitializeComponent();
            //intro.Source = new Uri($@"C:\Users\Rikob\source\repos\Filmagine\Filmagine\Graphic Resources\intro.mp4");
            //DisplayIntro();
            Register window = new Register();
            window.ShowDialog();
            DiscoverMovies.ItemsSource = Films;
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //HomePanel.Visibility = Visibility.Visible;
        }



        //private void Timer_Tick(object sender,EventArgs e)
        //{
        //    _timer.Stop();
        //    intro.Visibility = Visibility.Collapsed;
        //}
        //private void DisplayIntro()
        //{
        //    _timer.Tick += Timer_Tick;
        //    _timer.Interval = new TimeSpan(0, 0, 0, 6);
        //    _timer.Start();
        //}

        public dynamic Data { get; set; }
        HttpClient http = new HttpClient();
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {

                HttpResponseMessage response = new HttpResponseMessage();
                var name = "Fast and Furious";
                response = http.GetAsync($@"http://www.omdbapi.com/?apikey=e4d8a8d9&s={name}&plot=full").Result;
                var str = response.Content.ReadAsStringAsync().Result;
                Data = JsonConvert.DeserializeObject(str);
                MessageBox.Show(Data.Search[0].Plot);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }



}
