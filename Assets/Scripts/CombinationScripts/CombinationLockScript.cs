using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CombinationLockScript : MonoBehaviour
{
    public TMP_InputField playerInput;

    private bool playerInRange = false;
    private bool inDialouge = false;
    private bool puzzleSolved = false;

    private Movement player;

    private CameraScript cam;

    public string correctCombination;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GameObject.Find("PlayerInput").GetComponent<TMP_InputField>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        cam = Camera.main.GetComponent<CameraScript>();
        playerInput.gameObject.GetComponent<Image>().enabled = true;
        playerInput.enabled = true;
        foreach(Transform child in playerInput.gameObject.transform)
        {
            child.gameObject.SetActive(true);
        }
        playerInput.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(inDialouge)
                {
                    inDialouge = false;
                    player.enabled = true;
                    cam.enabled = true;
                    playerInput.gameObject.GetComponent<Image>().enabled = false;
                    playerInput.enabled = false;
                    foreach (Transform child in playerInput.gameObject.transform)
                    {
                        child.gameObject.SetActive(false);
                    }
                    playerInput.gameObject.SetActive(true);
                }
                else
                {
                    inDialouge = true;
                    player.enabled = false;
                    cam.enabled = false;
                    playerInput.gameObject.GetComponent<Image>().enabled = true;
                    playerInput.enabled = true;
                    foreach (Transform child in playerInput.gameObject.transform)
                    {
                        child.gameObject.SetActive(true);
                    }
                    playerInput.gameObject.SetActive(true);
                }
            }
        }
        if(inDialouge)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                if(playerInput.text == correctCombination)
                {
                    Debug.Log("Correct combination");
                    player.enabled = true;
                    playerInRange = false;
                    puzzleSolved = true;
                    playerInput.gameObject.SetActive(false);
                    /*playerInput.gameObject.GetComponent<Image>().enabled = false;
                    playerInput.enabled = false;
                    foreach (Transform child in playerInput.gameObject.transform)
                    {
                        child.gameObject.SetActive(false);
                    }*/
                    GetComponent<DoorScript>().enabled = true;
                    GetComponent<DoorScript>().playerInDoor = true;
                    this.enabled = false;
                }
                else
                {
                    Debug.Log("Incorrect combination");
                    playerInput.text = "";
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!puzzleSolved)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!puzzleSolved)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
            }
        }
    }
}
