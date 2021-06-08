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

namespace ProgectMangoRF
{
    /// <summary>
    /// Interakční logika pro GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public int Health0 = 100, Health1 = 100;
        public double Seconds = 0.0;
        public int Minutes = 0;
        public int Damage0 = 10, Damage1 = 10;

        public GamePage()
        {
            InitializeComponent();
            Time();
        }

        async void Time()
        {
            while(true)
            {
                Seconds += 0.25;

                //Regulators
                TimeRegulator();
                HealthRegulator();

                await Task.Delay(250);
            }
        }

        //Regulators
        void TimeRegulator()
        {
            if(Seconds >= 60)
            {
                Seconds -= 60;
                Minutes += 1;
            }
            TimeTextBlock.Text = Minutes + ":" + (int)Seconds;
        }

        void HealthRegulator()
        {
            //Health logic
            if (Health0 > 100)
            {
                Health0 = 100;
            }
            else if (Health0 < 0)
            {
                Health0 = 0;
            }
            HealthBar0.Value = Health0;

            if (Health1 > 100)
            {
                Health1 = 100;
            }
            else if (Health1 < 0)
            {
                Health1 = 0;
            }
            HealthBar1.Value = Health1;

            //HealthBar logic
            if (HealthBar0.Value == 100)
            {
                HealthBar0.Foreground = Brushes.Green;
            }
            else if (HealthBar0.Value >= 50)
            {
                HealthBar0.Foreground = Brushes.LightGreen;
            }
            else if (HealthBar0.Value >= 25)
            {
                HealthBar0.Foreground = Brushes.Yellow;
            }
            else
            {
                HealthBar0.Foreground = Brushes.Red;
            }

            if (HealthBar1.Value == 100)
            {
                HealthBar1.Foreground = Brushes.Green;
            }
            else if (HealthBar1.Value >= 50)
            {
                HealthBar1.Foreground = Brushes.LightGreen;
            }
            else if (HealthBar1.Value >= 25)
            {
                HealthBar1.Foreground = Brushes.Yellow;
            }
            else
            {
                HealthBar1.Foreground = Brushes.Red;
            }
        }

        //Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if((string)ClickedButton.Tag == "Kick0")
            {
                Health1 -= Damage0;
                ProcessTextBox0.Text = "Player0 kick Player1\n" + ProcessTextBox0.Text;
                ProcessTextBox1.Text = " \n" + ProcessTextBox1.Text;
            }
            else if ((string)ClickedButton.Tag == "Kick1")
            {
                Health0 -= Damage1;
                ProcessTextBox0.Text = " \n" + ProcessTextBox0.Text;
                ProcessTextBox1.Text = "Player1 kick Player0\n" + ProcessTextBox1.Text;
            }
        }
    }
}
