using UnityEngine;

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

    public GameObject sunButton;
    /*public GameObject mercuryButton;
    public GameObject venusButton;
    public GameObject earthButton;
    public GameObject marsButton;
    public GameObject jupiterButton;
    public GameObject saturnButton;
    public GameObject uranusButton;*/

    public bool buttonMenuOpen;

    public GameObject currentStand;

    private void Update()
    {
        if(buttonMenuOpen)
        {
            if(hasSun)
            {
                sunButton.SetActive(true);
            }
            else
            {
                sunButton.SetActive(false);
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
    }

    public void PlaceSun()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[0].SetActive(true);
    }
}
