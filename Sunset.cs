using HutongGames.PlayMaker;
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

        public void Start()
        {
            
        }

        public string TextReplacement(string str)
        {
            string originalString = str;
            switch (str)
            {
                case "With these, we shall flourish.  Our village will be the jewel of the mesa.":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Avec ceux-ci, nous prospérerons.  Notre village sera le joyau de la mesa."; break;
                    }
                    break;
                case "They understood our avarice, honed it into knives, and through our own hands hunted us.":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "FILL IN"; break;
                    }
                    break;
                case "My breath is being sapped.  It is hardening my thoughts, watching me die, celebrating.":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "FILL IN"; break;
                    }
                    break;
                case "Forgive me.":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Pardonne-moi."; break;
                        case "Dutch": str = "Vergeef me."; break;
                        case "Japanese": str = "儂を許して。"; break; // unsure of watashi here. perhaps washi, implying this is an old woman?
                    }
                    break;
                case "They returned with another.  They howled louder when they were brought close together, as though they were calling out to one another.  Screaming, or maybe laughing.":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "FILL IN"; break;
                    }
                    break;
                case "I feel it observing me.  Its singing is ceaseless.  I wish I had never agreed to keep it.":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "FILL IN"; break;
                    }
                    break;
                case "Damn the sage.  His suspicious mewling would feed our hungry bones to the soil.":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "FILL IN"; break;
                    }
                    break;
                case "Where is papa?  Where did these walls come from?":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "FILL IN"; break;
                    }
                    break;
            }
            if (originalString != str)
            {
                Plugin.Instance.PrintThisString("Changed a string from \""+originalString+"\" to \""+str+"\"");
            }
            return str;
        }

        // Bad old code
        public string OldTextReplacement(string str)
        {
            string startingString = str;

            string message1 = "With these, we shall flourish.  Our village will be the jewel of the mesa.";
            string message2 = "Where is papa?  Where did these walls come from?";
            string message3 = "I feel it observing me.  Its singing is ceaseless.  I wish I had never agreed to keep it.";
            string message4 = "Damn the sage.  His suspicious mewling would feed our hungry bones to the soil.";
            string message5 = "They returned with another.  They howled louder when they were brought close together, as though they were calling out to one another.  Screaming, or maybe laughing.";
            string message6 = "My breath is being sapped.  It is hardening my thoughts, watching me die, celebrating.";
            string message7 = "They understood our avarice, honed it into knives, and through our own hands hunted us.";
            string message8 = "Forgive me.";

            string message1_trans = "";
            string message2_trans = "";
            string message3_trans = "";
            string message4_trans = "";
            string message5_trans = "";
            string message6_trans = "";
            string message7_trans = "";
            string message8_trans = "";

            switch (Plugin.Instance.gameLanguage)
            {
                case "French":
                    message1_trans = "Avec ceux-ci, nous prospérerons. Notre village sera le joyau de la mesa.";
                    message2_trans = "Où est papa ? D'où viennent ces murs ?";
                    message3_trans = "Je le sens m'observer. Son chant est incessant. J'aurais aimé ne jamais avoir accepté de le garder.";
                    message4_trans = "Au diable le sage. Ses miaulements suspects nourriraient nos os affamés jusqu'au sol.";
                    message5_trans = "Ils revinrent avec un autre. Ils hurlaient plus fort lorsqu'ils étaient rapprochés, comme s'ils s'interpellaient. Crier, ou peut-être rire.";
                    message6_trans = "Mon souffle est coupé. Cela durcit mes pensées, me regarde mourir, fait la fête.";
                    message7_trans = "Ils ont compris notre avarice, l'ont aiguisée pour en faire des couteaux et nous ont chassés de nos propres mains.";
                    message8_trans = "Pardonne-moi.";
                    break;
            }

            // Dictionary to make the below code cleaner
            Dictionary<string, string> sunsetMessages = new Dictionary<string, string>
            {
                { message1, message1_trans },
                { message2, message2_trans },
                { message3, message3_trans },
                { message4, message4_trans },
                { message5, message5_trans },
                { message6, message6_trans },
                { message7, message7_trans },
                { message8, message8_trans },
            };

            try
            {
                // This is so fucking hacky; find a better way to do this please
                foreach (KeyValuePair<string, string> message in sunsetMessages)
                {
                    if (!string.IsNullOrEmpty(message.Value) && !(str.Length > message.Key.Length) && message.Key.Substring(0, str.Length) == str)
                    {
                        string value = message.Value;

                        // Compare length ( ͡° ͜ʖ ͡°)
                        if (value.Length < message.Key.Length)
                        {
                            value = value.PadRight(message.Key.Length).Substring(0, message.Key.Length);
                        }
                        else if (value.Length > message.Key.Length)
                        {
                            Plugin.Instance.PrintThisString("Translated string is longer than source string.");
                        }

                        // Display full translated string if we're at the end, no matter what.
                        if (startingString.Length == message.Key.Length)
                        {
                            str = value;
                        }
                        else
                        {
                            str = value.Substring(0, startingString.Length);
                        }

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Instance.PrintThisString("Error in Sunset text replacement: "+ex.ToString());
            }

            return str;
        }
    }
}
