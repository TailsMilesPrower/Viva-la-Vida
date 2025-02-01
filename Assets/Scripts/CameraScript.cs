using Unity.Cinemachine;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    public float smoothSpeed = 5f;

    public Vector3 offset;

    public float cameraZOffsetMin = -5.58f;
    public float cameraZOffsetMax = -8.25f;

    public Vector3 minCamPosition;
    public Vector3 maxCamPosition;

    private void Update()
    {
        if(Input.GetKey(KeyCode.S))
        {
            if(offset.z > cameraZOffsetMax)
            {
                offset.z -= 2f * Time.deltaTime;
            }
        }
        else if(Input.GetKey(KeyCode.W))
        {
            if (offset.z < cameraZOffsetMin)
            {
                offset.z += 2f * Time.deltaTime;
            }
        }
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = player.transform.position + offset;

        Vector3 clampedPosition = new Vector3(Mathf.Clamp(desiredPosition.x, minCamPosition.x, maxCamPosition.x), Mathf.Clamp(desiredPosition.y, minCamPosition.y, maxCamPosition.y), Mathf.Clamp(desiredPosition.z, minCamPosition.z, maxCamPosition.z));

        Vector3 smoothPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothPosition;
    }

    /*public float cameraMaximumZPosition;

    private float cameraOffsetValueMinimum;
    private float cameraOffsetValueMaximum;

    private void Update()
    {
        if(transform.position.z >= cameraMaximumZPosition)
        {
            cameraOffsetValueMinimum = -5.8f;
            cameraOffsetValueMaximum = -8.25f;

            if (Input.GetKey(KeyCode.S))
            {
                if (GetComponent<CinemachineFollow>().FollowOffset.z > cameraOffsetValueMaximum)
                {
                    GetComponent<CinemachineFollow>().FollowOffset.z -= 2f * Time.deltaTime;
                }
            }
            else if (Input.GetKey(KeyCode.W))
            {
                if (GetComponent<CinemachineFollow>().FollowOffset.z < cameraOffsetValueMinimum)
                {
                    GetComponent<CinemachineFollow>().FollowOffset.z += 2f * Time.deltaTime;
                }
            }
        }
        else
        {
            cameraOffsetValueMinimum = -4.96f;
            cameraOffsetValueMaximum = -8.25f;

            if (Input.GetKey(KeyCode.S))
            {
                if (GetComponent<CinemachineFollow>().FollowOffset.z < cameraOffsetValueMinimum)
                {
                    GetComponent<CinemachineFollow>().FollowOffset.z += 4f * Time.deltaTime;
                }
            }
            else if (Input.GetKey(KeyCode.W))
            {
                if (GetComponent<CinemachineFollow>().FollowOffset.z < cameraOffsetValueMinimum)
                {
                    GetComponent<CinemachineFollow>().FollowOffset.z += 2f * Time.deltaTime;
                }
            }
        }
    }*/
}
