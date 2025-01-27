using UnityEngine;

public class RoomEntryCheck : MonoBehaviour
{
    public Transform[] entryPoints;
    public GameObject player;
    public GameObject gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
        int entryNum = gameManager.GetComponent<GameManager>().entryNumber;
        player.transform.position = entryPoints[entryNum].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
