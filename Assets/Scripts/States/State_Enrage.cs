using UnityEngine;

public class State_Enrage : AIState
{
    [SerializeField] private float _range = 4;
    [SerializeField] private float _speedMultiplier = 2;
    [SerializeField] private float _enrageTimer = 1;

    private float _currentTimer = -1;

    protected override void OnEnter(AnimatorStateInfo stateInfo)
    {
        _currentTimer = _enrageTimer;
        _enemy.SetFsmBool("IsEnrage", true);
    }

    protected override void OnUpdate(AnimatorStateInfo stateInfo)
    {
        //Enrage timer
        _currentTimer -= Time.deltaTime;
        if (_currentTimer <= 0)
        {
            _enemy.SetFsmBool("IsEnrage", false);
        }

        //Movement
        Vector3 playerPos = Player.Instance.transform.position;
        Vector3 pos = _enemy.transform.position;
        Vector3 dir = playerPos - pos;
        dir.Normalize();
        _enemy.Movement.Move(dir * _speedMultiplier);

        //Check player in range
        _enemy.CheckIsPlayerInRange(_range);
    }

    protected override void OnExit(AnimatorStateInfo stateInfo)
    {

    }
}