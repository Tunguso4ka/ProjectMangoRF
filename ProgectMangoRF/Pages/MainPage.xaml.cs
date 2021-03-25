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
    /// Interakční logika pro MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            ChangeTheme();
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
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if((string)ClickedButton.Tag == "ContinueBtn")
            {
                
            }
            else if ((string)ClickedButton.Tag == "NewGameBtn")
            {
                ((MainWindow)Window.GetWindow(this)).Frame0.Navigate(((MainWindow)Window.GetWindow(this))._NewGamePage);
            }
            else if ((string)ClickedButton.Tag == "AboutBtn")
            {

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
