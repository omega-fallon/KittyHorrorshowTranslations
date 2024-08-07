using BepInEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace KittyHorrorshowTranslations
{
    public class CHYRZA : MonoBehaviour
    {
        public static CHYRZA Instance;
        public void Awake()
        {
            Instance = this;
        }
    }
}
