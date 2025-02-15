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
        if(gameManager.hallwayKey)
        {
            Destroy(gameObject);
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
                        player.enabled = true;
                        dialougeBox.GetComponent<RawImage>().enabled = false;
                        dialougeText.enabled = false;
                        inDialouge = false;
                        gameManager.hallwayKey = true;
                        Destroy(gameObject);
                    }
                    else
                    {
                        inDialouge = true;
                        dialougeText.text = "You picked up a key with an orange citrine gemstone as its head.";
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
}
