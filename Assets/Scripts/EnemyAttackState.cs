using UnityEngine;
using System.Collections;

public class EnemyAttackState : MonoBehaviour
{
    public Transform leftArm;
    public Transform rightArm;

    public float attackRange = 1f;
    public float attackSpeed = 2f;
    public float attackDamage = 10f;
    private bool isAttacking = false;
    private Movement playerMovement;
    private Transform player;
    private EnemyScript enemyMovement;

    private Quaternion leftArmDefaultRotation;
    private Quaternion rightArmDefaultRotation;
    private Quaternion leftArmAttackRotation;
    private Quaternion rightArmAttackRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftArmDefaultRotation = leftArm.localRotation;
        rightArmDefaultRotation = rightArm.localRotation;

        leftArmAttackRotation = Quaternion.Euler(-45, 0, 0) * leftArmDefaultRotation;
        rightArmAttackRotation = Quaternion.Euler(-45, 0, 0) * rightArmDefaultRotation;

        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            FindPlayer();
            return;
        }
        
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackRange)
        {
            if (!isAttacking)
                StartCoroutine(AttackAnimation());
        }
        else if (!isAttacking && enemyMovement != null)
        {
            enemyMovement.ResumeMovement(); //This will resume their movement when player moves away
        }
    }

    void FindPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) 
        {
            player = playerObj.transform;
            playerMovement = playerObj.GetComponent<Movement>();
        }
    }

    IEnumerator AttackAnimation()
    {
        isAttacking = true;
        if (enemyMovement != null)
        {
            enemyMovement.StopMovement(); // This will stop their movement when attacking
        }


        float elapsedTime = 0f;
        while (elapsedTime < 1f / attackSpeed)
        {
            leftArm.localRotation = Quaternion.Slerp(leftArmDefaultRotation, leftArmAttackRotation, elapsedTime * attackSpeed);
            rightArm.localRotation = Quaternion.Slerp(rightArmDefaultRotation, rightArmAttackRotation, elapsedTime * attackSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.1f); //This is a small delay before dealing damage

        if (playerMovement != null && Vector3.Distance(transform.position, player.position) <= attackRange) 
        {
            playerMovement.ChangeHealth(-attackDamage);
        }

        yield return new WaitForSeconds(0.2f); //This is to time the delay when the arms reset

        elapsedTime = 0f;
        while (elapsedTime < 1f / attackSpeed)
        {
            leftArm.localRotation = Quaternion.Slerp(leftArmAttackRotation, leftArmDefaultRotation, elapsedTime * attackSpeed);
            rightArm.localRotation = Quaternion.Slerp(rightArmAttackRotation, rightArmDefaultRotation, elapsedTime * attackSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isAttacking = false;
    }

}
