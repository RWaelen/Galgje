using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galgje
{
    class Controle
    {
        public List<string> secretWord = new List<string> {};
        List<string> currentList = new List<string> {};

        string UserInput="A";
        bool letterInWoord;
        bool gewonnen;

        public void Input(string letter)
        {
            UserInput = letter;
        }

        //controleer of de geselecteerde letter in het geheime woord zit
        public bool IsLetterInWoord()
        {
            letterInWoord = false;
            for (int i = 0; i < secretWord.Count; i++)
            {
                if (UserInput == secretWord[i])
                {
                    letterInWoord = true;
                }
            }
            if (letterInWoord)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //controleer of het spel gewonnen is
        public bool CheckWin()
        {
            for(int i = 0; i < currentList.Count; i++)
            {
                if (currentList[i] == "_")
                {
                    gewonnen = false;
                }
            }
            if (gewonnen != false)
            {
                return true;
            }
            else
            {
                gewonnen = true;
                return false;
            }
        }

        //zet geselecteerde letter op de juiste plaats
        public string ShowCorrectLetter(string current)
        {
            currentList = current.Split(' ').ToList();
            

            for (int i = 0; i < secretWord.Count; i++)
            {
                if (UserInput == secretWord[i])
                {
                    currentList[i] = UserInput;
                }
            }
            string updated = string.Join(" ", currentList.ToArray());

            return updated;
        }

        //zet het geheime woord op het scherm
        public string ShowCorrectWord()
        {
            string word = string.Join(" ", secretWord.ToArray());
            return word;
        }

        public int StringToCharToInt(string text)
        {
            //string, naar char, naar int
            char select = Convert.ToChar(text);
            int selectInt = Convert.ToInt32(select);
            return selectInt;
        }
        public string IntToCharToString(int selectInt)
        {
            //int, naar char, naar string
            char character = (char)selectInt;
            string text = character.ToString();
            return text;
        }
    }
}
