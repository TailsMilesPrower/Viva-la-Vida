using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    //Self explanitory, a method that destroys an item.
    public void DestroyThing()
    {
        Destroy(gameObject);
    }
}
