using UnityEngine;

public class RoomEntryCheck : MonoBehaviour
{
    //An array of all the entry points the room has
    public Transform[] entryPoints;

    //A refrence to the player
    public GameObject player;
    //A refrence to the game manager
    public GameObject gameManager;

    //Objects
    public Transform objectOne;
    public Transform objectTwo;

    //Object bools
    public bool isObjectOne;
    public bool isObjectTwo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Assigns the player and game manager
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
        //Gets the entry number in the game manager (assigned from the door in the previous scene
        int entryNum = gameManager.GetComponent<GameManager>().entryNumber;
        //Sets the player's position to the entry point
        player.transform.position = entryPoints[entryNum].transform.position;
        player.transform.rotation = entryPoints[entryNum].transform.rotation;
        if(isObjectOne)
        {
            objectOne.position = gameManager.GetComponent<GameManager>().objectOnePosition;
        }
        if(isObjectTwo)
        {
            objectTwo.position = gameManager.GetComponent<GameManager>().objectTwoPosition;
        }
    }

    public void SaveObjectPositions()
    {
        if(isObjectOne)
        {
            gameManager.GetComponent<GameManager>().objectOnePosition = objectOne.position;
        }
        if(isObjectTwo)
        {
            gameManager.GetComponent<GameManager>().objectTwoPosition = objectTwo.position;
        }
    }
}
