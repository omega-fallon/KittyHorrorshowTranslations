using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace KittyHorrorshowTranslations
{
    public class Actias : MonoBehaviour
    {
        public static Actias Instance;
        public void Awake()
        {
            Instance = this;
        }

        public string TextReplacement(string str)
        {
            switch (str)
            {
                case "6 remain ":
                case "5 remain ":
                case "4 remain ":
                case "3 remain ":
                case "2 remain ":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = str[0] + " restent "; break;
                        case "Dutch": str = str[0] + " blijven "; break;
                        case "Japanese": str = "残り" + str[0] + "基 "; break; //counter for "big things that are hard to move", specifically listed as being used for Japanese "toro", which are large stone lanterns and fairly analagous to pylons
                    }
                    break;

                case "1 remains ":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "1 reste "; break;
                        case "Dutch": str = "1 blijft "; break;
                        case "Japanese": str = "残り1基 "; break;
                    }
                    break;
            }
            return str;
        }
    }
}
