using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState CurrentEnemyState { get; set; }

    public void Initialize(EnemyState StartingState) {
        CurrentEnemyState = StartingState;
        CurrentEnemyState.EnterState();
    }

    public void ChangeState(EnemyState newState) {
        CurrentEnemyState.ExitState();
        CurrentEnemyState = newState;
        CurrentEnemyState.EnterState();
    }
}
