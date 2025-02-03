using UnityEngine;

public class FallChandeleer : MonoBehaviour
{
    //Refrences to the rope and the chandeleer
    public GameObject rope;
    public GameObject chandeleer;

    public void TriggerFall()
    {
        Destroy(rope);
        rope = null;
        //Makes the chandeleer fall down
        chandeleer.GetComponent<Rigidbody>().useGravity = true;
    }
}
