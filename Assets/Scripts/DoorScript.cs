using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public int doorNumber;

    public string sceneName;

    public GameObject gameManager;

    private bool playerInDoor = false;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    private void Update()
    {
        if(playerInDoor)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                gameManager.GetComponent<GameManager>().entryNumber = doorNumber;
                OpenDoor();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player in door");

        if (other.CompareTag("Player"))
        {
            playerInDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player exiting door");

        if (other.CompareTag("Player"))
        {
            playerInDoor = false;
        }
    }

    public void OpenDoor()
    {
        Debug.Log("Loading next scene");
        SceneManager.LoadScene(sceneName);
    }
}
