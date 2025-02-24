using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockItem : MonoBehaviour
{
    public bool swordNeeded;
    public bool bookNeeded;
    public bool clothNeeded;

    private GameManager gameManager;
    public Movement player;

    public GameObject dialougeBox;
    public TMP_Text dialougeText;
    public bool playerInRange = false;

    private bool inDialouge;

    public GameObject placedObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
        if(swordNeeded)
        {
            if(gameManager.swordPlaced)
            {
                placedObject.SetActive(true);
                this.enabled = false;
            }
        }
        else if(bookNeeded)
        {
            if(gameManager.bookPlaced)
            {
                placedObject.SetActive(true);
                this.enabled = false;
            }
        }
        else if(clothNeeded)
        {
            if(gameManager.toiletClogged)
            {
                placedObject.SetActive(true);
                this.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                player.enabled = false;
                dialougeBox.GetComponent<RawImage>().enabled = true;
                dialougeText.enabled = true;
                if(swordNeeded)
                {
                    if(gameManager.sword)
                    {
                        if(inDialouge)
                        {
                            gameManager.swordPlaced = true;
                            PlaceItem();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You place the sword in cross with the other. A small click can be heard and something rises up from the table.";
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
                            dialougeText.text = "On the wall is a shield and a sword. It looks odd, like it's missing another sword.";
                        }
                    }
                }
                else if(clothNeeded)
                {
                    if (gameManager.clothPile)
                    {
                        if (inDialouge)
                        {
                            gameManager.toiletClogged = true;
                            PlaceItem();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You place the pile of cloth into the toilet and flush. You hear the pipes rattle, and something bursts upstairs above you.";
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
                            dialougeText.text = "A small toilet. It looks old and ill taken care of. Maybe you could throw something in there?";
                        }
                    }
                }
                else if(bookNeeded)
                {
                    if (gameManager.book)
                    {
                        if (inDialouge)
                        {
                            gameManager.bookPlaced = true;
                            GetComponent<DoorScript>().enabled = true;
                            PlaceItem();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You place the book into the correct spot and push it in. A small click can be heard, and the bookshelf pushes open.";
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
                            dialougeText.text = "It's a small bookcase with a variety of books. One book is missing though, and in the wall behind is a small slot, looks like a keyhole. Maybe you can find the book somewhere?";
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

    private void PlaceItem()
    {
        player.enabled = true;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        inDialouge = false;
        placedObject.SetActive(true);
        this.enabled = false;
    }

    private void CloseDialouge()
    {
        player.enabled = true;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        inDialouge = false;
    }
}
