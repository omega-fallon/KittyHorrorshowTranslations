using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace KittyHorrorshowTranslations
{
    public class Basements : MonoBehaviour
    {
        public static Basements Instance;
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
                    text.text = Basements.Instance.TextReplacement(text.text);
                    text.text = MiscGames.Instance.TextReplacement(text.text);
                }
                catch
                {

                }
            }
        }

        public string TextReplacement(string str)
        {
            return "FILL IN";
        }
    }
}
