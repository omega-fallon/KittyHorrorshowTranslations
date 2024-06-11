using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace KittyHorrorshowTranslations
{
    public class Grandmother : MonoBehaviour
    {
        public static Grandmother Instance;
        public void Awake()
        {
            Instance = this;
        }

        public string HelloWorld()
        {
            return "Hello world!";
        }

        public string TextReplacement(string str)
        {
            switch (str)
            {
                // House
                case "Enter house":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Entrez dans la maison"; break;
                        case "Dutch": str = "Huis binnengaan"; break;
                        case "Japanese": str = "家に入る"; break;
                    }
                    break;
                case "Exit house":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Sortez de la maison"; break;
                        case "Dutch": str = "Verlaat huis"; break;
                        case "Japanese": str = "家を出る"; break;
                    }
                    break;
                case "Turn off television":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Éteignez la télévision"; break;
                        case "Dutch": str = "Zet televisie uit"; break;
                        case "Japanese": str = "テレビを消す"; break;
                    }
                    break;
                case "Turn on television":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Allumez la télévision"; break;
                        case "Dutch": str = "Zet televisie aan"; break;
                        case "Japanese": str = "テレビをつける"; break;
                    }
                    break;
                case "Read book":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Lisez le livre"; break;
                        case "Dutch": str = "Lees boek"; break;
                        case "Japanese": str = "本を読む"; break;
                    }
                    break;
                case "Take knife":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Prenez le couteau"; break;
                        case "Dutch": str = "Neem mes"; break;
                        case "Japanese": str = "ナイフを取る"; break;
                    }
                    break;

                // Barn
                case "Enter barn":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Entrez dans la grange"; break;
                        case "Dutch": str = "Ga schuur binnen"; break;
                        case "Japanese": str = "納屋に入る"; break;
                    }
                    break;
                case "Exit barn":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Sortez de la grange"; break;
                        case "Dutch": str = "Verlaat schuur"; break;
                        case "Japanese": str = "納屋を出る"; break;
                    }
                    break;

                // Mausoleum
                case "Enter mausoleum":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Entrez dans le mausolée"; break;
                        case "Dutch": str = "Ga mausoleum binnen"; break;
                        case "Japanese": str = "霊廟に入る"; break;
                    }
                    break;
                case "Leave mausoleum":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Sortez de le mausolée"; break;
                        case "Dutch": str = "Verlaat mausoleum"; break;
                        case "Japanese": str = "霊廟を出る"; break;
                    }
                    break;
                case "Talk to woman":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Parlez à la femme"; break;
                        case "Dutch": str = "Praat met de vrouw"; break;
                        case "Japanese": str = "女性と話す"; break;
                    }
                    break;
                case "Talk to grinning corpse":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Parlez à la cadavre souriant"; break;
                        case "Dutch": str = "Praat met het grijnzende lijk"; break;
                        case "Japanese": str = "ニヤニヤ笑う死体と話す"; break;
                    }
                    break;

                // Gallows
                case "Kill murderer":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Tuez le meurtrier"; break;
                        case "Dutch": str = "Dood de moordenaar"; break;
                        case "Japanese": str = "殺人犯を殺せ"; break;
                    }
                    break;
                case "Kill blasphemer":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Tuez le blasphémateur"; break;
                        case "Dutch": str = "Dood de godslasteraar"; break;
                        case "Japanese": str = "冒涜者を殺せ"; break;
                    }
                    break;
                case "Kill lecher":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Tuez le pervers"; break;
                        case "Dutch": str = "Dood de geilaard"; break;
                        case "Japanese": str = "好色家を殺せ"; break;
                    }
                    break;
                case "No implement":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Aucun outil"; break;
                        case "Dutch": str = "Geen werktuig"; break;
                        case "Japanese": str = "道具なし"; break;
                    }
                    break;
                case "FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST FEAST":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = str.Replace("FEAST", "FESTOYEZ"); break;
                        case "Dutch": str = str.Replace("FEAST", "FEEST"); break;
                        case "Japanese": str = str.Replace("FEAST", "ごちそう"); break;
                    }
                    break;

                // Finale
                case "Enter terminus":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Entrez dans le terminus"; break;
                        case "Dutch": str = "Terminus binnengaan"; break;
                        case "Japanese": str = "終点に入る"; break;
                    }
                    break;
                case "iknowwhichhouseisyours":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "jesaisquellemaisonestlavôtre"; break;
                        case "Dutch": str = "ikweetwelkhuisvanjouis"; break;
                        case "Japanese": str = "どの              \n  家が            \n    あな          \n      たの        \n        家か      \n          知っ    \n            てい  \n              ます"; break;
                    }
                    break;

                // Fragments of prompts
                default:
                    // Declare strings
                    string openPage = "ERROR";
                    string sheSays = "ERROR";
                    string pressSpace = "ERROR";

                    string book1 = "ERROR";
                    string book2 = "ERROR";
                    string book3 = "ERROR";
                    string book4 = "ERROR";
                    string book5 = "ERROR";

                    string woman1 = "ERROR";
                    string woman2 = "ERROR";
                    string woman3 = "ERROR";
                    string woman4 = "ERROR";
                    string woman5 = "ERROR";

                    // Set the strings
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            openPage = "Vous ouvrez sur une page aléatoire :  ";
                            sheSays = "Elle dit : ";
                            pressSpace = "  (Appuyez Espace pour continuer)";

                            book1 = "FILL IN";
                            book2 = "FILL IN";
                            book3 = "FILL IN";
                            book4 = "FILL IN";
                            book5 = "FILL IN";

                            woman1 = "FILL IN";
                            woman2 = "FILL IN";
                            woman3 = "FILL IN";
                            woman4 = "FILL IN";
                            woman5 = "FILL IN";

                            break;
                        case "Dutch":
                            openPage = "Je opent op een willekeurige pagina:  ";
                            sheSays = "Ze zegt: ";
                            pressSpace = "  (Druk op de Spatiebalk om door te gaan)";

                            book1 = "FILL IN";
                            book2 = "FILL IN";
                            book3 = "FILL IN";
                            book4 = "FILL IN";
                            book5 = "FILL IN";

                            woman1 = "FILL IN";
                            woman2 = "FILL IN";
                            woman3 = "FILL IN";
                            woman4 = "FILL IN";
                            woman5 = "FILL IN";

                            break;
                        case "Japanese":
                            openPage = "本をランダムにページを開いてみます：";
                            sheSays = "彼女が言います：";
                            pressSpace = "  (続行するにはスペースキーを押してください)";

                            book1 = "FILL IN";
                            book2 = "FILL IN";
                            book3 = "FILL IN";
                            book4 = "FILL IN";
                            book5 = "FILL IN";

                            woman1 = "FILL IN";
                            woman2 = "FILL IN";
                            woman3 = "FILL IN";
                            woman4 = "FILL IN";
                            woman5 = "FILL IN";

                            break;
                    }

                    // Do the replacements
                    // Fragments
                    str = str.Replace("You open to a random page:  ", openPage);
                    str = str.Replace("She says: ", sheSays);
                    str = str.Replace("  (Press Space to continue)", pressSpace);

                    // Sections of the book
                    str = str.Replace("\"The Priestess sank into the mud, which whispered to her as it filled her ears, and she felt His oils and secrets slide across the wrinkled flesh of her brain, and she shivered, and the knife burrowed under her ribs...\"", book1);
                    str = str.Replace("\"You will know that you have come to the kingdom of the Hierophant, for the roaches will have the teeth of men, and the wasps will have not stingers but tongues, and the worms will twist themselves into knots until they are torn and bleeding...\"", book2);
                    str = str.Replace("\"Her mother, whose head was full of the Tattered King's perverted songs, shut the girl in the attic, where blood dripped from between the teeth of the mad-eyed rocking horse and the spiders laughed like murderers...\"", book3);
                    str = str.Replace("\"The man walked, driven like cattle by the Tower's groans, and with each step he took a new worm penetrated the sole of his foot, until he was naught but a suit of skin for their family, teeming and boiling at the holes of his eyes...\"", book4);
                    str = str.Replace("\"The boy came to a clearing, where a great bloated tick wallowed in a shallow pond, and he found that he could not speak, for She had filled his mouth with leeches as he was running through the swamp...\"", book5);

                    // Quotes from the grinning woman
                    str = str.Replace("\"I know which house is yours.  I have looked upon your bed.\"", woman1);
                    str = str.Replace("\"I have eaten all the corpses in the graveyard.  I will not stop.\"", woman2);
                    str = str.Replace("\"From each of them, I took an eyelid.  I made myself a fine shawl.\"", woman3);
                    str = str.Replace("\"You should not have come here.\"", woman4);
                    str = str.Replace("\"I raked my teeth against the stone of my own grave until they shattered.  I vomit blood still.\"", woman5);

                    break;
            }
            return str;
        }
    }
}
