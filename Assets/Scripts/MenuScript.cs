using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("Room1");
    }
}
