using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetPickerScript : MonoBehaviour
{
    public bool hasSun;
    public bool hasMercury;
    public bool hasVenus;
    public bool hasEarth;
    public bool hasMars;
    public bool hasJupiter;
    public bool hasSaturn;
    public bool hasUranus;

    private UnityEngine.UI.Image noneButton;
    private TMP_Text noneText;
    private UnityEngine.UI.Image sunButton;
    private TMP_Text sunText;
    private UnityEngine.UI.Image mercuryButton;
    private TMP_Text mercuryText;
    private UnityEngine.UI.Image venusButton;
    private TMP_Text venusText;
    private UnityEngine.UI.Image earthButton;
    private TMP_Text earthText;
    private UnityEngine.UI.Image marsButton;
    private TMP_Text marsText;
    private UnityEngine.UI.Image jupiterButton;
    private TMP_Text jupiterText;
    private UnityEngine.UI.Image saturnButton;
    private TMP_Text saturnText;
    private UnityEngine.UI.Image uranusButton;
    private TMP_Text uranusText;

    public bool buttonMenuOpen;

    public GameObject currentStand;

    private GameObject dialougeBox;
    private TMP_Text dialougeText;

    private void Start()
    {
        noneButton = GameObject.Find("NoneButton").GetComponent<UnityEngine.UI.Image>();
        noneText = GameObject.Find("NoneButton").GetComponentInChildren<TMP_Text>();

        sunButton = GameObject.Find("SunButton").GetComponent<UnityEngine.UI.Image>();
        sunText = GameObject.Find("SunButton").GetComponentInChildren<TMP_Text>();

        mercuryButton = GameObject.Find("MercuryButton").GetComponent<UnityEngine.UI.Image>();
        mercuryText = GameObject.Find("MercuryButton").GetComponentInChildren<TMP_Text>();

        venusButton = GameObject.Find("VenusButton").GetComponent<UnityEngine.UI.Image>();
        venusText = GameObject.Find("VenusButton").GetComponentInChildren<TMP_Text>();

        earthButton = GameObject.Find("EarthButton").GetComponent<UnityEngine.UI.Image>();
        earthText = GameObject.Find("EarthButton").GetComponentInChildren<TMP_Text>();

        marsButton = GameObject.Find("MarsButton").GetComponent<UnityEngine.UI.Image>();
        marsText = GameObject.Find("MarsButton").GetComponentInChildren<TMP_Text>();

        jupiterButton = GameObject.Find("JupiterButton").GetComponent<UnityEngine.UI.Image>();
        jupiterText = GameObject.Find("JupiterButton").GetComponentInChildren<TMP_Text>();

        saturnButton = GameObject.Find("SaturnButton").GetComponent<UnityEngine.UI.Image>();
        saturnText = GameObject.Find("SaturnButton").GetComponentInChildren<TMP_Text>();

        uranusButton = GameObject.Find("UranusButton").GetComponent<UnityEngine.UI.Image>();
        uranusText = GameObject.Find("UranusButton").GetComponentInChildren<TMP_Text>();

        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (buttonMenuOpen)
        {
            noneButton.enabled = true;
            noneText.enabled = true;
        }
        else
        {
            noneButton.enabled = false;
            noneText.enabled = false;
        }

        if (hasSun && buttonMenuOpen)
        {
            sunButton.enabled = true;
            sunText.enabled = true;
        }
        else if(buttonMenuOpen == false)
        {
            sunButton.enabled = false;
            sunText.enabled = false;
        }

        if (hasMercury && buttonMenuOpen)
        {
            mercuryButton.enabled = true;
            mercuryText.enabled = true;
        }
        else if(buttonMenuOpen == false)
        {
            mercuryButton.enabled = false;
            mercuryText.enabled = false;
        }

        if (hasVenus && buttonMenuOpen)
        {
            venusButton.enabled = true;
            venusText.enabled = true;
        }
        else if (buttonMenuOpen == false)
        {
            venusButton.enabled = false;
            venusText.enabled = false;
        }

        if (hasEarth && buttonMenuOpen)
        {
            earthButton.enabled = true;
            earthText.enabled = true;
        }
        else if (buttonMenuOpen == false)
        {
            earthButton.enabled = false;
            earthText.enabled = false;
        }

        if (hasMars && buttonMenuOpen)
        {
            marsButton.enabled = true;
            marsText.enabled = true;
        }
        else if (buttonMenuOpen == false)
        {
            marsButton.enabled = false;
            marsText.enabled = false;
        }

        if (hasJupiter && buttonMenuOpen)
        {
            jupiterButton.enabled = true;
            jupiterText.enabled = true;
        }
        else if (buttonMenuOpen == false)
        {
            jupiterButton.enabled = false;
            jupiterText.enabled = false;
        }

        if (hasSaturn && buttonMenuOpen)
        {
            saturnButton.enabled = true;
            saturnText.enabled = true;
        }
        else if (buttonMenuOpen == false)
        {
            saturnButton.enabled = false;
            saturnText.enabled = false;
        }

        if (hasUranus && buttonMenuOpen)
        {
            uranusButton.enabled = true;
            uranusText.enabled = true;
        }
        else if (buttonMenuOpen == false)
        {
            uranusButton.enabled = false;
            uranusText.enabled = false;
        }
    }

    public void PlaceNone()
    {
        currentStand.GetComponent<PanetPuzzleScript>().inDialouge = false;
        buttonMenuOpen = false;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
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

    public void PlaceMercury()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[1].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[1];
        currentStand.GetComponent<PanetPuzzleScript>().inDialouge = false;
        buttonMenuOpen = false;
        hasMercury = false;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
    }

    public void PlaceVenus()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[2].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[2];
        currentStand.GetComponent<PanetPuzzleScript>().inDialouge = false;
        buttonMenuOpen = false;
        hasVenus = false;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
    }

    public void PlaceEarth()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[3].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[3];
        currentStand.GetComponent<PanetPuzzleScript>().inDialouge = false;
        buttonMenuOpen = false;
        hasEarth = false;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
    }

    public void PlaceMars()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[4].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[4];
        currentStand.GetComponent<PanetPuzzleScript>().inDialouge = false;
        buttonMenuOpen = false;
        hasMars = false;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
    }

    public void PlaceJupiter()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[5].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[5];
        currentStand.GetComponent<PanetPuzzleScript>().inDialouge = false;
        buttonMenuOpen = false;
        hasJupiter = false;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
    }

    public void PlaceSaturn()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[6].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[6];
        currentStand.GetComponent<PanetPuzzleScript>().inDialouge = false;
        buttonMenuOpen = false;
        hasSaturn = false;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
    }

    public void PlaceUranus()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[7].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[7];
        currentStand.GetComponent<PanetPuzzleScript>().inDialouge = false;
        buttonMenuOpen = false;
        hasUranus = false;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
    }
}
