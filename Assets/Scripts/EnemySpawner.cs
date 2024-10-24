using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn area")]
    [SerializeField] private Vector2 _verticalBoxSize = Vector2.zero;
    [SerializeField] private Vector2 _horizontalBoxSize = Vector2.zero;

    [Header("Enemies")]
    [SerializeField] private List<Enemy> _enemyPrefabs = null;
    [SerializeField] private float _timeBetweenSpawn = 3;

    private float _currentTimer = 0;

    private void Start()
    {
        _currentTimer = _timeBetweenSpawn;
    }

    private void Update()
    {
        _currentTimer -= Time.deltaTime;
        if(_currentTimer <= 0)
        {
            _currentTimer = _timeBetweenSpawn;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Enemy prefab = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Count)];
        Enemy enemy = Instantiate(prefab);
        int leftOrRight = Random.Range(0.0f, 1.0f) > 0.5f ? 1 : -1;
        int upOrDown = Random.Range(0.0f, 1.0f) > 0.5f ? 1 : -1;
        float hor = Random.Range(_horizontalBoxSize.x, _horizontalBoxSize.y);
        float vert = Random.Range(_verticalBoxSize.x, _verticalBoxSize.y);
        enemy.transform.position = new Vector3(leftOrRight * hor / 2, upOrDown * vert / 2);
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 topLeftOut = new Vector3(-_horizontalBoxSize.y / 2, _verticalBoxSize.y / 2, 0);
        Vector3 topLeftIn = new Vector3(-_horizontalBoxSize.x / 2, _verticalBoxSize.x / 2, 0);
        Vector3 topRightOut = new Vector3(_horizontalBoxSize.y / 2, _verticalBoxSize.y / 2, 0);
        Vector3 topRightIn = new Vector3(_horizontalBoxSize.x / 2, _verticalBoxSize.x / 2, 0);
        Vector3 bottomLeftOut = new Vector3(-_horizontalBoxSize.y / 2, -_verticalBoxSize.y / 2, 0);
        Vector3 bottomLeftIn = new Vector3(-_horizontalBoxSize.x / 2, -_verticalBoxSize.x / 2, 0);
        Vector3 bottomRightOut = new Vector3(_horizontalBoxSize.y / 2, -_verticalBoxSize.y / 2, 0);
        Vector3 bottomRightIn = new Vector3(_horizontalBoxSize.x / 2, -_verticalBoxSize.x / 2, 0);


        //Out
        Gizmos.color = Color.red;
        Gizmos.DrawLine(topLeftOut, topRightOut);
        Gizmos.DrawLine(topRightOut, bottomRightOut);
        Gizmos.DrawLine(bottomRightOut, bottomLeftOut);
        Gizmos.DrawLine(bottomLeftOut, topLeftOut);

        //In
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(topLeftIn, topRightIn);
        Gizmos.DrawLine(topRightIn, bottomRightIn);
        Gizmos.DrawLine(bottomRightIn, bottomLeftIn);
        Gizmos.DrawLine(bottomLeftIn, topLeftIn);
    }
}
