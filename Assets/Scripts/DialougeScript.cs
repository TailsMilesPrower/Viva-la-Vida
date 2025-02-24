using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialougeScript : MonoBehaviour
{
    public GameObject dialougeBox;
    public TMP_Text dialougeText;
    public string[] dialouge;
    public bool playerInRange = false;
    public int lineNumber;

    public bool outlineEneabled = false;

    private void Start()
    {
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                if(lineNumber < dialouge.Length)
                {
                    NextLine();
                }
                else
                {
                    dialougeBox.GetComponent<RawImage>().enabled = false;
                    dialougeText.enabled = false;
                    lineNumber = 0;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if(outlineEneabled)
            {
                GetComponent<Outline>().enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialougeBox.GetComponent<RawImage>().enabled = false;
            dialougeText.enabled = false;
            if (outlineEneabled)
            {
                GetComponent<Outline>().enabled = false;
            }
            lineNumber--;
        }
    }

    void NextLine()
    {
        dialougeBox.GetComponent<RawImage>().enabled = true;
        dialougeText.enabled = true;
        dialougeText.text = dialouge[lineNumber];
        lineNumber++;
    }
}
