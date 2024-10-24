using UnityEngine;

public class State_Stun : AIState
{
    [SerializeField] private float _stunTimer = 1;

    private float _currentTimer = -1;

    protected override void OnEnter(AnimatorStateInfo stateInfo)
    {
        _currentTimer = _stunTimer;
    }

    protected override void OnUpdate(AnimatorStateInfo stateInfo)
    {
        _currentTimer -= Time.deltaTime;

        if(_currentTimer <= 0)
        {
            _enemy.SetFsmBool("IsAttacking", false);
        }
    }

    protected override void OnExit(AnimatorStateInfo stateInfo)
    {
        
    }
}