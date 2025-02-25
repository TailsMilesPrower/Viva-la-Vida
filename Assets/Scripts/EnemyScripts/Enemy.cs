using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable, IDistanceFinder
{
    public NavMeshAgent agent;

    public Transform PlayerTransform;

    public Action OnDamage { get; set; } = delegate { };

    public float MaxHealth { get; set; } = 100f;
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
        OnDamage?.Invoke();
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
