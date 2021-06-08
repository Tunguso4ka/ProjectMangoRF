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
        //
        public double Seconds = 0.0;
        public int Minutes = 0;

        /*
        //test
        public int Health0 = 100, Health = 100;
        public int Damage0 = 10, Damage1 = 10;
        public int Heal0 = 15, Heal1 = 15;
        */

        //Players
        NewGamePage _NewGamePage;
        Actions _Actions;

        public GamePage(NewGamePage RecievedNewGamePage)
        {
            InitializeComponent();

            _NewGamePage = RecievedNewGamePage;
            _Actions = new Actions();
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
                StatusRegulator();

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
            if (_NewGamePage.Player0.Health > _NewGamePage.Player0.MaxHealth)
            {
                _NewGamePage.Player0.Health = _NewGamePage.Player0.MaxHealth;
            }
            else if (_NewGamePage.Player0.Health < 0)
            {
                _NewGamePage.Player0.Health = 0;
            }
            HealthBar0.Maximum = _NewGamePage.Player0.MaxHealth;
            HealthBar0.Value = _NewGamePage.Player0.Health;

            if (_NewGamePage.Player1.Health > _NewGamePage.Player1.MaxHealth)
            {
                _NewGamePage.Player1.Health = _NewGamePage.Player1.MaxHealth;
            }
            else if (_NewGamePage.Player1.Health < 0)
            {
                _NewGamePage.Player1.Health = 0;
            }
            HealthBar1.Maximum = _NewGamePage.Player1.MaxHealth;
            HealthBar1.Value = _NewGamePage.Player1.Health;

            //HealthBar logic
            if (HealthBar0.Value == _NewGamePage.Player0.MaxHealth)
            {
                HealthBar0.Foreground = Brushes.Green;
            }
            else if (HealthBar0.Value >= _NewGamePage.Player0.MaxHealth / 2)
            {
                HealthBar0.Foreground = Brushes.LightGreen;
            }
            else if (HealthBar0.Value >= _NewGamePage.Player0.MaxHealth / 4)
            {
                HealthBar0.Foreground = Brushes.Yellow;
            }
            else
            {
                HealthBar0.Foreground = Brushes.Red;
            }

            if (HealthBar1.Value == _NewGamePage.Player1.MaxHealth)
            {
                HealthBar1.Foreground = Brushes.Green;
            }
            else if (HealthBar1.Value >= _NewGamePage.Player1.MaxHealth / 2)
            {
                HealthBar1.Foreground = Brushes.LightGreen;
            }
            else if (HealthBar1.Value >= _NewGamePage.Player1.MaxHealth / 4)
            {
                HealthBar1.Foreground = Brushes.Yellow;
            }
            else
            {
                HealthBar1.Foreground = Brushes.Red;
            }
        }

        void LevelRegulator()
        {

        }

        void StatusRegulator()
        {
            Name0TextBlock.Text = _NewGamePage.Player0.Name;
            Name1TextBlock.Text = _NewGamePage.Player1.Name;

            Lvl0TextBlock.Text = "Lvl: " + _NewGamePage.Player0.Lvl;
            Lvl1TextBlock.Text = "Lvl: " + _NewGamePage.Player1.Lvl;

        }

        //Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if((string)ClickedButton.Tag == "Kick0")
            {
                _Actions.Kick(_NewGamePage.Player0, _NewGamePage.Player1);
                ProcessTextBox0.Text = "Player0 kick Player1\n" + ProcessTextBox0.Text;
                ProcessTextBox1.Text = " \n" + ProcessTextBox1.Text;
            }
            else if ((string)ClickedButton.Tag == "Kick1")
            {
                _Actions.Kick(_NewGamePage.Player1, _NewGamePage.Player0);
                ProcessTextBox0.Text = " \n" + ProcessTextBox0.Text;
                ProcessTextBox1.Text = "Player1 kick Player0\n" + ProcessTextBox1.Text;
            }
            else if ((string)ClickedButton.Tag == "Heal0")
            {
                _Actions.Heal(_NewGamePage.Player0);
                ProcessTextBox0.Text = "Player0 heal themself\n" + ProcessTextBox0.Text;
                ProcessTextBox1.Text = " \n" + ProcessTextBox1.Text;
            }
            else if ((string)ClickedButton.Tag == "Heal1")
            {
                _Actions.Heal(_NewGamePage.Player1);
                ProcessTextBox0.Text = " \n" + ProcessTextBox0.Text;
                ProcessTextBox1.Text = "Player1 heal themself\n" + ProcessTextBox1.Text;
            }
        }
    }
}
