using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable, IDistanceFinder
{
    private NavMeshAgent agent;

    public Transform PlayerTransform;

    public float MaxHealth { get; set; } = 50f;
    public float currentHealth { get ; set; }

    #region StateMachine Variables

    public EnemyStateMachine StateMachine { get; set; }
    public IdleState IdleState { get; set; }
    public AttackingState AttackingState { get; set; }
    public ChasingState ChasingState { get; set; }
    public bool isAggroed { get; set; }
    public bool isWithinAttackDistance { get; set; }

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
        StateMachine = new EnemyStateMachine();

        IdleState = new IdleState(this, StateMachine);
        AttackingState = new AttackingState(this, StateMachine);
        ChasingState = new ChasingState(this, StateMachine);
    }

    #endregion

    #region Idle Variables

    public float RandomMoveRange = 5f;
    public float RandomMoveSpeed = 1f;

    #endregion

    private void Start() {
        currentHealth = MaxHealth;

        StateMachine.Initialize(IdleState);
    }

    private void Update() {
        StateMachine.CurrentEnemyState.FrameUpdate();    
    }

    private void FixedUpdate() {
        StateMachine?.CurrentEnemyState.PhysicsUpdate();
    }



    #region HealthControll

    public void Damage(float DamageAmount) {
        currentHealth -= DamageAmount;

        if (currentHealth <= 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
    }
    #endregion

    #region StatusController

    public void SetAggroStatus(bool IsAggroed) {
        isAggroed = isAggroed;
    }

    public void AttackDistance(bool isWithingAttackDistance) {
       isWithinAttackDistance = isWithingAttackDistance;
    }

    #endregion

    #region Movement

    public void MoveEnemy(Vector3 Velocity) {
        agent.SetDestination(Velocity);
    }

    #endregion
}
