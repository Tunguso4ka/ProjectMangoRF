using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ProjectMangoRF
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

        MusicLogic _MusicLogic;
        ConsoleLogic _ConsoleLogic;
        public MainWindow()
        {
            Pages();
            InitializeComponent();
            ApplySettings();
            Frame0.Navigate(_MainPage);
            _MusicLogic.CreateMediaPlayer();
            PlayMusic();
        }

        void ApplySettings()
        {
            ChangeTheme();
            Fullscreen();
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
                ConsoleOpenBtn.Style = (Style)FindResource("TabBarButtonDark");
            }
        }
        void Fullscreen()
        {
            if(Properties.Settings.Default.IsFullscreen == true)
            {
                RightTabBar.Visibility = Visibility.Collapsed;
                WindowChromeBorders.GlassFrameThickness = new Thickness(-1);
                this.WindowState = WindowState.Maximized;
            }
        }
        void Pages()
        {
            _MainPage = new MainPage();
            _SettingsPage = new SettingsPage();
            _NewGamePage = new NewGamePage();
            _AboutPage = new AboutPage();

            _MusicLogic = new MusicLogic();
            _ConsoleLogic = new ConsoleLogic();
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
                    WindowState = WindowState.Normal;
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
            else if ((string)ClickedButton.Tag == "Back")
            {
                if(Frame0.CanGoBack)
                {
                    Frame0.GoBack();
                }
                else
                {
                    BackBtn.Visibility = Visibility.Collapsed;
                }
            }
            else if ((string)ClickedButton.Tag == "EnterConsole")
            {
                if (TextConsoleTextBox.Text != "")
                {
                    _ConsoleLogic.Command(TextConsoleTextBox.Text, this);
                }
            }
            else if ((string)ClickedButton.Tag == "ConsoleOpen")
            {
                if (ConsoleGrid.Visibility == Visibility.Collapsed)
                {
                    ConsoleGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    ConsoleGrid.Visibility = Visibility.Collapsed;
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
                WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Maximized;
                MaxiBtn.Content = "";
                WindowStyle = WindowStyle.None;
                WindowBorder.BorderThickness = new Thickness(5);
            }
            else
            {
                WindowBorder.BorderThickness = new Thickness(1);
            }
        }

        private void Frame0_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (Frame0.CanGoBack)
            {
                BackBtn.Visibility = Visibility.Visible;
            }
            else
            {
                BackBtn.Visibility = Visibility.Collapsed;
            }
        }

        public void PlayMusic()
        {
            _MusicLogic.Play();
        }
    }
}
