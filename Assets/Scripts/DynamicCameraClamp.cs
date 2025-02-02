using UnityEngine;

public class DynamicCameraClamp : MonoBehaviour
{
    public Vector3 cameraClampMin;
    public Vector3 cameraClampMax;

    private GameObject playerCamera;

    private void Start()
    {
        playerCamera = GameObject.Find("Main Camera");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerCamera.GetComponent<CameraScript>().minCamPosition = cameraClampMin;
            playerCamera.GetComponent<CameraScript>().maxCamPosition = cameraClampMax;
        }
    }
}
