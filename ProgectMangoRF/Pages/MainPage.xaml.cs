using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace ProjectMangoRF
{
    /// <summary>
    /// Interakční logika pro MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        int ContinueClicks;
        public MainPage()
        {
            InitializeComponent();
            ChangeTheme();
            News1TextBox.Text = "Sorry no news today.";
        }

        void ChangeTheme()
        {
            if (Properties.Settings.Default.DarkMode == true)
            {
                NewGameBtn.Style = (Style)FindResource("MenuButtonDark");
                AboutBtn.Style = (Style)FindResource("MenuButtonDark");
                SettingsBtn.Style = (Style)FindResource("MenuButtonDark");
                ExitBtn.Style = (Style)FindResource("MenuButtonDark");
                ChallengesBtn.Style = (Style)FindResource("MenuButtonDark");
                FighterBtn.Style = (Style)FindResource("MenuButtonDark");
                PacksBtn.Style = (Style)FindResource("MenuButtonDark");

                NewsTextBox.Style = (Style)FindResource("TextBoxDark");
                News1TextBox.Style = (Style)FindResource("TextBoxDark");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if ((string)ClickedButton.Tag == "NewGameBtn")
            {
                ((MainWindow)Window.GetWindow(this)).Frame0.Navigate(((MainWindow)Window.GetWindow(this))._NewGamePage);
            }
            else if ((string)ClickedButton.Tag == "AboutBtn")
            {
                ((MainWindow)Window.GetWindow(this)).Frame0.Navigate(((MainWindow)Window.GetWindow(this))._AboutPage);
            }
            else if ((string)ClickedButton.Tag == "SettingsBtn")
            {
                ((MainWindow)Window.GetWindow(this)).Frame0.Navigate(((MainWindow)Window.GetWindow(this))._SettingsPage);
            }
            else if ((string)ClickedButton.Tag == "ExitBtn")
            {
                if(Properties.Settings.Default.AppCanBeClosed == true)
                {
                    Application.Current.Dispatcher.Invoke(Application.Current.Shutdown);
                }
            }
        }
    }
}
