using UnityEngine;

public class State_Run : AIState
{
    [SerializeField] private float _range = 4;

    protected override void OnEnter(AnimatorStateInfo stateInfo)
    {
        
    }

    protected override void OnUpdate(AnimatorStateInfo stateInfo)
    {
        Vector3 playerPos = Player.Instance.transform.position;
        Vector3 pos = _enemy.transform.position;
        Vector3 dir = playerPos - pos;
        dir.Normalize();

        _enemy.Movement.Move(dir);

        _enemy.CheckIsPlayerInRange(_range);
    }

    protected override void OnExit(AnimatorStateInfo stateInfo)
    {
        
    }
}