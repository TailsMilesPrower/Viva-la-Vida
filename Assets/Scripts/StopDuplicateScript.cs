using UnityEngine;

public class StopDuplicateScript : MonoBehaviour
{
    //A refrence to the game manager
    public GameObject gameManager;


    private void Awake()
    {
        //Assigns the game manager
        if(gameManager == null)
        {
            gameManager = GameObject.Find("GameManager");
        }
        //Makes sure there is never more than one canvas in the scene
        if (gameManager.GetComponent<GameManager>().canvas == null)
        {
            gameManager.GetComponent<GameManager>().canvas = this.gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
