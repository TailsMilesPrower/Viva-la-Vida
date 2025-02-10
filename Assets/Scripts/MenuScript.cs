using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void LoadMenu()
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
}
