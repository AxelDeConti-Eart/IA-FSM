using UnityEngine;

public class State_Idle : AIState
{
    [SerializeField] private float _range = 4;

    protected override void OnEnter(AnimatorStateInfo stateInfo)
    {
        
    }

    protected override void OnUpdate(AnimatorStateInfo stateInfo)
    {
        _enemy.CheckIsPlayerInRange(_range);
    }

    protected override void OnExit(AnimatorStateInfo stateInfo)
    {
        
    }
}