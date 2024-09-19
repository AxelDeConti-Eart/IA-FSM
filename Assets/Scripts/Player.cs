using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private Movement _movement = null;

    [SerializeField] private float _stunDelay = 2;

    private float _currentStunTimer = -1;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        UpdateStun();
        HandleMovement();
    }

    private void UpdateStun()
    {
        if(_currentStunTimer > 0)
        {
            _currentStunTimer -= Time.deltaTime;
        }
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Mathf.Abs(horizontal) >= 0.1f || Mathf.Abs(vertical) >= 0.1f)
        {
            Vector2 movement = new Vector2(horizontal, vertical);
            _movement.Move(movement);
        }
        else
        {
            _movement.Move(Vector2.zero);
        }
    }

    public void UseStun()
    {
        _currentStunTimer = _stunDelay;
    }

    public bool CanStun => _currentStunTimer > 0;
}