using UnityEngine;

public class StatueMoving : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private float timeDelay = 2f;

    private PointControll currentpoint;
    private float waitForTriggerUpdate;

    private void Awake() {
        waitForTriggerUpdate = Time.realtimeSinceStartup + timeDelay;
        Collider[] spawnCollider = Physics.OverlapBox(transform.position, transform.forward);
        if (spawnCollider == null) {
            return;
        }
        foreach (Collider c in spawnCollider) {
            if (c.TryGetComponent(out PointControll pointControll)) {
                currentpoint = pointControll;
                currentpoint.IsOccupied = true;
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (waitForTriggerUpdate > Time.realtimeSinceStartup) {
            return ;
        }

        Ray ray = new Ray(this.transform.position, player.transform.rotation * Vector3.forward);
            
        float maxAngle = 80f;
        Transform transformPoint = null;
        foreach (var gameObject in currentpoint.neigbours) {
            float angle = Vector3.Angle(ray.direction, gameObject.transform.position - this.transform.position);
           if (angle < maxAngle) {
                maxAngle = angle;
                if (gameObject.GetComponent<PointControll>().IsOccupied == false) {
                    transformPoint = gameObject.transform;
                }
           } 
        }
        if (transformPoint != null) {
            currentpoint.IsOccupied = false;
            //transform.position = new Vector3(transformPoint.position.x, this.transform.position.y, transformPoint.position.z);
            currentpoint = transformPoint.gameObject.GetComponent<PointControll>() ;
            currentpoint.IsOccupied = true;
        }
        waitForTriggerUpdate = Time.realtimeSinceStartup + timeDelay;
    }

    private void FixedUpdate() {
        if (transform.position != currentpoint.transform.position) {
            transform.position = Vector3.Lerp(transform.position, currentpoint.transform.position, Time.deltaTime * 4f);
        }
    }
}
