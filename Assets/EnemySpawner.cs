using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
	// TODO: add different prefabs
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private List<Transform> wayPoints;
    // [SerializeField]
    // private Wave        currentWave;            // Current wave info

    private void Awake() {
        // 적 생성 코루틴 함수 호출
        StartCoroutine("SpawnEnemy");
    }    


    private IEnumerator SpawnEnemy() {
        while(true) {
			// TODO: add more complex logic for spawning enemies
            GameObject clone = Instantiate(enemyPrefab);
            BasicEnemy enemy = clone.GetComponent<BasicEnemy>();

			enemy.waypoints = new List<Transform>(wayPoints);
			if (wayPoints.Count > 0) {
				enemy.GetComponent<Rigidbody2D>().position = wayPoints[0].position;
			}

            yield return new WaitForSeconds(spawnTime); // wait until spawnTime 
        }
    }
}