using UnityEngine;

public class EntryPointCameraClamp : MonoBehaviour
{
    public Vector3 cameraClampMin;
    public Vector3 cameraClampMax;

    private GameObject playerCamera;

    public void AssignClamp()
    {
        playerCamera = GameObject.Find("Main Camera");

        playerCamera.GetComponent<CameraScript>().minCamPosition = cameraClampMin;
        playerCamera.GetComponent<CameraScript>().maxCamPosition = cameraClampMax;
    }
}
