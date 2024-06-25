using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace KittyHorrorshowTranslations
{
    public class Exclusion : MonoBehaviour
    {
        public static Exclusion Instance;
        public void Awake()
        {
            Instance = this;
        }

        public GameObject pressEnter;
        public GameObject escape;

        public GameObject templeWholeText;
        public GameObject plazaText;
        public GameObject overlookText;
        public GameObject towerInnerText;
        public GameObject towerOuterText;
        public GameObject hengeText;
        public GameObject innerChamberText;
        public GameObject orchardText;

        public void Update()
        {
            GameObject[] texts = { pressEnter, escape, templeWholeText, plazaText, overlookText, towerInnerText, towerOuterText, hengeText, innerChamberText, orchardText };

            foreach (GameObject text in texts) 
            {
                try
                {
                    UnityEngine.UI.Text textComponent = (UnityEngine.UI.Text)text.GetComponent(typeof(UnityEngine.UI.Text));
                    Plugin.Instance.PrintThisString("Text component of " + text.name + " has text: " + textComponent.text);

                    textComponent.text = MiscGames.Instance.TextReplacement(textComponent.text);
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
                case "Based on local historical records and the architecture of the region, we are confident that it was a religious structure of some kind.  However, its arrangement and composition are unlike any similar religious structures of the era or territory, despite superficial architectural similarities.  Previous examination teams have failed to recover any furnishings, artifacts, devices, etc. that would expressly describe the (henceforth) temple's purpose, and while local accounts, examinations of ambient radiation patterns, and simple visual observation of the surrounding countryside leave it beyond question that the temple was the epicenter of the devastation, we remain entirely ignorant as to how it was that the disaster came to pass.  This remains the chief objective of all examination teams dispatched to the exclusion zone.":
                    break;
                case "'Assessment: No Significant New Findings'":
                    break;
                case "\"Easily the most baffling part of the temple at large is the pair of cairn stones on the shore at the bottom of the steps north-west of the complex.  Nearly everything about them seems at odds with the rest of the structure, and with the region itself.  They are of a material that eludes identification and which cannot be located anywhere else on the peninsula.  Their arrangement (and indeed their very presence) suggests a kind of clandestine purpose that would likely be considered paganistic, possibly even heretical when juxtaposed with the dominant religion of the time and territory, yet it is obviously too close to the temple to have been kept hidden.  The glowing arches lining the stone steps which lead to the shore were found to have been constructed after the temple itself, but the cairns themselves, hitherto impossible to date accurately, are highly presumed to have been there for much longer, suggesting a deliberate acknowledgment of the cairns in the arches' construction.  Finally, prior examination teams have found traces of a kind of energetic charge in the air around the cairns, not radioactive yet with a similar half-life to radiation, and distinct from both the fallout of the disaster and the radiation found in the soil of the plots just north of the main structure.\r\n\r\nWhile it seems safe to assume the cairns can have had little to do directly with the catastrophe, both their purpose and their existence remain something of a fascination to us.  Examination teams are encouraged to check the surrounding area, but are cautioned against protracted proximity-- many examiners who remained in the cairns' immediate presence for more than several minutes began experiencing symptoms similar to a combination of radiation poisoning and aetheric plague, with at least one case resulting in death.\"":
                    break;
                case "The central chamber beneath the tower would be, by all accounts, the part of the temple used for communal prayer and administrative gatherings.  Such is the case with other religious facilities of the region, all of which feature a similar central chamber.  However, given the doubt raised as to the actual purpose of the temple, we are disinclined from making such assumptions.  One detail that we find to be most curious regarding the chamber is the fact that not a single one of the examination teams dispatched to the exclusion zone has ever recovered any kind of talisman or artifact from within, nothing so much as a scrap of cloth or particle of ash.  While other areas of the temple show clear signs of damage and dilapidation, the interior chamber is immaculate, almost deliberately so.  Scavengers are rarely so delicate in their work, which rules out the possibility of the chamber having simply been picked clean by opportunistic locals.  Also curious is the fact that despite its location directly beneath the extremely radioactive tower, the inner chamber is consistently found to be one of the least irradiated areas of the complex.  The stone from which the temple is constructed has no particular insulative properties, which makes this something of a mystery to us.  We have continued to look into possible causes for this anomaly, but the absolute lack of salvable material has proved a severe hindrance to our efforts.":
                    break;
                case "\"The swooping, asymmetrical 'fins' of the forward sheltered area have been something of a mystery to previous examination teams.  Their shape and positioning perfectly enables them to gather moisture from the air on balmy days (back when the climate of the area had not been irreparably changed and such days were still possible), which is then channeled into the shallow reflecting pools set into the floor in order that they be kept filled with water.  However, this almost artistic asymmetry is not present in any other part of the structure, and such a break in uniformity is in stark contrast to many of the fundamental religious tenets of the surrounding area.  Put plainly, it seems an ornamental indulgence that makes no sense to us, given what little we know about those who might have occupied this place.\r\n\r\nOne examiner discovered deep channels between the stones at the bottoms of the pool which seemed to run downward some distance, but were too narrow and solid to be inspected further.  Theories suggest some manner of sieve, a mechanism for gathering and storing potable water, or possibly even a cooling system for subterranean parts of the structure as-yet undiscovered.  Future examination teams may be dispatched with equipment suited to further exploration of these possibilities.\"":
                    break;
                case "It is reasonable to assert that the exterior area to the north of the main structure was a plot of some kind.  Many such monasteries and isolated religious communes of the time featured similar outdoor areas, used traditionally to cultivate a staple crop that the temple's residents could survive on or use for trade with nearby settlements.  However, it remains impossible for us to determine just what was grown here.  Soil traces betray no sign of any of the plants indigenous to the area, or indeed any surrounding regions from which seeds may have been imported.  Stranger still, radiation of a kind entirely unique to that modest plot can still be found in the soil, suggesting the growth of some kind of radioactive plant with an extraordinary half-life, distinct even from the radiation that filled the area in the wake of the disaster.  Absolutely no historical accounts of such a plant exist in any archive throughout the entire peninsula.  Consequently, this small area of ground is of great interest to us.  Examination teams are encouraged to check the area thoroughly for anything that may provide further information, no matter how seemingly miniscule.":
                    break;
                case "Dangerous levels of radiation detected":
                    break;
                case "Beginning quarantine procedures":
                    break;
                case "The overlook, for a mercy, is one feature of the temple which can be at least partially explained.  Were it not for the exclusion wall, the overlook would provide a grandiose view of the nearby lake, which is a feature the temple shares with all similar structures of the region.  All are built in proximity to an inland body of water, generally at elevation, and all feature an overlook of similar construction extending from the main structure and pointing toward aforementioned body.   This is of some interest to us, because we have at least some evidence to suggest that the temple was built with the specific purpose of performing whatever unique machinations precipitated the disaster, thus making the construction of an overlook something of a concession-- if the temple's original purpose was NOT the practice of the local religion, then the overlook would be superfluous.  It is possible that some of the temple's residents maintained their old beliefs, and therefore necessitated the overlook's construction, which opens the possibility that the temple's purpose may not be an entirely religious one after all.  It has also been suggested that it was meant merely as a prop, a visual misdirection intended to convince locals from a distance that all atop the lakeside hill was normal and that nothing untoward was being conducted.  Some of us find this possibility to be somewhat cynical, but it cannot be ruled out.":
                    break;
                case "Stand by for extraction":
                    break;
                case "Return to exclusion wall bulkhead for extraction":
                    break;
                case "\"NOTE TO EXAMINATION TEAMS:  EXTREME CAUTION ADVISED WHEN APPROACHING MAIN TOWER OF TEMPLE COMPLEX.  AMBIENT RADIATION AT DANGEROUS LEVELS.  PROTRACTED PROXIMITY TO TOWER HEAVILY DISCOURAGED; EVENTUAL FATALITIES EXTREMELY LIKELY.\r\n\r\nThe tower, being the obvious centerpiece of the temple structure, is presumed by most of us to be the nucleus of the disaster.  The continuing extremes of ambient radiation originating from the tower's apex prevent approach, which has stymied all direct attempts at investigation into the disaster's most probable epicenter, and by extension the entire temple's express role in the calamity.  This has long frustrated us for obvious reasons-- it is exceedingly difficult to piece together the specifics of such a unique event using only secondary accounts, archaeological hints, and speculation.  Most believe the answer to everything is waiting there at the tower's highest point, but our curiosities go ever unsatisfied.  We have been looking into potential alternative means of inspection, including possible aerial passes, long-range examination from atop the exclusion wall, the training and application of eastern gyrvultures (due to their intelligence, manual dexterity, and immunity to most known forms of radiation), and, all other options failing, complete demolition of the tower at its base with hope of a resultant dispersal or reduction of ambient radiation allowing for approach.\"":
                    break;
                case "\"(From the recovered notes of Examiner Saturna (DECEASED)--)\r\n\r\nShe was wronged.  None of this would have happened had her sisters not wronged her so.  She would not have been so lonesome, wouldn't have called out like she did.  She'd have kept her old worshipers, the ones who knew how to build her temples and channel her stones.  The ones that came from where she came from.  She wouldn't have had to call out across the sea to a place she wasn't known.  They only tried to love her and honor her here.  But our stones are not like her stones and our air is not like her air and that's what caused it.  That's why it happened, I'm sure of it.  She will be vilified once her name is learned, but it was her sisters who broke her up and threw her down.  Gods above, it makes me want to cry just thinking about it, how long she must have lain there under the sand, hurting and lonely and angry and not knowing what she did wrong.  And now this.  So much devastation just because she wanted to be loved, and because they wanted to love her but didn't know how.  And now she's alone again, wherever she is.  I don't know how to pray to her, I would if I could.  Maybe just thinking about how sorry I am for everything she's gone through will be enough.  I'm sorry, sister.  You deserved better.  This was not your fault.\"":
                    break;
                case "Examination Complete":
                    break;
            }

            return str;
        }
    }
}
