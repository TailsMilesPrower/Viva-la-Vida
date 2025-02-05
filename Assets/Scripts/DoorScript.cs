using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    //The number of the door. Used to determine where the player will spawn in the next scene
    public int doorNumber;

    //A string used to load the correct scene when the door is opened
    public string sceneName;

    //A refrence to the game manager
    public GameManager gameManager;

    //A bool to help check if the player is by the door
    private bool playerInDoor = false;

    public GameObject roomCheck;

    public CanvasGroup fadeScreen;

    private bool fadeIn = false;

    public float timeToFade;

    public GameObject player;

    private void Start()
    {
        //Assigning the game manager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        roomCheck = GameObject.Find("RoomEntryCheck");
        fadeScreen = GameObject.Find("FadeScreen").GetComponent<CanvasGroup>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        //If the player is by the door and press E
        if(playerInDoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //The door accesses the game manager and assigns its entry number as the same as the door number
                gameManager.entryNumber = doorNumber;
                //Then, it calls the function that loads the next scene
                StartCoroutine(OpenDoor());
            }
        }
        if (fadeIn)
        {
            if (fadeScreen.alpha < 1)
            {
                fadeScreen.alpha += timeToFade * Time.deltaTime;
                if (fadeScreen.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
    }

    //Code to check when the player enters the door trigger
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player in door");

        if (other.CompareTag("Player"))
        {
            playerInDoor = true;
        }
    }

    //Code to check when the player exits the door trigger
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player exiting door");

        if (other.CompareTag("Player"))
        {
            playerInDoor = false;
        }
    }

    //A function that loads the next scene
    public IEnumerator OpenDoor()
    {
        roomCheck.GetComponent<RoomEntryCheck>().SaveObjectPositions();
        Debug.Log("Loading next scene");
        player.GetComponent<Movement>().enabled = false;
        fadeIn = true; 
        player.GetComponent<Movement>().enabled = false;
        yield return new WaitForSeconds(timeToFade + 0.2f);
        SceneManager.LoadScene(sceneName);
    }
}
