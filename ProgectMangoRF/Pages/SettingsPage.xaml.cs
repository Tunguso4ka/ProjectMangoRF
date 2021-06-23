using System.Windows;
using System.Windows.Controls;

namespace ProjectMangoRF
{
    /// <summary>
    /// Interakční logika pro SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            ElementsApply();
            ChangeTheme();
        }

        void ChangeTheme()
        {
            if (Properties.Settings.Default.DarkMode == true)
            {
                DarkModeTextBlock.Style = (Style)FindResource("TextBlockDark");
                SaveBtn.Style = (Style)FindResource("MenuButtonDark");
                SaveAndRestartBtn.Style = (Style)FindResource("MenuButtonDark");
                PlayerNameTextBlock.Style = (Style)FindResource("TextBlockDark");
                FullscreenTextBlock.Style = (Style)FindResource("TextBlockDark");
            }
        }

        void ElementsApply()
        {
            //Dark mode
            if (Properties.Settings.Default.DarkMode == true) { DarkModeCheckBox.IsChecked = true; }
            //Fullscreen
            if (Properties.Settings.Default.IsFullscreen == true) { FullscreenCheckBox.IsChecked = true; }

            PlayerNameTextBox.Text = Properties.Settings.Default.PlayerName;
        }

        void Save()
        {
            //Dark mode
            if(DarkModeCheckBox.IsChecked == true) { Properties.Settings.Default.DarkMode = true; }
            else { Properties.Settings.Default.DarkMode = false; }

            //Fullscreen
            if (FullscreenCheckBox.IsChecked == true) { Properties.Settings.Default.IsFullscreen = true; }
            else { Properties.Settings.Default.IsFullscreen = false; }

            //PlayerName
            if (PlayerNameTextBox.Text != "" && PlayerNameTextBox.Text.Length < 20) { Properties.Settings.Default.PlayerName = PlayerNameTextBox.Text; }

            Properties.Settings.Default.Save();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if ((string)ClickedButton.Tag == "SaveBtn")
            {
                Save();
            }
            else if ((string)ClickedButton.Tag == "SaveAndRestartBtn")
            {
                Save();
                MainWindow NewMainWindow = new MainWindow();
                NewMainWindow.Show();
                ((MainWindow)Window.GetWindow(this)).Close();
            }
        }
    }
}
