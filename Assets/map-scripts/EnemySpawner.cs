using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject  enemyPrefab;            // Enemy prefab; info
    [SerializeField]
    private float       spawnTime;              // Enemy spawntime
    [SerializeField]
    private Transform[] wayPoints;              // Current position

    private void Awake() {
        // 적 생성 코루틴 함수 호출
        StartCoroutine("SpawnEnemy");
    }    

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