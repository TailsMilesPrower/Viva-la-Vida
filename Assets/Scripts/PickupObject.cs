using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour
{
    private GameManager gameManager;
    public Movement player;

    public GameObject roomCheck;

    public GameObject dialougeBox;
    public TMP_Text dialougeText;
    public bool playerInRange = false;

    public bool coinOne;
    public bool coinTwo;
    public bool coinThree;

    public bool sword;
    public bool clothPile;
    public bool book;

    public bool toiletClogged;

    public bool hallwayKey;
    public bool planetariumKey;
    public bool meetingKey;
    public bool secondFloorKey;
    public bool servantsKey;
    public bool tunnelKey;

    public bool basementKey;
    public bool kingsKeyOne;
    public bool kingsKeyTwo;

    private bool inDialouge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        roomCheck = GameObject.Find("RoomEntryCheck");
        player = GameObject.Find("Player").GetComponent<Movement>();
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
        if(hallwayKey)
        {
            if (gameManager.hallwayKey)
            {
                Destroy(gameObject);
            }
        }
        else if(tunnelKey)
        {
            if (gameManager.tunnelKey)
            {
                Destroy(gameObject);
            }
        }
        else if(servantsKey)
        {
            if (gameManager.servantsKey)
            {
                Destroy(gameObject);
            }
        }
        else if (basementKey)
        {
            if (gameManager.basementKey)
            {
                Destroy(gameObject);
            }
        }
        else if(secondFloorKey)
        {
            if (gameManager.secondFloorKey)
            {
                Destroy(gameObject);
            }
        }
        else if(planetariumKey)
        {
            if (gameManager.planetariumKey)
            {
                Destroy(gameObject);
            }
        }
        else if(meetingKey)
        {
            if (gameManager.meetingKey)
            {
                Destroy(gameObject);
            }
        }
        else if(coinOne)
        {
            if (gameManager.coinOne)
            {
                Destroy(gameObject);
            }
        }
        else if(coinTwo)
        {
            if (gameManager.coinTwo)
            {
                Destroy(gameObject);
            }
        }
        else if(coinThree)
        {
            if (gameManager.coinThree)
            {
                Destroy(gameObject);
            }
        }
        else if(kingsKeyOne)
        {
            if (gameManager.kingsKeyOne)
            {
                Destroy(gameObject);
            }
        }
        else if (kingsKeyTwo)
        {
            if (gameManager.kingsKeyTwo)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.enabled = false;
                dialougeBox.GetComponent<RawImage>().enabled = true;
                dialougeText.enabled = true;
                if(hallwayKey)
                {
                    if(inDialouge)
                    {
                        gameManager.hallwayKey = true;
                        CLoseDialouge();
                        Destroy(gameObject);
                    }
                    else
                    {
                        inDialouge = true;
                        dialougeText.text = "You pick up a key with an orange citrine gemstone as its head.";
                    }
                }
                else if (tunnelKey)
                {
                    if (inDialouge)
                    {
                        gameManager.tunnelKey = true;
                        CLoseDialouge();
                        Destroy(gameObject);
                    }
                    else
                    {
                        inDialouge = true;
                        dialougeText.text = "You pick up a key with a horse emblem as its head.";
                    }
                }
                else if(servantsKey)
                {
                    if (inDialouge)
                    {
                        gameManager.servantsKey = true;
                        CLoseDialouge();
                        Destroy(gameObject);
                    }
                    else
                    {
                        inDialouge = true;
                        dialougeText.text = "You pick up a key with a large S-shaped emblem as its head.";
                    }
                }
                else if(basementKey)
                {
                    if (inDialouge)
                    {
                        gameManager.basementKey = true;
                        CLoseDialouge();
                        Destroy(gameObject);
                    }
                    else
                    {
                        inDialouge = true;
                        dialougeText.text = "You pick up an old and rusty key. Whatever this unlocks, it must be a very old lock.";
                    }
                }
                else if (secondFloorKey)
                {
                    if (inDialouge)
                    {
                        gameManager.secondFloorKey = true;
                        CLoseDialouge();
                        Destroy(gameObject);
                    }
                    else
                    {
                        inDialouge = true;
                        dialougeText.text = "You pick up a small key. The head is engraved with a 2.";
                    }
                }
                else if (planetariumKey)
                {
                    if (inDialouge)
                    {
                        gameManager.planetariumKey = true;
                        CLoseDialouge();
                        Destroy(gameObject);
                    }
                    else
                    {
                        inDialouge = true;
                        dialougeText.text = "You pick up a shiny golden key. The head of it is shaped like the sun.";
                    }
                }
                else if (meetingKey)
                {
                    if (inDialouge)
                    {
                        gameManager.meetingKey = true;
                        CLoseDialouge();
                        Destroy(gameObject);
                    }
                    else
                    {
                        inDialouge = true;
                        dialougeText.text = "You pick up small key. Its head is decorated with small blue saphires.";
                    }
                }
                else if (coinOne)
                {
                    if (inDialouge)
                    {
                        gameManager.coinOne = true;
                        CLoseDialouge();
                        Destroy(gameObject);
                    }
                    else
                    {
                        inDialouge = true;
                        dialougeText.text = "You pick up a large copper coin. Wonder if it can be used somewhere.";
                    }
                }
                else if (coinTwo)
                {
                    if (inDialouge)
                    {
                        gameManager.coinTwo = true;
                        CLoseDialouge();
                        Destroy(gameObject);
                    }
                    else
                    {
                        inDialouge = true;
                        dialougeText.text = "You pick up a large silver coin. Maybe it will be of some use?";
                    }
                }
                else if (coinThree)
                {
                    if (inDialouge)
                    {
                        gameManager.coinThree = true;
                        CLoseDialouge();
                        Destroy(gameObject);
                    }
                    else
                    {
                        inDialouge = true;
                        dialougeText.text = "You pick up a large gold coin. If it's of no use, you can pocket it for yourself.";
                    }
                }
                else if (kingsKeyOne)
                {
                    if (inDialouge)
                    {
                        gameManager.kingsKeyOne = true;
                        CLoseDialouge();
                        Destroy(gameObject);
                    }
                    else
                    {
                        inDialouge = true;
                        dialougeText.text = "You pick up a large blue key. It's head is a replica of the crown of Norway.";
                    }
                }
                else if (kingsKeyTwo)
                {
                    if (inDialouge)
                    {
                        gameManager.kingsKeyTwo = true;
                        CLoseDialouge();
                        Destroy(gameObject);
                    }
                    else
                    {
                        inDialouge = true;
                        dialougeText.text = "You pick up a large red key. It's head is a replica of the crown of Denmark.";
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
            GetComponent<Outline>().enabled = true;
            playerInRange = true;
        }
    }

    //Code to check when the player exits the door trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Outline>().enabled = false;
            playerInRange = false;
        }
    }

    void CLoseDialouge()
    {
        player.enabled = true;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        inDialouge = false;
    }
}
