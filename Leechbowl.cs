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
                case "Main St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Rue Principale";
                            break;
                        case "Dutch":
                            str = "Hoofdstraat";
                            break;
                        case "Japanese":
                            str = "大通り";
                            break;
                    }
                    break;
                case "First St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Première Rue";
                            break;
                        case "Dutch":
                            str = "Eerste St";
                            break;
                        case "Japanese":
                            str = "最初の道";
                            break;
                    }
                    break;
                case "Second St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Deuxième Rue";
                            break;
                        case "Dutch":
                            str = "Tweede St";
                            break;
                        case "Japanese":
                            str = "第二の道";
                            break;
                    }
                    break;
                case "Third St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Troisième Rue";
                            break;
                        case "Dutch":
                            str = "Derde St";
                            break;
                        case "Japanese":
                            str = "三番目の道";
                            break;
                    }
                    break;
                case "Fourth St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Quatrième Rue";
                            break;
                        case "Dutch":
                            str = "Vierde St";
                            break;
                        case "Japanese":
                            str = "四番の道";
                            break;
                    }
                    break;
                case "Fifth St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Cinquième Rue";
                            break;
                        case "Dutch":
                            str = "Vijfde St";
                            break;
                        case "Japanese":
                            str = "五番目の道";
                            break;
                    }
                    break;

                // Streets
                case "Rheum St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Rue Rheum";
                            break;
                        case "Dutch":
                            str = "Rheum St";
                            break;
                        case "Japanese":
                            str = "Rheumの道";
                            break;
                    }
                    break;
                case "Lymph St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Rue Lymphe";
                            break;
                        case "Dutch":
                            str = "Lymfe St";
                            break;
                        case "Japanese":
                            str = "リンパ液の道";
                            break;
                    }
                    break;
                case "Hookworm St":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Rue Ankylostome";
                            break;
                        case "Dutch":
                            str = "Mijnworm St";
                            break;
                        case "Japanese":
                            str = "鉤虫の道";
                            break;
                    }
                    break;

                // Roads
                case "Botfly Rd":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Rt Œstre";
                            break;
                        case "Dutch":
                            str = "Horzel Rt";
                            break;
                        case "Japanese":
                            str = "ウマバエの街路";
                            break;
                    }
                    break;
                case "Leechbowl Rd":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Rt Bol-Sangsue";
                            break;
                        case "Dutch":
                            str = "Lijkkom Rt";
                            break;
                        case "Japanese":
                            str = "蛭碗の街路";
                            break;
                    }
                    break;

                // Avenues
                case "Cholera Ave":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Ave Choléra";
                            break;
                        case "Dutch":
                            str = "Cholera Ln";
                            break;
                        case "Japanese":
                            str = "コレラの大通り";
                            break;
                    }
                    break;
                case "Sputum Ave":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Ave Crachat";
                            break;
                        case "Dutch":
                            str = "Sputum Ln";
                            break;
                        case "Japanese":
                            str = "喀痰の大通り";
                            break;
                    }
                    break;

                // misc.
                case "Annelid Cres":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Croi Annélidé";
                            break;
                        case "Dutch":
                            str = "Annelies Sikk";
                            break;
                        case "Japanese":
                            str = "環形動物の三日月";
                            break;
                    }
                    break;
                case "Hematoma Way":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Chem Hématome";
                            break;
                        case "Dutch":
                            str = "Hematoom Weg";
                            break;
                        case "Japanese":
                            str = "血腫の道";
                            break;
                    }
                    break;
                case "Mealworm Ln":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            str = "Voie Ver-de-Farine";
                            break;
                        case "Dutch":
                            str = "Meelworm Gang";
                            break;
                        case "Japanese":
                            str = "ミルワームの路地";
                            break;
                    }
                    break;
            }
            return str;
        }
    }
}
