using System;
using System.Collections.Generic;
using System.Linq;
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

namespace esercizio_ponte
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Random r = new Random();

        object Ponte = new object();

        public MainWindow()
        {
            InitializeComponent();

            Macchina1.Margin = new Thickness(587, 95, 0, 0);

            Macchina2.Margin = new Thickness(692, 95, 0, 0);

            Macchina3.Margin = new Thickness(70, 227, 0, 0);

            Macchina4.Margin = new Thickness(0, 227, 0, 0);

        }

        public void MuoviConcorrente1()
        {

            Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(50,201)));

            lock (Ponte)
            {
                int concorrente1 = 560;
                int concorrente2 = 682;

                while (true)
                {
                    
                    concorrente1 -= 30;

                    Thread.Sleep(TimeSpan.FromMilliseconds(50));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Macchina1.Margin = new Thickness(concorrente1, 95, 0, 0);
                    }));                   
                 
                    concorrente2 -= 30;

                    Thread.Sleep(TimeSpan.FromMilliseconds(50));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Macchina2.Margin = new Thickness(concorrente2, 95, 0, 0);
                    }));

                    if(concorrente1 <= 20 && concorrente2 <= 50)
                    {
                        break;
                    }
                }
            }  
        }

        public void MuoviConcorrente3()
        {

            Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(50, 201)));

            lock (Ponte)
            {
                int concorrente3 = 138;
                int concorrente4 = 10;

                while (true)
                {

                    concorrente3 += 30;

                    Thread.Sleep(TimeSpan.FromMilliseconds(50));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Macchina3.Margin = new Thickness(concorrente3, 227, 0, 0);
                    }));

                    concorrente4 += 30;

                    Thread.Sleep(TimeSpan.FromMilliseconds(50));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Macchina4.Margin = new Thickness(concorrente4, 227, 0, 0);
                    }));

                    if (concorrente3 > 750 && concorrente4 > 600)
                    {
                        break;
                    }

                }

            }
        }

        private void btnVia_Click(object sender, RoutedEventArgs e)
        {

            Thread t1 = new Thread(new ThreadStart(MuoviConcorrente1));      

            Thread t3 = new Thread(new ThreadStart(MuoviConcorrente3));

            t1.Start();

            t3.Start(); 
        }
    }
}
