using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 5f;

    private void Start()
    {
        target = GameObject.Find("Player");
    }

    void LateUpdate()
    {
        if (target != null)
        {
            //Vector3 desiredPosition = target.position + offset;
            //transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.LookAt(target.transform.position);
        }
    }
}
