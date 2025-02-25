using UnityEngine;

public class Zombie : Enemy
{
    private void Start() {
        base.Start();
        AttackRange = 4f;
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("KillableEnviremoent")) {
            Damage(10f);
        }
    }
}
