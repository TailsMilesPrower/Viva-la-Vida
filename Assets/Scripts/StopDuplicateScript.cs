using UnityEngine;

public class StopDuplicateScript : MonoBehaviour
{
    public GameObject gameManager;

    public bool isCanvas;
    public bool isEventSystem;

    private void Awake()
    {
        if(gameManager == null)
        {
            gameManager = GameObject.Find("GameManager");
        }
        if(isCanvas) 
        {
            if (gameManager.GetComponent<GameManager>().canvas == null)
            {
                gameManager.GetComponent<GameManager>().canvas = this.gameObject;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if(isEventSystem)
        {
            if (gameManager.GetComponent<GameManager>().eventSystem == null)
            {
                gameManager.GetComponent<GameManager>().eventSystem = this.gameObject;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
