using UnityEngine;

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
        Debug.Log("I am now Idling.");
    }

    public override void ExitState() {
        base.ExitState();
    }

    public override void FrameUpdate() {
        base.FrameUpdate();
        
        _direction = (_targetPos - enemy.transform.position).normalized;

        enemy.MoveEnemy(_direction);

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
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemy.RandomMoveRange;
    }
}
