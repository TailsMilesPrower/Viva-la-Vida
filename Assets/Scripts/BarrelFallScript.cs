using UnityEngine;

public class BarrelFallScript : MonoBehaviour
{
    //Refrences to the rope and the chandeleer
    public GameObject[] barrels;

    //If its hit by a bullet, both the bullet and the rope will disappear.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            //Makes the chandeleer fall down
            for(int i = 0;  i < barrels.Length; i++)
            {
                barrels[i].gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
            Destroy(this.gameObject);
        }
    }
}
