using UnityEngine;

public class GameManager : MonoBehaviour
{
    //This is something used to make sure there is never more than one game manager
    private static GameManager instance;

    //Object refrences
    public GameObject player;
    public GameObject canvas;

    //The number used to spawn the player in the correct location when entering a room
    public int entryNumber;

    //Objects in the rooms
    public Vector3 objectOnePosition;
    public Vector3 objectTwoPosition;

    //Enemies in the room
    public bool enemyOneDead = false;
    public bool enemyTwoDead = false;
    public bool enemyThreeDead = false;

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
}
