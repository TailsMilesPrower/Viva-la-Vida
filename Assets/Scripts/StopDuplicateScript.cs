using UnityEngine;

public class StopDuplicateScript : MonoBehaviour
{
    private static StopDuplicateScript instance;

    //A refrence to the game manager
    public GameObject gameManager;

    private void Awake()
    {
        //This code is used to make sure there are never more than one camera
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
