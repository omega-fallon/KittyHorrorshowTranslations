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

        public void EditObjectNames()
        {
            foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                string translatedName = obj.name;

                Plugin.Instance.PrintThisString("Found object with this name: " + obj.name);
            }
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
