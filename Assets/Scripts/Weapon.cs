using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _parent = null;

    private void Update()
    {
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        // Calculate the direction vector from this position to mouse position
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos = transform.position;
        Vector3 direction = mouseWorldPos - pos;

        // Calculate the angle and apply it
        float angle = Mathf.Atan2(direction.y, direction.x);
        _parent.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
    }
}
