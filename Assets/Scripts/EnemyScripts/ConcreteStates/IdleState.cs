using UnityEngine;
using UnityEngine.AI;

public class IdleState : EnemyState
{
    private Vector3 _targetPos;
    private Vector3 _direction;
    private float fieldOfView = 90f;

    private float timeToNextPoint;

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
        timeToNextPoint += Time.deltaTime;
        enemy.MoveEnemy(_targetPos);
        var direction = enemy.PlayerTransform.transform.position - enemy.transform.position;
        var angleToPlayer = Vector3.Angle(enemy.transform.forward, direction);

        if ((enemy.transform.position - _targetPos).sqrMagnitude < 0.01f || timeToNextPoint > 8f ) {
            _targetPos = GetRandomPointInCircle();
            timeToNextPoint = 0f;
        }

        if (((enemy.PlayerTransform.position - enemy.transform.position).magnitude < enemy.DetectionDistance && angleToPlayer < fieldOfView / 2) 
                || (enemy.PlayerTransform.position - enemy.transform.position).magnitude < 8f) {
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
