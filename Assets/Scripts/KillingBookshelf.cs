using UnityEngine;

public class KillingBookshelf : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 targetPosition;
    private bool isPlayerNearby = false;
    private bool wasTriggered = false;
    private Collider bookshelfCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
        bookshelfCollider = GetComponent<Collider>();
        bookshelfCollider.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    private void Update()
    {
        if (isPlayerNearby && !wasTriggered && Input.GetKeyDown(KeyCode.E) || isPlayerNearby && !wasTriggered && Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            wasTriggered = true;
            ActivateBookshelf();
        }
    }

    void ActivateBookshelf()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        //bookshelfCollider.isTrigger = false;
        float forceMagnitude = 5f;
        Vector3 directionToTarget = (targetPosition - transform.position).normalized;

        Vector3 forceToApply = directionToTarget * forceMagnitude;
        rb.AddForce(forceToApply, ForceMode.Impulse);

    }

}
