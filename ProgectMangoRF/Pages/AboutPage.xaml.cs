using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace ProjectMangoRF
{
    /// <summary>
    /// Interakční logika pro AboutPage.xaml
    /// </summary>
    public partial class AboutPage : Page
    {
        public AboutPage()
        {
            InitializeComponent();
            ChangeTheme();

            AboutTextBox.Text = "Random Fights .\nVersion: " + Assembly.GetExecutingAssembly().GetName().Version + " (Mango)\nMade by Kira Kosova\nMy twitter: @tunguso4ka\nMy github: tunguso4ka\nI <3 Stef!\nThanks for using!";
        }

        void ChangeTheme()
        {
            if (Properties.Settings.Default.DarkMode == true)
            {
                AboutTextBox.Style = (Style)FindResource("TextBoxDark");
            }
        }
    }
}
