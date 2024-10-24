using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("References")]
    [SerializeField] private Animator _fsm = null;
    [SerializeField] private Movement _movement = null;
    [SerializeField] private SpriteRenderer _spriteRenderer = null;

    [Header("Health")]
    [SerializeField] private int _maxHealth = 4;

    [Header("Damage")]
    [SerializeField] private int _damage = 1;

    private int _currentHealth = 0;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void CheckIsPlayerInRange(float range)
    {
        float distance = Vector3.Distance(Player.Instance.transform.position, transform.position);
        SetFsmBool("IsPlayerInRange", distance <= range);
    }

    public void Damage(int value)
    {
        _currentHealth -= value;
        if(_currentHealth <= 0)
        {
            //Kill enemy
            Destroy(gameObject);
        }
    }

    #region FSM
    public void SetFsmBool(string name, bool value)
    {
        _fsm.SetBool(name, value);
    }

    public void SetFsmTrigger(string name)
    {
        _fsm.SetTrigger(name);
    }
    #endregion

    #region Interface
    private void OnMouseDown()
    {
        //Called when clicked on this enemy
        Debug.Log($"Clicked on {name}");

        if (Player.Instance.CanStun)
        {
            SetFsmBool("IsStun", true);
            Player.Instance.UseStun();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                //Damage the collider
                damageable.Damage(_damage);
            }
        }
    }
    #endregion

    public Movement Movement => _movement;
    public SpriteRenderer SpriteRenderer => _spriteRenderer;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;
}