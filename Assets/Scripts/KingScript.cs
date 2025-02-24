using UnityEngine;
using UnityEngine.AI;

public class KingScript : MonoBehaviour
{
    private int oneTimeThing = 0;

    private NavMeshAgent agent;
    private float attackCooldown = 2f;
    private float maxHealth = 3;

    private float waitForTriggerUpdate;

    [SerializeField] private float bossSpeed = 1.5f;
    [SerializeField] private float attackDamage = 20f;

    private Movement movement;
    private Transform playerTransform;

    private bool isAttacking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GameObject.Find("Player").GetComponent<Movement>();
        playerTransform = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        waitForTriggerUpdate = Time.realtimeSinceStartup + attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision) {
        if (waitForTriggerUpdate > Time.realtimeSinceStartup) {
            return;
        }
        if (collision.collider.CompareTag("Bullet")) {
            if (maxHealth > 0) {
                maxHealth -= 1f;
                Debug.LogWarning("Took Damage from the player.  " + maxHealth);
            } else if (maxHealth <= 0) Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Player")) {
            isAttacking = true;
            if (Vector3.Distance(movement.transform.position, transform.position) < 5) {
                new WaitForSeconds(1f);
                movement.ChangeHealth(-attackDamage);
                Debug.LogWarning("Did " + attackDamage + " damage to the player.");
            }
            isAttacking = false;
        }
        waitForTriggerUpdate = Time.realtimeSinceStartup + attackCooldown;
    }
}
