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

            //I veicoli che vengono, tramite i Thread, eseguiti e startati per primi hanno la possibilità di transitare per primi sul ponte

            InitializeComponent();

            Macchina1.Margin = new Thickness(587, 95, 0, 0);

            Macchina2.Margin = new Thickness(692, 95, 0, 0);

            Macchina3.Margin = new Thickness(70, 227, 0, 0);

            Macchina4.Margin = new Thickness(0, 227, 0, 0);

            Camion1.Margin = new Thickness(564, 86, 0, 0);

            Camion2.Margin = new Thickness(32, 217, 0, 0);

            Camion3.Margin = new Thickness(32, 217, 0, 0);
        }

        public void MuoviMacchina1()
        {

            Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(50,201)));

            lock (Ponte)
            {
                int macchina1 = 560;
                int macchina2 = 682;

                while (true)
                {
                    
                    macchina1 -= 30;

                    Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(10, 101)));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Macchina1.Margin = new Thickness(macchina1, 95, 0, 0);
                    }));                   
                 
                    macchina2 -= 30;

                    Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(10,101)));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Macchina2.Margin = new Thickness(macchina2, 95, 0, 0);
                    }));

                    if(macchina1 <= 20 && macchina2 <= 50)
                    {
                        break;
                    }
                }
            }  
        }

        public void MuoviCamion1()
        {

            Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(50, 201)));

            lock (Ponte)
            {
                int camion1 = 564;

                while (true)
                {

                    camion1 -= 30;

                    Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(50, 201)));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Camion1.Margin = new Thickness(camion1, 86, 0, 0);
                    }));

                    if (camion1 <= 20)
                    {
                        break;
                    }
                }
            }
        }

        public void MuoviMacchina2()
        {

            Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(50, 201)));

            lock (Ponte)
            {
                int macchina3 = 138;
                int macchina4 = 10;

                while (true)
                {

                    macchina3 += 30;

                    Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(10, 101)));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Macchina3.Margin = new Thickness(macchina3, 227, 0, 0);
                    }));

                    macchina4 += 30;

                    Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(10, 101)));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Macchina4.Margin = new Thickness(macchina4, 227, 0, 0);
                    }));

                    if (macchina3 > 750 && macchina4 > 600)
                    {
                        break;
                    }

                }

            }
        }

        public void MuoviCamion2()
        {

            Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(50, 201)));

            lock (Ponte)
            {
                int camion2 = 32;

                while (true)
                {

                    camion2 += 30;

                    Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(50, 201)));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Camion2.Margin = new Thickness(camion2, 217, 0, 0);
                    }));

                    if (camion2 > 600)
                    {
                        break;
                    }
                }
            }
        }

        public void MuoviCamion3()
        {

            Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(50, 201)));

            lock (Ponte)
            {
                int camion3 = 32;

                while (true)
                {

                    camion3 += 30;

                    Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(50, 201)));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Camion3.Margin = new Thickness(camion3, 217, 0, 0);
                    }));

                    if (camion3 > 600)
                    {
                        break;
                    }
                }
            }
        }

        private void btnVia_Click(object sender, RoutedEventArgs e)
        {

            Thread t1 = new Thread(new ThreadStart(MuoviMacchina1));

            Thread t2 = new Thread(new ThreadStart(MuoviCamion1));

            Thread t3 = new Thread(new ThreadStart(MuoviMacchina2));

            Thread t4 = new Thread(new ThreadStart(MuoviCamion2));

            Thread t5 = new Thread(new ThreadStart(MuoviCamion3));

            t1.Start();

            t2.Start();

            t3.Start();

            t4.Start();

            t5.Start();
        }
    }
}
