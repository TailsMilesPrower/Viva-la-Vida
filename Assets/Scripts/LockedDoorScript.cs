using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoorScript : MonoBehaviour
{
    private DoorScript doorScript;
    private GameManager gameManager;
    public Movement player;

    public GameObject roomCheck;

    public GameObject dialougeBox;
    public TMP_Text dialougeText;
    public bool playerInRange = false;

    public bool hallwayDoor;
    public bool servantsDoor;
    public bool planeteriumDoor;
    public bool secondFloorDoor;
    public bool meetingDoor;
    public bool libraryDoor;
    public bool tunnelDoor;

    public bool coinDoor;
    public bool basementKey;
    public bool kingsDoor;

    private bool inDialouge;
    public bool puzzleSolved;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Assigning the game manager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        roomCheck = GameObject.Find("RoomEntryCheck");
        player = GameObject.Find("Player").GetComponent<Movement>();
        doorScript = this.GetComponent<DoorScript>();
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
        if(gameManager.hallwayUnlocked)
        {
            puzzleSolved = true;
            doorScript.enabled = true;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                player.enabled = false;
                dialougeBox.GetComponent<RawImage>().enabled = true;
                dialougeText.enabled = true;
                if (hallwayDoor)
                {
                    if (gameManager.hallwayKey)
                    {
                        if(inDialouge)
                        {
                            player.enabled = true;
                            dialougeBox.GetComponent<RawImage>().enabled = false;
                            dialougeText.enabled = false;
                            inDialouge = false;
                            doorScript.enabled = true;
                            doorScript.playerInDoor = true;
                            GetComponent<Outline>().enabled = false;
                            puzzleSolved = true;
                            gameManager.hallwayUnlocked = true;
                            this.enabled = false;
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You unlocked the hallway door.";
                        }
                    }
                    else
                    {
                        if(inDialouge)
                        {
                            player.enabled = true;
                            dialougeBox.GetComponent<RawImage>().enabled = false;
                            dialougeText.enabled = false;
                            inDialouge = false;
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "The door is locked. An orange citrine gemstone is engraved into the door.";
                        }
                    }
                }
            }
        }
    }

    //Code to check when the player enters the door trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!puzzleSolved)
            {
                GetComponent<Outline>().enabled = true;
            }
            playerInRange = true;
        }
    }

    //Code to check when the player exits the door trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!puzzleSolved)
            {
                GetComponent<Outline>().enabled = false;
            }
            playerInRange = false;
        }
    }
}
