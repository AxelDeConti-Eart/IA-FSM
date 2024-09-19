using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _fsm = null;
    [SerializeField] private Movement _movement = null;

    private void OnMouseDown()
    {
        //Called when clicked on this enemy
        Debug.Log($"Clicked on {name}");

        if (Player.Instance.CanStun)
        {
            Player.Instance.UseStun();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            //End game
            Debug.Log("End game");
        }
    }

    public Movement Movement => _movement;
}