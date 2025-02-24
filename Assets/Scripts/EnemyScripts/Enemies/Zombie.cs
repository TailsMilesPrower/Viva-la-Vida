using UnityEngine;

public class Zombie : Enemy
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Bullet")) {
            Damage(10f);
        }
    }
}
