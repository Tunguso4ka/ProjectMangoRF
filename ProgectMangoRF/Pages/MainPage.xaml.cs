using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace ProgectMangoRF
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
            News1TextBox.Text = "Test\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\nTest\ns";
        }

        void ChangeTheme()
        {
            if (Properties.Settings.Default.DarkMode == true)
            {
                ContinueBtn.Style = (Style)FindResource("MenuButtonDark");
                NewGameBtn.Style = (Style)FindResource("MenuButtonDark");
                AboutBtn.Style = (Style)FindResource("MenuButtonDark");
                SettingsBtn.Style = (Style)FindResource("MenuButtonDark");
                ExitBtn.Style = (Style)FindResource("MenuButtonDark");

                NewsTextBox.Style = (Style)FindResource("TextBoxDark");
                News1TextBox.Style = (Style)FindResource("TextBoxDark");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if((string)ClickedButton.Tag == "ContinueBtn")
            {
                if(Properties.Settings.Default.SaveIsReal == true)
                {

                }
                else
                {
                    RFTextBox.Text = "Sorry, u dont have any saves.";
                    VersionTextBox.Text = "Random Fights\n" + Assembly.GetExecutingAssembly().GetName().Version + " (Project Mango)";
                    ContinueClicks += 1;
                    if (ContinueClicks >= 10 && ContinueClicks < 49)
                    {
                        RFTextBox.Text = "Can you click on another button...";
                    }
                    else if (ContinueClicks == 50)
                    {
                        RFTextBox.Text = "Thats not funny...";
                        ContinueClicks = 0;
                    }
                }
            }
            else if ((string)ClickedButton.Tag == "NewGameBtn")
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
