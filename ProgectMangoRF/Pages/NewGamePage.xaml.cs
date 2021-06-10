using System.Windows;
using System.Windows.Controls;

namespace ProgectMangoRF
{
    /// <summary>
    /// Interakční logika pro NewGamePage.xaml
    /// </summary>
    public partial class NewGamePage : Page
    {
        int UserSpecial = 0, BotSpecial = 0;

        public GamePage _GamePage;

        public Player Player0;
        public Player Player1;

        public NewGamePage()
        {
            InitializeComponent();
            ChangeTheme();
        }

        void ChangeTheme()
        {
            if (Properties.Settings.Default.DarkMode == true)
            {
                BackBtn.Style = (Style)FindResource("MenuButtonDark");
                PlayBtn.Style = (Style)FindResource("MenuButtonDark");

                BotTextBlock.Style = (Style)FindResource("TextBlockDark");
                CheatsTextBlock.Style = (Style)FindResource("TextBlockDark");
                FullRandomTextBlock.Style = (Style)FindResource("TextBlockDark");
                RandomServerTextBlock.Style = (Style)FindResource("TextBlockDark");
                YourSpecialTextBlock.Style = (Style)FindResource("TextBlockDark");
                BotSpecialTextBlock.Style = (Style)FindResource("TextBlockDark");
                
                UserRadioButtonBomb.Style = (Style)FindResource("RadioButtonDark");
                UserRadioButtonPoison.Style = (Style)FindResource("RadioButtonDark");
                UserRadioButtonStrenght.Style = (Style)FindResource("RadioButtonDark");
                UserRadioButtonShield.Style = (Style)FindResource("RadioButtonDark");
                UserRadioButtonXP.Style = (Style)FindResource("RadioButtonDark");
                UserRadioButtonRandom.Style = (Style)FindResource("RadioButtonDark");

                BotRadioButtonBomb.Style = (Style)FindResource("RadioButtonDark");
                BotRadioButtonPoison.Style = (Style)FindResource("RadioButtonDark");
                BotRadioButtonStrenght.Style = (Style)FindResource("RadioButtonDark");
                BotRadioButtonShield.Style = (Style)FindResource("RadioButtonDark");
                BotRadioButtonXP.Style = (Style)FindResource("RadioButtonDark");
                BotRadioButtonRandom.Style = (Style)FindResource("RadioButtonDark");
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox CheckedCheckBox = (CheckBox)sender;
            if((string)CheckedCheckBox.Tag == "BotCheckBox")
            {
                //BotSpecialStackPanel.Visibility = Visibility.Visible;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox CheckedCheckBox = (CheckBox)sender;
            if ((string)CheckedCheckBox.Tag == "BotCheckBox")
            {
                BotSpecialStackPanel.Visibility = Visibility.Collapsed;
            }
        }

        void MakeStandartInts(Player _Player)
        {
            _Player.Lvl = 1;
            _Player.Xp = 0;

            _Player.MaxHealth = 100;
            _Player.Health = 100;
            _Player.Heal = 15;
            _Player.Shield = 0;

            _Player.Damage = 10;
            _Player.AdditionalDamage = 0;

            _Player.PoisonEffectTime = 0;
        }

        private void UserRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //spells: grenade 0, shield 1, ultra heal 2, add additional damage 3, poison 4, additional xp 5
            RadioButton CheckedRadioButton = (RadioButton)sender;
            if((string)CheckedRadioButton.Tag == "grenade")
            {
                UserSpecial = 0;
            }
            else if ((string)CheckedRadioButton.Tag == "shield")
            {
                UserSpecial = 1;
            }
            else if ((string)CheckedRadioButton.Tag == "ultraheal")
            {
                UserSpecial = 2;
            }
            else if ((string)CheckedRadioButton.Tag == "additionaldamage")
            {
                UserSpecial = 3;
            }
            else if ((string)CheckedRadioButton.Tag == "poison")
            {
                UserSpecial = 4;
            }
            else if ((string)CheckedRadioButton.Tag == "xp")
            {
                UserSpecial = 5;
            }
            else if ((string)CheckedRadioButton.Tag == "random")
            {
                UserSpecial = 0;
            }
        }

        private void BotRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //spells: grenade 0, shield 1, ultra heal 2, add additional damage 3, poison 4, additional xp 5
            RadioButton CheckedRadioButton = (RadioButton)sender;
            if ((string)CheckedRadioButton.Tag == "grenade")
            {
                BotSpecial = 0;
            }
            else if ((string)CheckedRadioButton.Tag == "shield")
            {
                BotSpecial = 1;
            }
            else if ((string)CheckedRadioButton.Tag == "ultraheal")
            {
                BotSpecial = 2;
            }
            else if ((string)CheckedRadioButton.Tag == "additionaldamage")
            {
                BotSpecial = 3;
            }
            else if ((string)CheckedRadioButton.Tag == "poison")
            {
                BotSpecial = 4;
            }
            else if ((string)CheckedRadioButton.Tag == "xp")
            {
                BotSpecial = 5;
            }
            else if ((string)CheckedRadioButton.Tag == "random")
            {
                BotSpecial = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if ((string)ClickedButton.Tag == "BackBtn")
            {
                ((MainWindow)Window.GetWindow(this)).Frame0.GoBack();
            }
            else if ((string)ClickedButton.Tag == "PlayBtn")
            {
                //Player0 (user)
                Player0 = new Player();
                Player0.Name = Properties.Settings.Default.PlayerName;
                Player0.Spell = UserSpecial;
                MakeStandartInts(Player0);

                //Player1 (bot/second user)
                Player1 = new Player();
                Player1.Name = "Name";
                Player1.Spell = BotSpecial;
                MakeStandartInts(Player1);

                _GamePage = new GamePage(((MainWindow)Window.GetWindow(this))._NewGamePage);
                ((MainWindow)Window.GetWindow(this)).Frame0.Navigate(_GamePage);
            }
        }
    }
}
