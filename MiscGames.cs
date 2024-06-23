using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace KittyHorrorshowTranslations
{
    public class MiscGames : MonoBehaviour
    {
        public static MiscGames Instance;
        public void Awake()
        {
            Instance = this;
        }

        public string TextReplacement(string str)
        {
            switch (str)
            {
                // Cyberskull
                case "USER DETECTED - PROXY CONTROL ENABLED {I J K L}":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "UTILISATEUR DÉTECTÉ — CONTRO^LE PROXY ACTIVÉ {I J K L}"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;

                case "IM THE CYBERSKULL!!!":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "JE SUIS LE CYBERSKULL!!!"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "|2477l3 |2477l3 |2477l3!!!":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "(l!()_ (l!()_ (l!()_!!!"; break; // cliq
                        case "Dutch": str = "|2473l3|\\| |2473l3|\\| |2473l3|\\|!!!"; break; // ratelen
                        case "Japanese": str = "64746474 64746474 64746474!!!"; break; // がたがた, gatagata
                    }
                    break;
                case "DONT TOUCH MY SERVERS MEATPUNK!!!":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "NE TOUCHEZ PAS A MES SERVEURS VIANDEPUNK!!!"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "TALK SHIT GET BIT... BY THE CYBERSKULL!!!":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "PARLEZ DE MERDE, FAITES-VOUS MORDRE... PAR LE CYBERSKULL!!!"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "IM IN THE BONE ZONE YEEHAWW!!!":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "JE SUIS DANS LE ZONE DES OS TAIAU!!!"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "IF U AINT JACKED IN YOU AINT A BIG SKULL LIKE ME FUCK YOU!!!":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "SI TU N'EST PAS BRANCHE TU N'EST PAS UN GRAND CRANE COMME MOI VA TE FAIRE FOUTRE!!!"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "GET OUTTA MY SKULLZONE U MEAT-HAVER!!!":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "SORS DE MOI ZONE DE CRANE PETIT TRUC DE VIANDE!!!"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;

                case "I COULD WIN A CRUISE!!  THIS BIG IRON VESSEL WITH THE WIDE TEETH COULD COME AND SCOOP ME UP AND TAKE ME ON A DREAM VACATION!!!  THE SCREAMING BOAT WANTS ME TO WIN":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "JE POURRAIS GAGNER UNE CROISIÈRE!! CE GROS NAVIRE EN FER AUX DENTS LARGES POURRAIT VENIR ME RÉCOLTER ET M'EMPORTER EN VACANCES DE RÊVE!!! LE BATEAU CRIANT VEUT QUE JE GAGNE"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "TWO WEEK FREE TRIAL, NO CREDIT CARD REQUIRED, NO MONEY REQUIRED, NO SKIN REQUIRED, NO BLOOD REQUIRED, NO VEINS REQUIRED, NO EYES REQUIRED, NO STOMACH REQUI":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "ESSAI GRATUIT DE DEUX SEMAINES, PAS DE CARTE DE CRÉDIT REQUISE, PAS DE ARGENT REQUIS, PAS DE PEAU REQUISE, PAS DE SANG REQUIS, PAS DE VEINES REQUISE, PAS DE YEUX REQUIS, PAS DE ESTOMAC REQU"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "THE AD SAID ID GET A FREE LAPTOP AND LIKE MB IM NOT CLEAR ON WHAT A LAPTOP IS?????? ALL ITS TEETH ARE ROTTED AND IT WONT STOP YELLNG":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "LA PUB DISAIT QUE J'AURAIS UN ORDINATEUR PORTABLE GRATUIT ET COMME PEUT-ETRE JE NE COMPRENDS PAS CE QU'EST UN ORDINATEUR PORTABLE?????? TOUTES SES DENTS POURRIENT ET IL N'ARRETERA PAS DE CRIER"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "WTF THEY TOLD ME THEY COULD MAKE MY PENIS BIGGER BUT IT'S THE SAME SIZE AND A WAILING AUTOMATON JUST COLLAPSED MY ROOF?????":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "WTF ILS M'ONT DIT QU'ILS POUVAIENT AGRANDIR MON PENIS MAIS IL A LA MEME TAILLE ET UN AUTOMATE GEMISSANT VIENT DE S'EFFONDRER SUR MON TOIT?????"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "OMG I LOVE THIS MOUSE EVRY TIME I CLICK THE PAIN STOPS!!!1!  BRB PUKING BLOOD, I DIDNT NO I HAD THIS MUCH SEEMS LKE I SHLD B EMPTY BY NOW":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "OMD JME TELLEMENT CETTE SOURIS CHQUE FOIS QUE JE CLIQUE LA DOULEUR S'ARRETE!!!1!  JREV JE VOMIS DU SANG, JE NE SAVAIS PAS QUE J'EN HAVAIS AUTANT ON DIRAIT Q JE DEVRAIS ETR VIDE MAINTENANT"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;

                // Wraithshead
                case "\"To The Fire, My Hours\"":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "« Au Feu, Mes Heures »"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "\"The Parting Kiss of the Sand\"":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "« Le Baiser d'Adieu du Sable »"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "\"Left With Naught But Fury and Starlight\"":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "« Ne Restait Plus Que la Fureur et la Lumière des Étoiles »"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "\"Drowned by the Knives of the Forest\"":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "« Noyé par les Couteaux de la Forêt »"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "\"The Altar of Zo'ira\"":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "« L'Autel de Zo'ira »"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;

                // Multi-game lines
                case "Score:":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Score :"; break;
                        case "Dutch": str = "Stand:"; break;
                        case "Japanese": str = "スコア："; break;
                    }
                    break;
                case "(Press M to close/open map)":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "(Appuyez M à fermer/ouvrir la carte)"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "(Press R to close)":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "(Appuyez R pour fermer)"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
                case "Leave?  (  Y  /  N  )":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Sortir ?  (  Y (OUI)  /  N (NON)  )"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;

                case "Y / N":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Y (OUI) / N (NON)"; break;
                        case "Dutch": str = "Y (JA) / N (NEE)"; break;
                        case "Japanese": str = "Y (はい) / N (いいえ)"; break;
                    }
                    break;
                case "ESCAPE TO OS?":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "ÉCHAPPER AU SYSTÈME ?"; break;
                        case "Dutch": str = "FILL IN"; break;
                        case "Japanese": str = "FILL IN"; break;
                    }
                    break;
            }
            return str;
        }
    }
}
