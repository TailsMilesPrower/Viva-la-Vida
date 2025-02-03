using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().KillEnemy();
        }
        if(collision.gameObject.CompareTag("TriggerEnviorment"))
        {
            collision.gameObject.GetComponent<FallChandeleer>().TriggerFall();
        }
        Destroy(gameObject);
    }
}
