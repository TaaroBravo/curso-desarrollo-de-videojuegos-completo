using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public ZombieEnemy enemyPrefab;
    public Transform[] spawnPoints;
    public ParticleSystem spawnExplosion;
    private float _currentTime = 1f;

    void Update()
    {
        _currentTime -= Time.deltaTime;

        if(_currentTime < 0)
        {
            _currentTime = 1;
            ZombieEnemy enemy = Instantiate(enemyPrefab);
            enemy.transform.position = GetSpawnPoint();
        }
       
    }

    Vector3 GetSpawnPoint()
    {
        int random = Random.Range(0, spawnPoints.Length);
        return spawnPoints[random].position;
    }
}
