using System;
using System.Collections.Generic;
using System.Linq;
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
