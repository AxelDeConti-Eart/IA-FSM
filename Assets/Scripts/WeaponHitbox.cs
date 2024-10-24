using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage(_damage);
        }
    }
}
