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
using System.Windows.Shapes;

namespace ProgectMangoRF
{
    /// <summary>
    /// Interakční logika pro InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();
            _TextBox.Text = "\n\nBy Kira Kosova, twitter/github: tunguso4ka";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;

            if ((string)ClickedButton.Tag == "Minimize")
            {
                this.WindowState = WindowState.Minimized;
            }
            else if ((string)ClickedButton.Tag == "Close")
            {
                this.Hide();
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
