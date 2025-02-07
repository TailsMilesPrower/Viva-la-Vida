using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetPickerScript : MonoBehaviour
{
    public bool hasSun;
    /*public bool hasMercury;
    public bool hasVenus;
    public bool hasEarth;
    public bool hasMars;
    public bool hasJupiter;
    public bool hasSaturn;
    public bool hasUranus;*/

    public UnityEngine.UI.Image sunButton;
    public TMP_Text sunText;
    /*public GameObject mercuryButton;
    public GameObject venusButton;
    public GameObject earthButton;
    public GameObject marsButton;
    public GameObject jupiterButton;
    public GameObject saturnButton;
    public GameObject uranusButton;*/

    public bool buttonMenuOpen;

    public GameObject currentStand;

    public GameObject dialougeBox;
    public TMP_Text dialougeText;

    private void Start()
    {
        sunButton = GameObject.Find("SunButton").GetComponent<UnityEngine.UI.Image>();
        sunText = GameObject.Find("SunButton").GetComponentInChildren<TMP_Text>();
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (hasSun == true && buttonMenuOpen == true)
        {
            sunButton.enabled = true;
            sunText.enabled = true;
        }
        else if(buttonMenuOpen == false)
        {
            sunButton.enabled = false;
            sunText.enabled = false;
        }

        /*if (hasMercury)
        {
            mercuryButton.SetActive(true);
        }
        else
        {
            mercuryButton.SetActive(false);
        }

        if (hasVenus)
        {
            venusButton.SetActive(true);
        }
        else
        {
            venusButton.SetActive(false);
        }

        if (hasEarth)
        {
            earthButton.SetActive(true);
        }
        else
        {
            earthButton.SetActive(false);
        }

        if (hasMars)
        {
            marsButton.SetActive(true);
        }
        else
        {
            marsButton.SetActive(false);
        }

        if (hasJupiter)
        {
            jupiterButton.SetActive(true);
        }
        else
        {
            jupiterButton.SetActive(false);
        }

        if (hasSaturn)
        {
            saturnButton.SetActive(true);
        }
        else
        {
            saturnButton.SetActive(false);
        }*/
    }

    public void PlaceSun()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[0].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[0];
        currentStand.GetComponent<PanetPuzzleScript>().inDialouge = false;
        buttonMenuOpen = false;
        hasSun = false;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
    }

    public void PlaceNone()
    {
        buttonMenuOpen = false;
    }
}
