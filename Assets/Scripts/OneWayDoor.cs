using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OneWayDoor : MonoBehaviour
{
    public bool correctWay;

    private DoorScript doorScript;
    private GameManager gameManager;
    public Movement player;

    public GameObject dialougeBox;
    public TMP_Text dialougeText;
    public bool playerInRange = false;

    public bool kitchenDoor;
    public bool statueDoor;
    public bool diningDoor;

    private bool inDialouge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        doorScript = this.GetComponent<DoorScript>();
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();

        if(kitchenDoor)
        {
            if(gameManager.kitchenUnlocked)
            {
                doorScript.enabled = true;
                this.enabled = false;
            }
        }
        else if (statueDoor)
        {
            if (gameManager.statueRoomUnlocked)
            {
                doorScript.enabled = true;
                this.enabled = false;
            }
        }
        else if (diningDoor)
        {
            if (gameManager.diningUnlocked)
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
                if(kitchenDoor)
                {
                    if(correctWay)
                    {
                        if (inDialouge)
                        {
                            gameManager.kitchenUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You unlocked the door. You should be able to come through on the other side now.";
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
                            dialougeText.text = "The door is locked from the other side.";
                        }
                    }
                }
                else if (statueDoor)
                {
                    if (correctWay)
                    {
                        if (inDialouge)
                        {
                            gameManager.statueRoomUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You unlocked the door. You should be able to come through on the other side now.";
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
                            dialougeText.text = "The door is locked from the other side.";
                        }
                    }
                }
                else if (diningDoor)
                {
                    if (correctWay)
                    {
                        if (inDialouge)
                        {
                            gameManager.diningUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You unlocked the door. You should be able to come through on the other side now.";
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
                            dialougeText.text = "The door is locked from the other side.";
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
