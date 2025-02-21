using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    //A value for the enemy movement speed
    public float speed;

    //A refrence to the player
    public GameObject player;

    public int enemyNum;

    private GameObject gameManager;
    
    //This gives NavMeshAI on the enemy
    private Transform playerTransform;
    private NavMeshAgent nav;
    private bool isStopped = false;
    
    private void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();

        //This will ensure that NavMesh uses the correct speed
        if (nav != null)
        {
            nav.speed = speed;
            nav.isStopped = false;
            ResumeMovement();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;

            if (playerTransform == null)
            {
                return;
            }
        }
 
        if (!isStopped && nav != null) 
        {
            nav.SetDestination(playerTransform.position);
        }

        /*
        //Lyubo added the things below to an conditional statement, so the enemy will only move when not stopped

        //This makes the enemy move towards the player
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, (speed * Time.deltaTime));
        //This makes the enemy look at the player
        transform.LookAt(player.transform.position);

       // nav.destination = playerTransform.position;

        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //This will kill the enemy. If they are hit by a bullet, both the bullet and the enemy are destroyed. However, if its hit by something else that can kill it, only the enemy is destroyed
        if(collision.gameObject.CompareTag("KillableEnviorment"))
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        if (enemyNum == 1)
        {
            gameManager.GetComponent<GameManager>().enemyOneDead = true;
        }
        else if (enemyNum == 2)
        {
            gameManager.GetComponent<GameManager>().enemyTwoDead = true;
        }
        else if (enemyNum == 3)
        {
            gameManager.GetComponent<GameManager>().enemyThreeDead = true;
        }
        Destroy(gameObject);
    }

    public void StopMovement()
    {
        if (isStopped)
        {
            return;
        }

        isStopped = true;
        if (nav != null)
        {
            nav.isStopped = true;
        }
    }

    public void ResumeMovement()
    {
        if (!isStopped)
        {
            return;
        }
        
        isStopped = false;
        if (nav != null)
        {
            nav.isStopped = false;
            nav.SetDestination(playerTransform.position);
        }
    }

}
