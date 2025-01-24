using UnityEngine;

public class FallChandeleer : MonoBehaviour
{
    //Refrences to the rope and the chandeleer
    public GameObject rope;
    public GameObject Chandeleer;

    //If its hit by a bullet, both the bullet and the rope will disappear.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(rope);
            rope = null;
            //Makes the chandeleer fall down
            Chandeleer.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
