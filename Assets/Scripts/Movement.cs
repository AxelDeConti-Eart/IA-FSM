using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb = null;
    [SerializeField] private SpriteRenderer _sprite = null;

    [SerializeField] private float _speed = 1f;

    private bool _canMove = true;
    private bool _isFacingRight = true;
    
    public void Move(Vector2 direction)
    {
        if (!_canMove)
            return;

        //Set velocity
        _rb.velocity = direction * _speed;

        //Change face direction
        if(_isFacingRight && direction.x < -0.1f)
        {
            _sprite.flipX = true;
            _isFacingRight = false;
        }
        else if(!_isFacingRight && direction.x > 0.1f)
        {
            _sprite.flipX = false;
            _isFacingRight = true;
        }
    }
}