using UnityEngine;

public class State_MageAttack : AIState
{
    [SerializeField] private float _range = 4;
    [SerializeField] private Projectile _projectilePrefab = null;
    [SerializeField] private float _attackTimer = 1;

    private float _currentTimer = -1;

    protected override void OnEnter(AnimatorStateInfo stateInfo)
    {
        _enemy.SetFsmBool("IsAttacking", true);
        _currentTimer = _attackTimer;

        //Spawn projectile
        Projectile p = Instantiate(_projectilePrefab, _enemy.transform.position, Quaternion.identity);

        Vector2 projectilePosition = p.transform.position;
        Vector2 playerPosition = Player.Instance.transform.position;
        Vector2 direction = playerPosition - projectilePosition;
        direction.Normalize();
        p.Init(direction, "Player");
    }

    protected override void OnUpdate(AnimatorStateInfo stateInfo)
    {
        _currentTimer -= Time.deltaTime;

        if (_currentTimer <= 0)
        {
            _enemy.SetFsmBool("IsAttacking", false);
        }
    }

    protected override void OnExit(AnimatorStateInfo stateInfo)
    {
        
    }
}