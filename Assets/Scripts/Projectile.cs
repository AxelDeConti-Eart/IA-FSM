using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private Movement _movement = null;
    [SerializeField] private float _deathTime = 1f;
    [SerializeField] private int _damage = 1;

    private Vector2 _direction = Vector2.zero;
    private string _tagToCheck = string.Empty;

    public void Init(Vector2 direction, string tag)
    {
        _direction = direction;
        _tagToCheck = tag;

        Invoke("DestroyProjecile", _deathTime);
    }

    private void Update()
    {
        _movement.Move(_direction);
    }

    private void DestroyProjecile()
    {
        if (gameObject != null)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == _tagToCheck)
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                //Damage the collider
                damageable.Damage(_damage);
                DestroyProjecile();
            }
        }
    }

    private void OnValidate()
    {
        if (_movement == null)
            _movement = GetComponent<Movement>();
    }
}