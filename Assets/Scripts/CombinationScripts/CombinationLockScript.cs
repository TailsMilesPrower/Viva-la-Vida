using UnityEngine;
using TMPro;

public class CombinationLockScript : MonoBehaviour
{
    public TMP_InputField playerInput;

    private bool playerInRange = false;
    private bool inDialouge = false;
    private bool puzzleSolved = false;

    private Movement player;

    private CameraScript camera;

    public GameObject box;

    public string correctCombination;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GameObject.Find("PlayerInput").GetComponent<TMP_InputField>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        camera = Camera.main.GetComponent<CameraScript>();
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
                    camera.enabled = true;
                    playerInput.gameObject.SetActive(false);
                }
                else
                {
                    inDialouge = true;
                    player.enabled = false;
                    camera.enabled = false;
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
                    box.GetComponent<Renderer>().material.color = Color.green;
                    playerInput.gameObject.SetActive(false);
                    player.enabled = true;
                    playerInRange = false;
                    puzzleSolved = true;

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
