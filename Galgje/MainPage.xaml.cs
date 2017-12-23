using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Galgje
{

    public sealed partial class MainPage : Page
    {
        VisualChangeClass VisualChange = new VisualChangeClass();
        Controle controle = new Controle();

        string input = "A";
        bool gewonnen = false;
        string geheim;

        List<string> geheimList = new List<string>();
        
        public int fouten { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            btnSelect.Click += BtnSelect_Click;
            btnLinks.Click += BtnLinks_Click;
            btnRechts.Click += BtnRechts_Click;
            btnNewGame.Click += BtnNewGame_Click;
        }

        //event// - parameters van vorige pagina die meegegeven zijn naar string omzetten
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            geheim = e.Parameter.ToString();
            setSecretWord();
        }

        //set secretword + length of word in gui
        private void setSecretWord()
        {
            char[] characters = geheim.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                string text = characters[i].ToString();
                text = text.ToUpper();
                geheimList.Add(text);
            }
            controle.secretWord = geheimList;

            for (int i = 0; i < characters.Length; i++)
            {
                lblSecretWord.Text = lblSecretWord.Text + "_ ";
            }   
        }

        //voer controle uit voor ingevoerde letter. uitkomst kan zijn: juist, onjuist, onjuist game over
        void Check()
        {
            //juist
            controle.Input(input);
            if (controle.IsLetterInWoord())
            {
                lblSecretWord.Text = controle.ShowCorrectLetter(lblSecretWord.Text);
                gewonnen = controle.CheckWin();

                if (gewonnen)
                {
                    lblSelecteer.Visibility = Visibility.Collapsed;
                    Gewonnen.Visibility = Visibility.Visible;
                }
            }
            //onjuist
            else if (fouten < 9)
            {
                fouten++;
                Imaging();
                TextblockEdit();
            }
            //onjuist game over
            else if (fouten < 10)
            {
                fouten++;
                Imaging();
                TextblockEdit();
                lblSelecteer.Visibility = Visibility.Collapsed;
                GameOver.Visibility = Visibility.Visible;
                lblWord.Text = controle.ShowCorrectWord();
                lblWord.Visibility = Visibility.Visible;
            }
        }

        //Create bitmapimage from asset path
        void Imaging()
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(BaseUri, VisualChange.GalgImageChange(fouten)));
            ImgGalg.Source = bitmapImage;
        }

        //zet gebruikte, onjuiste letters in textblock
        void TextblockEdit()
        {
            string usedLine = "Onjuiste" + VisualChange.GetUsedLine();
            TextBlock textBlock = FindName(usedLine) as TextBlock;
            textBlock.Text = VisualChange.DisplayOnjuiste(input);
        }

        //event// - letterselectie controleren
        void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (gewonnen!=true & fouten < 10 )
            {
                Check();
            }
        }

        //event// - zorgt ervoor dat de volgende letter in het alfabet geselecteerd wordt
        void BtnRechts_Click(object sender, RoutedEventArgs e)
        {
            //string, naar char, naar int
            string convertText = lblSelection.Text;
            int selectInt = controle.StringToCharToInt(convertText);

            //Z=unicode 90, niet hoger dus
            if (selectInt < 90)
            {
                selectInt++;
            }

            //int, naar char, naar string
            string text = controle.IntToCharToString(selectInt);
            input = text;
            lblSelection.Text = text;
        }

        //event// - zorgt ervoor dat de vorige letter in het alfabet geselecteerd wordt
        void BtnLinks_Click(object sender, RoutedEventArgs e)
        {
            //string, naar char, naar int
            string convertText = lblSelection.Text;
            int selectInt = controle.StringToCharToInt(convertText);

            //A=unicode 65, niet lager dus
            if (selectInt > 65)
            {
                selectInt--;
            }

            //int, naar char, naar string
            string text = controle.IntToCharToString(selectInt);
            input = text;
            lblSelection.Text = text;
        }

        //event// - New Game ga naar menu page
        private void BtnNewGame_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Menu));
        }
    }
}
