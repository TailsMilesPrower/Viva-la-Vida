using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntryCheck : MonoBehaviour
{
    //An array of all the entry points the room has
    public Transform[] entryPoints;

    //A refrence to the player
    public GameObject player;
    //A refrence to the game manager
    public GameObject gameManager;
    //A refrence to the player camera
    public GameObject playerCamera;

    //Objects
    public Transform objectOne;
    public Transform objectTwo;

    //Object bools
    public bool isObjectOne;
    public bool isObjectTwo;

    //Enemies
    public GameObject enemyOne;
    public GameObject enemyTwo;
    public GameObject enemyThree;

    //Enemy bools
    public bool isEnemyOne;
    public bool isEnemyTwo;
    public bool isEnemyThree;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Assigns the player,game manager, and camera
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
        playerCamera = GameObject.Find("Main Camera");

        StartCoroutine(MovePlayer());

        //Sets the object positions
        if(isObjectOne)
        {
            objectOne.position = gameManager.GetComponent<GameManager>().objectOnePosition;
        }
        if(isObjectTwo)
        {
            objectTwo.position = gameManager.GetComponent<GameManager>().objectTwoPosition;
        }

        //Sets the status of the enemies
        if(isEnemyOne)
        {
            if(gameManager.GetComponent<GameManager>().enemyOneDead == true)
            {
                Destroy(enemyOne);
            }
        }
        if (isEnemyTwo)
        {
            if (gameManager.GetComponent<GameManager>().enemyTwoDead == true)
            {
                Destroy(enemyTwo);
            }
        }
        if (isEnemyThree)
        {
            if (gameManager.GetComponent<GameManager>().enemyThreeDead == true)
            {
                Destroy(enemyThree);
            }
        }
        
    }

    public void SaveObjectPositions()
    {
        if(isObjectOne)
        {
            gameManager.GetComponent<GameManager>().objectOnePosition = objectOne.position;
        }
        if(isObjectTwo)
        {
            gameManager.GetComponent<GameManager>().objectTwoPosition = objectTwo.position;
        }
    }

    IEnumerator MovePlayer()
    {
        //Gets the entry number in the game manager (assigned from the door in the previous scene
        int entryNum = gameManager.GetComponent<GameManager>().entryNumber;

        Rigidbody rb = player.gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        //Calculates the offset between the player and the camera
        Vector3 playerPos = player.transform.position;
        Vector3 cameraOffset = playerCamera.transform.position - playerPos;

        //Sets the player's position to the entry point
        player.transform.position = entryPoints[entryNum].position;
        player.transform.rotation = entryPoints[entryNum].rotation;


        //Sets the camera position
        playerCamera.transform.position = player.transform.position + cameraOffset;

        yield return new WaitForSeconds(0.1f);

        rb.isKinematic = false;
    }
}
