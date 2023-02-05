using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this goes under spawner object -> Enemy.cs goes under this

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject  enemyPrefab;            // Enemy prefab; info
    [SerializeField]
    private float       spawnTime;              // Enemy spawntime
    [SerializeField]
    private Transform[] wayPoints;              // Current position
    // [SerializeField]
    // private Wave        currentWave;            // Current wave info

    private void Awake() {
        // 적 생성 코루틴 함수 호출
        StartCoroutine("SpawnEnemy");
    }    

    // public void StartWave(wave wave)
    // {
    //     currentWave = wave;

    //     StartCoroutine("SpawnEnemy");
    // }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            GameObject      clone = Instantiate(enemyPrefab);       // Enemy object create
            Enemy           enemy = clone.GetComponent<Enemy>();    // Created enemy object's component -> refer to Enemy.cs

            enemy.Setup(wayPoints);                                 // wayPoint info is called by Setup() function 

            yield return new WaitForSeconds(spawnTime);             // wait until spawnTime 
        }
    }
}