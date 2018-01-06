using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Galgje
{
    class VisualChangeClass
    {
        List<string> OnjuistList = new List<string> { };
        int lineNumb = 0;

        //galg image path veranderen wanneer een fout gemaakt is
        public string GalgImageChange(int fouten)
        {
            string strFouten = fouten.ToString();
            string ImgPath = "Assets/Galg/GalgT" + strFouten + ".png";
            return ImgPath;            
        }

        //line selecteren om onjuiste letters weer te geven
        public int GetUsedLine()
        {
            for (int i = 0; i < OnjuistList.Count; i++)
            {
                if (i / 4 == 1)
                {
                    lineNumb++;
                    OnjuistList.Clear();
                }
            }
            return lineNumb;
        }

        // gebruikte letters in een string zetten
        public string DisplayOnjuiste(string letter)
        {
            OnjuistList.Add(letter);
            string OnjuisteString = string.Join(" ", OnjuistList.ToArray());
            return OnjuisteString;
        }


    }
}
