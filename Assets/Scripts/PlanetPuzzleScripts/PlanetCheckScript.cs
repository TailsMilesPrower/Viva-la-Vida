using UnityEngine;

public class PlanetCheckScript : MonoBehaviour
{
    public bool planetsInOrder;

    public GameObject[] stands;

    // Update is called once per frame
    void Update()
    {
        if (stands[0].GetComponent<PanetPuzzleScript>().hasCorrectPlanet && stands[1].GetComponent<PanetPuzzleScript>().hasCorrectPlanet && stands[2].GetComponent<PanetPuzzleScript>().hasCorrectPlanet && stands[3].GetComponent<PanetPuzzleScript>().hasCorrectPlanet && stands[4].GetComponent<PanetPuzzleScript>().hasCorrectPlanet && stands[5].GetComponent<PanetPuzzleScript>().hasCorrectPlanet && stands[6].GetComponent<PanetPuzzleScript>().hasCorrectPlanet && stands[7].GetComponent<PanetPuzzleScript>().hasCorrectPlanet)
        {
            planetsInOrder = true;
            for(int i = 0; i < stands.Length; i++)
            {
                var currentStand = stands[i].GetComponent<PanetPuzzleScript>();
                currentStand.puzzleOver = true;
                currentStand.playerInRange = false;
            }
        }
        if(planetsInOrder)
        {
            if(GetComponent<Renderer>().material.color != Color.green)
            {
                GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
}
