using UnityEngine;
using TMPro;

public class Consumables : MonoBehaviour
{
    private GameManager gameManager;
    public Movement player;

    public GameObject roomCheck;

    public GameObject dialougeBox;
    public TMP_Text dialougeText;
    public bool playerInRange = false;

    [SerializeField]
    private float healAmount = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.GetComponent<Movement>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ApplyHealing();
            Destroy(gameObject);
        }
    }

    private void ApplyHealing()
    {
        if (player != null)
        {
            player.ChangeHealth(healAmount);
        }
    }

}
