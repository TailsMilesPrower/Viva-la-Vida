using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    //The number of the door. Used to determine where the player will spawn in the next scene
    public int doorNumber;

    //A string used to load the correct scene when the door is opened
    public string sceneName;

    //A refrence to the game manager
    public GameObject gameManager;

    //A bool to help check if the player is by the door
    private bool playerInDoor = false;

    private void Start()
    {
        //Assigning the game manager
        gameManager = GameObject.Find("GameManager");
    }

    private void Update()
    {
        //If the player is by the door and press F
        if(playerInDoor)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //The door accesses the game manager and assigns its entry number as the same as the door number
                gameManager.GetComponent<GameManager>().entryNumber = doorNumber;
                //Then, it calls the function that loads the next scene
                OpenDoor();
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
    public void OpenDoor()
    {
        Debug.Log("Loading next scene");
        SceneManager.LoadScene(sceneName);
    }
}
