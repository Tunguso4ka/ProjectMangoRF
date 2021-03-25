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
            }
        }

        void ElementsApply()
        {
            if (Properties.Settings.Default.DarkMode == true) { DarkModeCheckBox.IsChecked = true; }
            PlayerNameTextBox.Text = Properties.Settings.Default.PlayerName;
        }

        void Save()
        {
            if(DarkModeCheckBox.IsChecked == true) { Properties.Settings.Default.DarkMode = true; }
            else { Properties.Settings.Default.DarkMode = false; }
            if(PlayerNameTextBox.Text != "" && PlayerNameTextBox.Text.Length < 20) { Properties.Settings.Default.PlayerName = PlayerNameTextBox.Text; }
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
                MainWindow _MainWindow = new MainWindow();
                _MainWindow.Show();
                ((MainWindow)Window.GetWindow(this)).Close();
            }
        }
    }
}
