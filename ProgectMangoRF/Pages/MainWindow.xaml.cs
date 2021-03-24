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
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public InfoWindow _InfoWindow;

        public MainWindow()
        {
            InitializeComponent();
            ApplySettings();
        }

        void ApplySettings()
        {
            ChangeTheme();
            Pages();
        }

        void ChangeTheme()
        {
            if(Properties.Settings.Default.DarkMode == true)
            {
                this.Background = Brushes.Black;
                InfoBtn.Style = (Style)FindResource("TabBarButtonDark");
                MiniBtn.Style = (Style)FindResource("TabBarButtonDark");
                MaxiBtn.Style = (Style)FindResource("TabBarButtonDark");
                CloseBtn.Style = (Style)FindResource("TabBarButtonDark");
            }
        }
        void Pages()
        {
            _InfoWindow = new InfoWindow();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if ((string)ClickedButton.Tag == "Info")
            {
                try
                {
                    _InfoWindow.Show();
                    _InfoWindow.WindowState = WindowState.Normal;
                }
                catch
                {

                }
            }
            else if ((string)ClickedButton.Tag == "Minimize")
            {
                this.WindowState = WindowState.Minimized;
            }
            else if ((string)ClickedButton.Tag == "Maximize")
            {
                if(this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                    MaxiBtn.Content = "";
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    MaxiBtn.Content = "";
                }
            }
            else if ((string)ClickedButton.Tag == "Close")
            {
                if(Properties.Settings.Default.AppCanBeClosed == true)
                {
                    Application.Current.Dispatcher.Invoke(Application.Current.Shutdown);
                }
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
