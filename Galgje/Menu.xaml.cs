using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Galgje
{
    
    public sealed partial class Menu : Page
    {
        string geheimwoord;
        int maxAantalFouten = 10;

        List<string> doorgeefLijst = new List<string>();
        
        public Menu()
        {
            this.InitializeComponent();
            btnPlay.Click += BtnPlay_Click;   
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (geheimeWoord.Text!="" & geheimeWoord.Text.Length > 2 & geheimeWoord.Text.Length < 13)
            {
                geheimwoord = geheimeWoord.Text;
                doorgeefLijst.Add(geheimwoord);
                doorgeefLijst.Add(maxAantalFouten.ToString());
                this.Frame.Navigate(typeof(MainPage), doorgeefLijst);
            }
        }

        private int valueOfSelectedCheckboxSelected()
        {
            return 5;
        }

        private void SettingsImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PanelBg.Visibility = Visibility.Visible;
            SettingsPanel.Visibility = Visibility.Visible;
            closeSettingsPanel.Visibility = Visibility.Visible;
        }

        private void closeSettingsPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PanelBg.Visibility = Visibility.Collapsed;
            SettingsPanel.Visibility = Visibility.Collapsed;
            closeSettingsPanel.Visibility = Visibility.Collapsed;
        }

        private void cb6Fouten_Checked(object sender, RoutedEventArgs e)
        {
            cb10Fouten.IsChecked = false;
            cb8Fouten.IsChecked = false;
            maxAantalFouten = 6;
        }

        private void cb8Fouten_Checked(object sender, RoutedEventArgs e)
        {
            cb10Fouten.IsChecked = false;
            cb6Fouten.IsChecked = false;
            maxAantalFouten = 8;
        }

        private void cb10Fouten_Checked(object sender, RoutedEventArgs e)
        {
            cb6Fouten.IsChecked = false;
            cb8Fouten.IsChecked = false;
            maxAantalFouten = 10;
        }
    }
}
