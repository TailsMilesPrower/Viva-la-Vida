using UnityEngine;

public class FallChandeleer : MonoBehaviour
{
    public GameObject rope;
    public GameObject Chandeleer;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(rope);
            rope = null;
            Chandeleer.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
