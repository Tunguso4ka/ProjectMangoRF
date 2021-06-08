using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ProgectMangoRF
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainPage _MainPage;
        public SettingsPage _SettingsPage;
        public NewGamePage _NewGamePage;
        public AboutPage _AboutPage;
        public GamePage _GamePage;

        public MainWindow()
        {
            Pages();
            InitializeComponent();
            ApplySettings();
            Frame0.Navigate(_MainPage);
        }

        void ApplySettings()
        {
            ChangeTheme();
        }

        void ChangeTheme()
        {
            if(Properties.Settings.Default.DarkMode == true)
            {
                this.Background = Brushes.Black;
                MiniBtn.Style = (Style)FindResource("TabBarButtonDark");
                MaxiBtn.Style = (Style)FindResource("TabBarButtonDark");
                CloseBtn.Style = (Style)FindResource("TabBarButtonDark");
                BackBtn.Style = (Style)FindResource("TabBarButtonDark");
            }
        }
        void Pages()
        {
            _MainPage = new MainPage();
            _SettingsPage = new SettingsPage();
            _NewGamePage = new NewGamePage();
            _AboutPage = new AboutPage();
            _GamePage = new GamePage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if ((string)ClickedButton.Tag == "Minimize")
            {
                WindowState = WindowState.Minimized;
            }
            else if ((string)ClickedButton.Tag == "Maximize")
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    FrameBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 200, 0));
                    WindowState = WindowState.Normal;
                    MaxiBtn.Content = "";
                }
                else
                {
                    FrameBorder.BorderBrush = Brushes.Transparent;
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                    this.WindowState = WindowState.Maximized;
                    MaxiBtn.Content = "";
                    this.WindowStyle = WindowStyle.None;
                }

                /*
                if (WindowState == WindowState.Maximized)
                {
                    if(Properties.Settings.Default.IsFullscreen == true)
                    {
                        FrameBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 200, 0));
                    }
                    else
                    {
                        ResizeMode = ResizeMode.CanMinimize;
                    }
                    WindowState = WindowState.Normal;
                    MaxiBtn.Content = "";
                }
                else if (Properties.Settings.Default.IsFullscreen == true)
                {
                    FrameBorder.BorderBrush = Brushes.Transparent;
                    WindowState = WindowState.Maximized;
                    MaxiBtn.Content = "";
                }
                else
                {
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    ResizeMode = ResizeMode.CanResize;
                    WindowState = WindowState.Maximized;
                    WindowStyle = WindowStyle.None;
                    MaxiBtn.Content = "";
                }
                */
            }
            else if ((string)ClickedButton.Tag == "Close")
            {
                if(Properties.Settings.Default.AppCanBeClosed == true)
                {
                    Application.Current.Dispatcher.Invoke(Application.Current.Shutdown);
                }
            }
            else if ((string)ClickedButton.Tag == "Back")
            {
                if(Frame0.CanGoBack)
                {
                    Frame0.GoBack();
                }
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_StateChanged(object sender, System.EventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
            {
                FrameBorder.BorderBrush = Brushes.Transparent;
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Maximized;
                MaxiBtn.Content = "";
                this.WindowStyle = WindowStyle.None;
            }
            else if (this.WindowState == WindowState.Minimized)
            {

            }
            else
            {
                FrameBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 200, 0));
                WindowState = WindowState.Normal;
                MaxiBtn.Content = "";
            }
        }
    }
}
