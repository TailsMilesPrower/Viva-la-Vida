using Unity.Cinemachine;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float cameraOffsetValue = -5.8f;

    private float cameraOffsetValueMinimum = -5.8f;
    private float cameraOffsetValueMaximum = -8.25f;

    private void Update()
    {
        GetComponent<CinemachineFollow>().FollowOffset.z = cameraOffsetValue;

        if (Input.GetKey(KeyCode.S))
        {
            if (cameraOffsetValue > cameraOffsetValueMaximum)
            {
                cameraOffsetValue -= 2f * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (cameraOffsetValue < cameraOffsetValueMinimum)
            {
                cameraOffsetValue += 2f * Time.deltaTime;
            }
        }
    }
}
