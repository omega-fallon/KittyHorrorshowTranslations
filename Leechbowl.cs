using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace KittyHorrorshowTranslations
{
    public class Leechbowl : MonoBehaviour
    {
        public static Leechbowl Instance;
        public void Awake()
        {
            Instance = this;
        }

        public string TextReplacement(string str)
        {
            switch (str)
            {
                // How'd you get lost in Leechbowl? The streets are numbered!
                case "First St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
                case "Second St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
                case "Third St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
                case "Fourth St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
                case "Fifth St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;

                // Others
                case "Botfly Rd":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
                case "Leechbowl Rd":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
                case "Cholera Ave":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
                case "Rheum St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
                case "Hematoma Way":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
                case "Lymph St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
                case "Main St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
                case "Annelid Cres":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
                case "Hookworm St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
                case "Sputum Ave":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
                
                case "Mealworm Ln":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "";
                            break;
                        case "Dutch":
                            str = "";
                            break;
                        case "Japanese":
                            str = "";
                            break;
                    }
                    break;
            }
            return str;
        }
    }
}
