using System.Threading;
using UnityEngine;

public class AttackingState : EnemyState
    {
    private float timer;
    private float timeBetweenAttacks = 2f;

    private float exitTimer;
    private float timeTilExit;

    private Movement movementScript;
    public AttackingState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine) {
       movementScript = enemy.PlayerTransform.GetComponent<Movement>();
    }

    public override void AnimationTriggerEvent() {
        base.AnimationTriggerEvent();
    }

    public override void EnterState() {
        base.EnterState();
    }

    public override void ExitState() {
        base.ExitState();
    }

    public override void FrameUpdate() {
        base.FrameUpdate();

        enemy.MoveEnemy(enemy.transform.position);

        if (timer > timeBetweenAttacks) {

            timer = 0f;

            movementScript.ChangeHealth(enemy.DamageDelt);


        }

        if (Vector3.Distance(enemy.PlayerTransform.position, enemy.transform.position) > enemy.AttackRange) {
            exitTimer += Time.deltaTime;

            if (exitTimer > timeTilExit) {
                enemy.AttackDistance(false);
                enemyStateMachine.ChangeState(enemy.ChasingState);
            }
        }
        else {
            exitTimer = 0f;
        }

        timer += Time.deltaTime;
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
}
