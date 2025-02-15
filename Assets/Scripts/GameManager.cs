using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //This is something used to make sure there is never more than one game manager
    private static GameManager instance;

    //Object refrences
    public GameObject player;
    public GameObject canvas;
    public GameObject playerCamera;

    //The number used to spawn the player in the correct location when entering a room
    public int entryNumber;

    //Objects in the rooms
    public Vector3 objectOnePosition;
    public Vector3 objectTwoPosition;

    //Enemies in the room
    public bool enemyOneDead = false;
    public bool enemyTwoDead = false;
    public bool enemyThreeDead = false;

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

    public bool hallwayUnlocked;

    private void Awake()
    {
        //This code is used to make sure there are never more than one game manager
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "TutorialScene")
        {
            Destroy(this.gameObject);
        }
    }
}
