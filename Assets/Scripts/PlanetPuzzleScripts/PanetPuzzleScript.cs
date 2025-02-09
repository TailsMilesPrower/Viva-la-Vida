using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PanetPuzzleScript : MonoBehaviour
{
    public bool hasCorrectPlanet;

    public GameObject correctPlanet;

    public GameObject currentlyEnabledPlanet;

    public GameObject[] planets;

    public bool playerInRange;

    public GameObject dialougeBox;
    public TMP_Text dialougeText;

    public GameObject planetPicker;

    public bool inDialouge;

    public bool puzzleOver = false;

    public Movement player;

    private void Start()
    {
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
        planetPicker = GameObject.Find("PlanetPicker");
        player = GameObject.Find("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentlyEnabledPlanet == correctPlanet)
        {
            hasCorrectPlanet = true;
        }
        else
        {
            hasCorrectPlanet = false;
        }

        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(!inDialouge)
                {
                    player.enabled = false;
                    if (currentlyEnabledPlanet == null)
                    {
                        dialougeText.text = "Which planet do you want to place here?";
                        planetPicker.GetComponent<PlanetPickerScript>().buttonMenuOpen = true;
                    }
                    else
                    {
                        dialougeText.text = "You picked up " + currentlyEnabledPlanet.name;
                        if (currentlyEnabledPlanet.name == "Sun")
                        {
                            planetPicker.GetComponent<PlanetPickerScript>().hasSun = true;
                        }
                        else if(currentlyEnabledPlanet.name == "Mercury")
                        {
                            planetPicker.GetComponent<PlanetPickerScript>().hasMercury = true;
                        }
                        else if (currentlyEnabledPlanet.name == "Venus")
                        {
                            planetPicker.GetComponent<PlanetPickerScript>().hasVenus = true;
                        }
                        else if (currentlyEnabledPlanet.name == "Earth")
                        {
                            planetPicker.GetComponent<PlanetPickerScript>().hasEarth = true;
                        }
                        else if (currentlyEnabledPlanet.name == "Mars")
                        {
                            planetPicker.GetComponent<PlanetPickerScript>().hasMars = true;
                        }
                        else if (currentlyEnabledPlanet.name == "Jupiter")
                        {
                            planetPicker.GetComponent<PlanetPickerScript>().hasJupiter = true;
                        }
                        else if (currentlyEnabledPlanet.name == "Saturn")
                        {
                            planetPicker.GetComponent<PlanetPickerScript>().hasSaturn = true;
                        }
                        else if (currentlyEnabledPlanet.name == "Uranus")
                        {
                            planetPicker.GetComponent<PlanetPickerScript>().hasUranus = true;
                        }
                        else
                        {
                            Debug.Log("Error: You are not supposed to see this. If you encounter this, alert the developer");
                            dialougeText.text = "Error: You are not supposed to see this. If you encounter this, alert the developer";
                        }
                        currentlyEnabledPlanet.SetActive(false);
                        currentlyEnabledPlanet = null;
                    }

                    dialougeBox.GetComponent<RawImage>().enabled = true;
                    dialougeText.enabled = true;
                    inDialouge = true;
                }
                else
                {
                    player.enabled = true;
                    dialougeBox.GetComponent<RawImage>().enabled = false;
                    dialougeText.enabled = false;
                    inDialouge = false;
                    planetPicker.GetComponent<PlanetPickerScript>().buttonMenuOpen = false;
                }
            }
            if(GetComponent<Outline>() == enabled)
            {
                GetComponent<Outline>().enabled = true;
            }
        }
        else
        {
            if(GetComponent<Outline>() == enabled)
            {
                GetComponent<Outline>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!puzzleOver)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
                planetPicker.GetComponent<PlanetPickerScript>().currentStand = this.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(!puzzleOver)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
                planetPicker.GetComponent<PlanetPickerScript>().currentStand = null;
            }
        }
    }
}
