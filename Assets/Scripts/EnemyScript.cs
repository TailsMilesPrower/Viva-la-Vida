using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, (speed * Time.deltaTime));
        transform.LookAt(player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
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
