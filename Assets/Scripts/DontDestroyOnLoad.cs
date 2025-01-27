using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    //This is just a DontDestroyOnLoad script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
