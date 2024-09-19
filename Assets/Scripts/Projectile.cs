using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Movement _movement = null;
    [SerializeField] private float _deathTime = 1f;

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
        if(gameObject != null)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == _tagToCheck)
        {
            //End game
            Debug.Log("End game");
        }
    }
}