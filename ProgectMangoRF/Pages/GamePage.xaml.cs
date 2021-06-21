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

        double SecondsToAction = 1;
        int SecondsToWait = 1;
        bool FullRandom = false;
        bool Turn = true;
        bool IsPaused = false;
        bool IsDead = false;



        /*
        //test
        public int Health0 = 100, Health = 100;
        public int Damage0 = 10, Damage1 = 10;
        public int Heal0 = 15, Heal1 = 15;
        */

        //Players
        Actions _Actions;
        BotAI _BotAI;
        Player Player0;
        Player Player1;

        public GamePage(NewGamePage RecievedNewGamePage)
        {
            InitializeComponent();

            Player0 = RecievedNewGamePage.Player0;
            Player1 = RecievedNewGamePage.Player1;

            if(RecievedNewGamePage.FullRandom == true)
            {
                MainActionsPanel.Visibility = Visibility.Collapsed;
                FullRandom = true;
            }
            else
            {
                SecondsToWait = 5;
            }

            _BotAI = new BotAI();
            _Actions = new Actions();
            Time();
        }

        async void Time()
        {
            while(true)
            {
                if(IsPaused == false && IsDead == false)
                {
                    Seconds += 0.25;
                    SecondsToAction -= 0.25;

                    if (SecondsToAction <= 0)
                    {
                        TurnRegulator();
                        SecondsToAction += SecondsToWait;
                    }

                    //Regulators
                    TimeRegulator();
                    HealthRegulator();
                    StatusRegulator();
                    LevelRegulator();
                }
                if(IsDead == true)
                {

                }

                await Task.Delay(250);
            }
        }

        public void Say(string Text)
        {
            switch(Turn)
            {
                case true:
                    ProcessTextBox0.Text = Text + "\n" + ProcessTextBox0.Text;
                    ProcessTextBox1.Text = " \n" + ProcessTextBox1.Text;
                    break;
                case false:
                    ProcessTextBox1.Text = Text + "\n" + ProcessTextBox1.Text;
                    ProcessTextBox0.Text = " \n" + ProcessTextBox0.Text;
                    break;
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
            Player0.HealthRegulator();

            HealthBar0.Maximum = Player0.MaxHealth;
            HealthBar0.Value = Player0.Health;
            HealthBar0TextBlock.Text = Player0.Health + "HP / " + Player0.MaxHealth;

            Player1.HealthRegulator();

            HealthBar1.Maximum = Player1.MaxHealth;
            HealthBar1.Value = Player1.Health;
            HealthBar1TextBlock.Text = Player1.Health + "HP / " + Player1.MaxHealth;

            //HealthBar logic
            if (HealthBar0.Value == Player0.MaxHealth)
            {
                HealthBar0.Foreground = Brushes.Green;
            }
            else if (HealthBar0.Value >= Player0.MaxHealth / 2)
            {
                HealthBar0.Foreground = Brushes.LightGreen;
            }
            else if (HealthBar0.Value >= Player0.MaxHealth / 4)
            {
                HealthBar0.Foreground = Brushes.Yellow;
            }
            else
            {
                HealthBar0.Foreground = Brushes.Red;
            }

            if (HealthBar1.Value == Player1.MaxHealth)
            {
                HealthBar1.Foreground = Brushes.Green;
            }
            else if (HealthBar1.Value >= Player1.MaxHealth / 2)
            {
                HealthBar1.Foreground = Brushes.LightGreen;
            }
            else if (HealthBar1.Value >= Player1.MaxHealth / 4)
            {
                HealthBar1.Foreground = Brushes.Yellow;
            }
            else
            {
                HealthBar1.Foreground = Brushes.Red;
            }

            if (Player0.Health == 0)
            {
                IsDead = true;
            }
            if (Player1.Health == 0)
            {
                IsDead = true;
            }
        }

        void LevelRegulator()
        {
            Player0.LevelUp();

            Player1.LevelUp();
        }

        void StatusRegulator()
        {
            Name0TextBlock.Text = Player0.Name;
            Name1TextBlock.Text = Player1.Name;

            Lvl0TextBlock.Text = "Lvl: " + Player0.Lvl;
            Lvl1TextBlock.Text = "Lvl: " + Player1.Lvl;

            //spells: grenade 0, shield 1, ultra heal 2, add additional damage 3, poison 4, additional xp 5

            switch(Player0.Spell)
            {
                case 0:
                    SpellName0TextBlock.Text = "Grenade";
                    break;
                case 1:
                    SpellName0TextBlock.Text = "Shield: " + Player0.Shield;
                    break;
                case 2:
                    SpellName0TextBlock.Text = "Ultra Heal";
                    break;
                case 3:
                    SpellName0TextBlock.Text = "Additional Damage: " + Player0.AdditionalDamage;
                    break;
                case 4:
                    SpellName0TextBlock.Text = "Poison time: " + Player1.PoisonEffectTime;
                    break;
                case 5:
                    SpellName0TextBlock.Text = "Additional XP";
                    break;
            }

            switch (Player1.Spell)
            {
                case 0:
                    SpellName1TextBlock.Text = "Grenade";
                    break;
                case 1:
                    SpellName1TextBlock.Text = "Shield: " + Player1.Shield;
                    break;
                case 2:
                    SpellName1TextBlock.Text = "Ultra Heal";
                    break;
                case 3:
                    SpellName1TextBlock.Text = "Additional Damage: " + Player1.AdditionalDamage;
                    break;
                case 4:
                    SpellName1TextBlock.Text = "Poison time: " + Player0.PoisonEffectTime;
                    break;
                case 5:
                    SpellName1TextBlock.Text = "Additional XP";
                    break;
            }

        }

        void TurnRegulator()
        {
            switch (Turn)
            {
                //Player0 turn
                case true:

                    _BotAI.DoAction(Player0, Player1, FullRandom, this);
                    Turn = false;
                    break;

                //Player1 turn
                case false:

                    _BotAI.DoAction(Player1, Player0, FullRandom, this);
                    Turn = true;
                    break;
            }
        }

        //Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            //Player0
            if((string)ClickedButton.Tag == "Kick0")
            {
                _Actions.Kick(Player0, Player1);
                ProcessTextBox0.Text = "Player0 kick Player1\n" + ProcessTextBox0.Text;
                ProcessTextBox1.Text = " \n" + ProcessTextBox1.Text;
                Turn = false;
            }
            else if ((string)ClickedButton.Tag == "Heal0")
            {
                _Actions.Heal(Player0);
                ProcessTextBox0.Text = "Player0 heal themself\n" + ProcessTextBox0.Text;
                ProcessTextBox1.Text = " \n" + ProcessTextBox1.Text;
                Turn = false;
            }
            else if ((string)ClickedButton.Tag == "Spell0")
            {
                _Actions.Spell(Player0, Player1);
                ProcessTextBox0.Text = "Player0 use spell\n" + ProcessTextBox0.Text;
                ProcessTextBox1.Text = " \n" + ProcessTextBox1.Text;
                Turn = false;
            }
            //Player1
            else if ((string)ClickedButton.Tag == "Kick1")
            {
                _Actions.Kick(Player1, Player0);
                ProcessTextBox0.Text = " \n" + ProcessTextBox0.Text;
                ProcessTextBox1.Text = "Player1 kick Player0\n" + ProcessTextBox1.Text;
            }
            else if ((string)ClickedButton.Tag == "Heal1")
            {
                _Actions.Heal(Player1);
                ProcessTextBox0.Text = " \n" + ProcessTextBox0.Text;
                ProcessTextBox1.Text = "Player1 heal themself\n" + ProcessTextBox1.Text;
            }
            else if ((string)ClickedButton.Tag == "Spell1")
            {
                _Actions.Spell(Player1, Player0);
                ProcessTextBox0.Text = " \n" + ProcessTextBox0.Text;
                ProcessTextBox1.Text = "Player1 use spell\n" + ProcessTextBox1.Text;
            }
        }
    }
}
