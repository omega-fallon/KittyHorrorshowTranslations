using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace KittyHorrorshowTranslations
{
    public class Sunset : MonoBehaviour
    {
        public static Sunset Instance;
        public void Awake()
        {
            Instance = this;
        }

        public string TextReplacement(string str)
        {
            switch (str)
            {
                
            }
            return str;
        }
    }
}
