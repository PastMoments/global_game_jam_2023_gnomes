using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    // private GameObject enemyPrefab;
    private GameObject[] enemyPrefabs;

	// TODO: add different prefabs
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private List<Transform> wayPoints;

    // private int currentIndex = 0;
    float refTime    = 3.0f;
    int   currentIndex = 0;
    int   lastPeriod = 0;

    private void Awake() {
        
        StartCoroutine("SpawnEnemy");
    }    

    private void Update() {

        float currentTime = GameObject.Find("Global").GetComponent<Global>().timeElapsed;
        // print(currentTime);

        int period = (int)(currentTime / refTime);

        if ((period > lastPeriod) && (currentIndex == enemyPrefabs.Length - 1))
        {
            lastPeriod = period;

            currentIndex = 0;
            
        }
        else if ((period > lastPeriod) && (currentIndex < enemyPrefabs.Length))
        {
            lastPeriod = period;

            currentIndex++;
        }
        // print(index);

    }

    private IEnumerator SpawnEnemy() {
        while(true) {
			// TODO: add more complex logic for spawning enemies
            GameObject clone = Instantiate(enemyPrefabs[currentIndex], new Vector3(-10.0f, -10.0f, 0.0f), Quaternion.identity);
            BasicEnemy enemy = clone.GetComponent<BasicEnemy>();

			enemy.waypoints = new List<Transform>(wayPoints);
			if (wayPoints.Count > 0) {
				enemy.GetComponent<Rigidbody2D>().position = wayPoints[0].position;
			}

            yield return new WaitForSeconds(spawnTime); // wait until spawnTime 
        }
    }
}