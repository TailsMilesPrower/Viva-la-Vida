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
    public bool basementDoor;
    public bool kingsDoor;

    private bool inDialouge;

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
        if(hallwayDoor)
        {
            if (gameManager.hallwayUnlocked)
            {
                doorScript.enabled = true;
                this.enabled = false;
            }
        }
        else if (tunnelDoor)
        {
            if(gameManager.tunnelUnlocked)
            {
                doorScript.enabled = true;
                this.enabled = false;
            }
        }
        else if(servantsDoor)
        {
            if(gameManager.servantsUnlocked)
            {
                doorScript.enabled = true;
                this.enabled = false;
            }
        }
        else if(basementDoor)
        {
            if(gameManager.basementUnlocked)
            {
                doorScript.enabled = true;
                this.enabled = false;
            }
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
                            gameManager.hallwayUnlocked = true;
                            UnlockDoor();
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
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "The door is locked. An orange citrine gemstone is engraved into the door.";
                        }
                    }
                }
                else if(tunnelDoor)
                {
                    if (gameManager.tunnelKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.tunnelUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You unlocked the secret tunnel.";
                        }
                    }
                    else
                    {
                        if (inDialouge)
                        {
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "A small door is hidden behind the small cupboard. It is locked with a horse-shaped lock.";
                        }
                    }
                }
                else if(servantsDoor)
                {
                    if (gameManager.servantsKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.servantsUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You unlocked the servant's quarters.";
                        }
                    }
                    else
                    {
                        if (inDialouge)
                        {
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "The door is locked. The wood is worn out, and it is decorated with a large S emblem.";
                        }
                    }
                }
                else if(basementDoor)
                {
                    if (gameManager.basementKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.basementUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You unlocked the basement.";
                        }
                    }
                    else
                    {
                        if (inDialouge)
                        {
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "The basement door is locked with large, old lock. Whatever key unlocks this must be old and rusty.";
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
            playerInRange = true;
        }
    }

    //Code to check when the player exits the door trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void UnlockDoor()
    {
        player.enabled = true;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        inDialouge = false;
        doorScript.enabled = true;
        doorScript.playerInDoor = true;
        this.enabled = false;
    }

    void CloseDialouge()
    {
        player.enabled = true;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        inDialouge = false;
    }
}
