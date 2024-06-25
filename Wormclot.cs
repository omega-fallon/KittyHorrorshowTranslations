using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace KittyHorrorshowTranslations
{
    public class Wormclot : MonoBehaviour
    {
        public static Wormclot Instance;
        public void Awake()
        {
            Instance = this;
        }

        public void Update()
        {
            Text[] allText = (Text[])FindObjectsOfTypeAll(typeof(Text));

            foreach (Text text in allText)
            {
                try
                {
                    text.text = Wormclot.Instance.TextReplacement(text.text);
                    text.text = MiscGames.Instance.TextReplacement(text.text);
                }
                catch
                {

                }
            }
        }

        public string TextReplacement(string str)
        {
            switch (str)
            {
                case "C a s t l e p a t h y":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "C h â t e a u p a t h i e"; break;
                        case "Dutch": str = "K a s t e e l p a t h i e"; break;
                        case "Japanese": str = "し ろ パ シ ー"; break;
                    }
                    break;
                case "Name:\nClass:\nAngst:\nGloom:\nPiety:\nWoe:\nVomit:":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Nom :\nClasse :\nAngoisse :\nTristesse :\nPiété :\nMalheur :\nVomi :"; break;
                    }
                    break;
            }

            return str;
        }
    }
}
