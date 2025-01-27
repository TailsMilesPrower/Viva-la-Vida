using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //A value for the enemy movement speed
    public float speed;

    //A refrence to the player
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //This makes the enemy move towards the player
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, (speed * Time.deltaTime));
        //This makes the enemy look at the player
        transform.LookAt(player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //This will kill the enemy. If they are hit by a bullet, both the bullet and the enemy are destroyed. However, if its hit by something else that can kill it, only the enemy is destroyed
        if(collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("KillableEnviorment"))
        {
            if(collision.gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
