using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void LoadFreeroam()
    {
        SceneManager.LoadScene("Room1_1");
    }

    public void LoadPlanet()
    {
        SceneManager.LoadScene("SolarSystemTest");
    }

    public void LoadCombination()
    {
        SceneManager.LoadScene("CombinationPuzzle");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
