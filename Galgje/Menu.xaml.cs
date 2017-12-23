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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Galgje
{
    
    public sealed partial class Menu : Page
    {
        string geheimwoord;
        public Menu()
        {
            this.InitializeComponent();
            btnPlay.Click += BtnPlay_Click;
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (geheimeWoord.Text!="" & geheimeWoord.Text.Length > 3)
            {
                geheimwoord = geheimeWoord.Text;
                this.Frame.Navigate(typeof(MainPage), geheimwoord);
            }
        }
    }
}
