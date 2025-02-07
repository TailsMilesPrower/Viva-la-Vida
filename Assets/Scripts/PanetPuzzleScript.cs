using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PanetPuzzleScript : MonoBehaviour
{
    public bool hasCorrectPlanet;

    public GameObject correctPlanet;

    public GameObject currentlyEnabledPlanet;

    public GameObject[] planets;

    private bool playerInRange;

    public GameObject dialougeBox;
    public TMP_Text dialougeText;

    public GameObject planetPicker;

    public bool inDialouge;

    private void Start()
    {
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
        planetPicker = GameObject.Find("PlanetPicker");
    }

    // Update is called once per frame
    void Update()
    {
        if(correctPlanet == isActiveAndEnabled)
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
                        currentlyEnabledPlanet.SetActive(false);
                        currentlyEnabledPlanet = null;
                    }

                    Debug.Log("Testing");
                    dialougeBox.GetComponent<RawImage>().enabled = true;
                    dialougeText.enabled = true;
                    inDialouge = true;
                }
                else
                {
                    dialougeBox.GetComponent<RawImage>().enabled = false;
                    dialougeText.enabled = false;
                    inDialouge = false;
                    planetPicker.GetComponent<PlanetPickerScript>().buttonMenuOpen = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
            planetPicker.GetComponent<PlanetPickerScript>().currentStand = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
        planetPicker.GetComponent<PlanetPickerScript>().currentStand = null;
    }
}
