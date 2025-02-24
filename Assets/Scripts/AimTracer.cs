using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;

public class AimTracer : MonoBehaviour
{
    [Header("References)")]
    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private GameObject player;

    private bool aiming = false;
    private Vector3 aimPosition;

    void Update() {
        // Detect right mouse button hold
        if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.Joystick1Button6))
        {
            aiming = true;
        }
        else
        {
            aiming = false;
        }

        // Create a ray from the player's position in the forward direction
        Ray ray = new Ray(player.transform.position, player.transform.forward);

        // Perform raycast
        if (Physics.Raycast(ray, out RaycastHit hitData)) {
            // Save the exact hit position
            aimPosition = hitData.point;
        }
        else {
            // If nothing is hit, extend forward indefinitely
            aimPosition = player.transform.position + player.transform.forward * 100f;
        }

        // If aiming, update the line renderer
        if (aiming) {
            lineRenderer.enabled = true; // Make sure the LineRenderer is enabled
            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, aimPosition);
        }
        else {
            lineRenderer.enabled = false; // Disable it instead of setting to null
        }
    }
}
