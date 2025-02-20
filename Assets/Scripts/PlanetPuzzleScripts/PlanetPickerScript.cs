using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetPickerScript : MonoBehaviour
{
    private PlanetPickerScript instance;

    public bool hasSun;
    public bool hasMercury;
    public bool hasVenus;
    public bool hasEarth;
    public bool hasMars;
    public bool hasJupiter;
    public bool hasSaturn;
    public bool hasUranus;

    private Image noneButton;
    private TMP_Text noneText;
    private Image sunButton;
    private TMP_Text sunText;
    private Image mercuryButton;
    private TMP_Text mercuryText;
    private Image venusButton;
    private TMP_Text venusText;
    private Image earthButton;
    private TMP_Text earthText;
    private Image marsButton;
    private TMP_Text marsText;
    private Image jupiterButton;
    private TMP_Text jupiterText;
    private Image saturnButton;
    private TMP_Text saturnText;
    private Image uranusButton;
    private TMP_Text uranusText;

    public bool buttonMenuOpen;

    public GameObject currentStand;

    private GameObject dialougeBox;
    private TMP_Text dialougeText;

    public Movement player;

    private void Start()
    {
        // This code is used to make sure there are never more than one of this
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        noneButton = GameObject.Find("NoneButton").GetComponent<Image>();
        noneText = GameObject.Find("NoneButton").GetComponentInChildren<TMP_Text>();

        sunButton = GameObject.Find("SunButton").GetComponent<Image>();
        sunText = GameObject.Find("SunButton").GetComponentInChildren<TMP_Text>();

        mercuryButton = GameObject.Find("MercuryButton").GetComponent<Image>();
        mercuryText = GameObject.Find("MercuryButton").GetComponentInChildren<TMP_Text>();

        venusButton = GameObject.Find("VenusButton").GetComponent<Image>();
        venusText = GameObject.Find("VenusButton").GetComponentInChildren<TMP_Text>();

        earthButton = GameObject.Find("EarthButton").GetComponent<Image>();
        earthText = GameObject.Find("EarthButton").GetComponentInChildren<TMP_Text>();

        marsButton = GameObject.Find("MarsButton").GetComponent<Image>();
        marsText = GameObject.Find("MarsButton").GetComponentInChildren<TMP_Text>();

        jupiterButton = GameObject.Find("JupiterButton").GetComponent<Image>();
        jupiterText = GameObject.Find("JupiterButton").GetComponentInChildren<TMP_Text>();

        saturnButton = GameObject.Find("SaturnButton").GetComponent<Image>();
        saturnText = GameObject.Find("SaturnButton").GetComponentInChildren<TMP_Text>();

        uranusButton = GameObject.Find("UranusButton").GetComponent<Image>();
        uranusText = GameObject.Find("UranusButton").GetComponentInChildren<TMP_Text>();

        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();

        player = GameObject.Find("Player").GetComponent<Movement>();
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "TutorialScene")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Death scene")
        {
            Destroy(this.gameObject);
        }

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
        player.enabled = true;
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
        player.enabled = true;
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
        player.enabled = true;
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
        player.enabled = true;
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
        player.enabled = true;
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
        player.enabled = true;
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
        player.enabled = true;
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
        player.enabled = true;
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
        player.enabled = true;
    }
}
