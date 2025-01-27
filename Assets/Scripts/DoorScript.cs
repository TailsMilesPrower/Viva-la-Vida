using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                OpenDoor();
            }
        }
    }

    public void OpenDoor()
    {
        SceneManager.LoadScene(sceneName);
    }
}
