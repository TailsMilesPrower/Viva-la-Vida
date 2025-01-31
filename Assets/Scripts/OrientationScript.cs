using UnityEngine;

public class OrientationScript : MonoBehaviour
{
    private GameObject cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation.y = cam.transform.rotation.eulerAngles;
    }
}
