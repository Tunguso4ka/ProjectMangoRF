using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Locale = ProjectMangoRF.Properties.Locale;

namespace ProjectMangoRF
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
        bool Cheats = false;

        /*
        //test
        public int Health0 = 100, Health = 100;
        public int Damage0 = 10, Damage1 = 10;
        public int Heal0 = 15, Heal1 = 15;
        */

        //Players
        Actions _Actions;
        BotAI _BotAI;
        ConsoleLogic _ConsoleLogic;

        public Player Player0;
        public Player Player1;

        public GamePage(NewGamePage RecievedNewGamePage)
        {
            InitializeComponent();

            ChangeTheme();

            if (RecievedNewGamePage.StartFromSave == true)
            {
                Player0 = new Player();
                Player1 = new Player();

                LoadFromSaveGame();

                if (FullRandom == true)
                {
                    MainActionsPanel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    SecondsToWait = 5;
                }

                if (Cheats == true)
                {
                    ConsoleGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    ConsoleGrid.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                Player0 = RecievedNewGamePage.Player0;
                Player1 = RecievedNewGamePage.Player1;

                if (RecievedNewGamePage.FullRandom == true)
                {
                    MainActionsPanel.Visibility = Visibility.Collapsed;
                    FullRandom = true;
                }
                else
                {
                    SecondsToWait = 5;
                }

                if (RecievedNewGamePage.Cheats == true)
                {
                    ConsoleGrid.Visibility = Visibility.Visible;
                    Cheats = true;
                }
                else
                {
                    ConsoleGrid.Visibility = Visibility.Collapsed;
                }
            }

            _BotAI = new BotAI();
            _Actions = new Actions();
            _ConsoleLogic = new ConsoleLogic();

            Time();
        }

        void ChangeTheme()
        {
            if(Properties.Settings.Default.DarkMode == true)
            {
                ProcessTextBox0.Style = (Style)FindResource("TextBoxDark");
                ProcessTextBox1.Style = (Style)FindResource("TextBoxDark");
            }
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
                        SaveGame();
                        TurnRegulator();
                        SecondsToAction += SecondsToWait;
                    }

                    //Regulators
                    TimeRegulator();
                    HealthRegulator();
                    StatusRegulator();
                    LevelRegulator();
                    ChanceRegulator();
                }
                if(IsDead == true)
                {
                    DeleteSave();
                    MainActionsPanel.Visibility = Visibility.Collapsed;
                }

                await Task.Delay(250);
            }
        }

        public void Say(string Text)
        {
            switch(Turn)
            {
                case true:
                    ProcessTextBox0.Text = Text + " - " + TimeTextBlock.Text + "\n" + ProcessTextBox0.Text;
                    ProcessTextBox1.Text = " \n" + ProcessTextBox1.Text;
                    break;
                case false:
                    ProcessTextBox1.Text = TimeTextBlock.Text + " - " + Text + "\n" + ProcessTextBox1.Text;
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
                    SpellName0TextBlock.Text = Locale.Locale.Bomb;
                    break;
                case 1:
                    SpellName0TextBlock.Text = Locale.Locale.Shield + ": " + Player0.Shield;
                    break;
                case 2:
                    SpellName0TextBlock.Text = Locale.Locale.DoubleHeal;
                    break;
                case 3:
                    SpellName0TextBlock.Text = Locale.Locale.AdditionalDamagePotion + ": " + Player0.AdditionalDamage;
                    break;
                case 4:
                    SpellName0TextBlock.Text = Locale.Locale.PoisonPotion + ": " + Player1.PoisonEffectTime;
                    break;
                case 5:
                    SpellName0TextBlock.Text = Locale.Locale.XPPotion;
                    break;
            }

            switch (Player1.Spell)
            {
                case 0:
                    SpellName1TextBlock.Text = Locale.Locale.Bomb;
                    break;
                case 1:
                    SpellName1TextBlock.Text = Locale.Locale.Shield + ": " + Player1.Shield;
                    break;
                case 2:
                    SpellName1TextBlock.Text = Locale.Locale.DoubleHeal;
                    break;
                case 3:
                    SpellName1TextBlock.Text = Locale.Locale.AdditionalDamagePotion + ": " + Player1.AdditionalDamage;
                    break;
                case 4:
                    SpellName1TextBlock.Text = Locale.Locale.PoisonPotion + ": " + Player0.PoisonEffectTime;
                    break;
                case 5:
                    SpellName1TextBlock.Text = Locale.Locale.XPPotion;
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

        void ChanceRegulator()
        {
            Player0.ChanceRegulator();
            Player1.ChanceRegulator();
        }

        //Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            //Player0
            if((string)ClickedButton.Tag == "Kick0")
            {
                Turn = true;
                _Actions.Kick(Player0, Player1, this);

                ActionsStackPanel0.Visibility = Visibility.Collapsed;
                ActionsStackPanel1.Visibility = Visibility.Visible;
            }
            else if ((string)ClickedButton.Tag == "Heal0")
            {
                Turn = true;
                _Actions.Heal(Player0, this);

                ActionsStackPanel0.Visibility = Visibility.Collapsed;
                ActionsStackPanel1.Visibility = Visibility.Visible;
            }
            else if ((string)ClickedButton.Tag == "Spell0")
            {
                Turn = true;
                _Actions.Spell(Player0, Player1, this);

                ActionsStackPanel0.Visibility = Visibility.Collapsed;
                ActionsStackPanel1.Visibility = Visibility.Visible;
            }
            //Player1
            else if ((string)ClickedButton.Tag == "Kick1")
            {
                Turn = false;
                _Actions.Kick(Player1, Player0, this);

                ActionsStackPanel1.Visibility = Visibility.Collapsed;
                ActionsStackPanel0.Visibility = Visibility.Visible;
            }
            else if ((string)ClickedButton.Tag == "Heal1")
            {
                Turn = false;
                _Actions.Heal(Player1, this);

                ActionsStackPanel1.Visibility = Visibility.Collapsed;
                ActionsStackPanel0.Visibility = Visibility.Visible;
            }
            else if ((string)ClickedButton.Tag == "Spell1")
            {
                Turn = false;
                _Actions.Spell(Player1, Player0, this);

                ActionsStackPanel1.Visibility = Visibility.Collapsed;
                ActionsStackPanel0.Visibility = Visibility.Visible;
            }

            else if ((string)ClickedButton.Tag == "EnterConsoleBtn")
            {
                if(TextConsoleTextBox.Text != "")
                {
                    _ConsoleLogic.Command(TextConsoleTextBox.Text, this);
                }
            }
        }

        void SaveGame()
        {
            string SaveName = "save";
            string SavePath = Environment.CurrentDirectory + "/saves/" + SaveName + ".sav";

            if (!Directory.Exists(Environment.CurrentDirectory + "/saves"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "/saves");

            File.Delete(SavePath);
            try
            {
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(SavePath, FileMode.Create));

                //Player0
                Player0.SetSpellName();

                binaryWriter.Write(Player0.Name);

                binaryWriter.Write(Player0.Lvl);
                binaryWriter.Write(Player0.MaxXp);
                binaryWriter.Write(Player0.Xp);

                binaryWriter.Write(Player0.MaxHealth);
                binaryWriter.Write(Player0.Health);
                binaryWriter.Write(Player0.Heal);
                binaryWriter.Write(Player0.Chance);
                binaryWriter.Write(Player0.Shield);

                binaryWriter.Write(Player0.Damage);
                binaryWriter.Write(Player0.AdditionalDamage);

                binaryWriter.Write(Player0.SpellName);
                binaryWriter.Write(Player0.Spell);
                binaryWriter.Write(Player0.PoisonEffectTime);

                //Player1
                Player1.SetSpellName();

                binaryWriter.Write(Player1.Name);

                binaryWriter.Write(Player1.Lvl);
                binaryWriter.Write(Player1.MaxXp);
                binaryWriter.Write(Player1.Xp);

                binaryWriter.Write(Player1.MaxHealth);
                binaryWriter.Write(Player1.Health);
                binaryWriter.Write(Player1.Heal);
                binaryWriter.Write(Player1.Shield);

                binaryWriter.Write(Player1.Damage);
                binaryWriter.Write(Player1.AdditionalDamage);

                binaryWriter.Write(Player1.SpellName);
                binaryWriter.Write(Player1.Spell);
                binaryWriter.Write(Player1.PoisonEffectTime);

                //game

                binaryWriter.Write(Seconds);
                binaryWriter.Write(Minutes);

                binaryWriter.Write(SecondsToAction);
                binaryWriter.Write(SecondsToWait);

                binaryWriter.Write(FullRandom);
                binaryWriter.Write(Turn);
                binaryWriter.Write(IsPaused);
                binaryWriter.Write(IsDead);
                binaryWriter.Write(Cheats);

                binaryWriter.Dispose();
            }
            catch
            {

            }
        }

        void DeleteSave()
        {
            string SaveName = "save";
            string SavePath = Environment.CurrentDirectory + "/saves/" + SaveName + ".sav";
            File.Delete(SavePath);
        }

        void LoadFromSaveGame()
        {
            string SaveName = "save";
            string SavePath = Environment.CurrentDirectory + "/saves/" + SaveName + ".sav";

            if (Directory.Exists(Environment.CurrentDirectory + "/saves"))
            {
                BinaryReader binaryReader = new BinaryReader(File.Open(SavePath, FileMode.Open));

                //Player0

                Player0.Name = binaryReader.ReadString();

                Player0.Lvl = binaryReader.ReadInt32();
                Player0.MaxXp = binaryReader.ReadInt32();
                Player0.Xp = binaryReader.ReadInt32();

                Player0.MaxHealth = binaryReader.ReadInt32();
                Player0.Health = binaryReader.ReadInt32();
                Player0.Heal = binaryReader.ReadInt32();
                Player0.Chance = binaryReader.ReadInt32();
                Player0.Shield = binaryReader.ReadInt32();

                Player0.Damage = binaryReader.ReadInt32();
                Player0.AdditionalDamage = binaryReader.ReadInt32();

                Player0.SpellName = binaryReader.ReadString();
                Player0.Spell = binaryReader.ReadInt32();
                Player0.PoisonEffectTime = binaryReader.ReadInt32();

                Player0.SetSpellName();

                //Player1

                Player1.Name = binaryReader.ReadString();

                Player1.Lvl = binaryReader.ReadInt32();
                Player1.MaxXp = binaryReader.ReadInt32();
                Player1.Xp = binaryReader.ReadInt32();

                Player1.MaxHealth = binaryReader.ReadInt32();
                Player1.Health = binaryReader.ReadInt32();
                Player1.Heal = binaryReader.ReadInt32();
                Player1.Shield = binaryReader.ReadInt32();

                Player1.Damage = binaryReader.ReadInt32();
                Player1.AdditionalDamage = binaryReader.ReadInt32();

                Player1.SpellName = binaryReader.ReadString();
                Player1.Spell = binaryReader.ReadInt32();
                Player1.PoisonEffectTime = binaryReader.ReadInt32();

                Player1.SetSpellName();

                //game

                Seconds = binaryReader.ReadDouble();
                Minutes = binaryReader.ReadInt32();

                SecondsToAction = binaryReader.ReadInt32();
                SecondsToWait = binaryReader.ReadInt32();

                FullRandom = binaryReader.ReadBoolean();
                Turn = binaryReader.ReadBoolean();
                IsPaused = binaryReader.ReadBoolean();
                IsDead = binaryReader.ReadBoolean();
                Cheats = binaryReader.ReadBoolean();

                binaryReader.Dispose();

                TimeRegulator();
                HealthRegulator();
                StatusRegulator();
                LevelRegulator();
            }
        }
    }
}
