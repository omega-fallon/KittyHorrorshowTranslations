using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace KittyHorrorshowTranslations
{
    public class MiscGames : MonoBehaviour
    {
        public static MiscGames Instance;
        public void Awake()
        {
            Instance = this;
        }

        public string TextReplacement(string str)
        {
            switch (str)
            {
                // Acro
                case "Score:":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Score :"; break;
                        case "Dutch": str = "Stand:"; break;
                        case "Japanese": str = "スコア："; break;
                    }
                    break;

                // Amalia
                case "(Press M to close/open map)":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "FILL IN"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "(Press R to close)":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "FILL IN"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "Leave?  (  Y  /  N  )":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "FILL IN"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;

                // Potentially many
                case "Y / N":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Y (OUI) / N (NON)"; break;
                        case "Dutch": str = "Y (JA) / N (NEE)"; break;
                        case "Japanese": str = "Y (はい) / N (いいえ)"; break;
                    }
                    break;
            }
            return str;
        }
    }
}
