using UnityEngine;
using UnityEngine.AI;

public class IdleState : EnemyState
{
    private Vector3 _targetPos;
    private Vector3 _direction;

    public IdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine) {
    }

    public override void AnimationTriggerEvent() {
        base.AnimationTriggerEvent();
    }

    public override void EnterState() {
        base.EnterState();
        _targetPos = GetRandomPointInCircle();
    }

    public override void ExitState() {
        base.ExitState();
    }

    public override void FrameUpdate() {
        base.FrameUpdate();

        enemy.MoveEnemy(_targetPos);

        if ((enemy.transform.position - _targetPos).sqrMagnitude < 0.01f) {
            _targetPos = GetRandomPointInCircle();
        }

        if ((enemy.PlayerTransform.position - enemy.transform.position).magnitude < 50f) {
            enemyStateMachine.ChangeState(enemy.ChasingState);
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }

    private Vector3 GetRandomPointInCircle() {

        Vector3 result = new Vector3(enemy.transform.position.x + Random.Range(-5, 5), enemy.transform.position.y, enemy.transform.position.z + Random.Range(-5, 5));
        return result;

    }
}
