using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
	
	
	public GameObject BasicTurret;
	public bool building = false;
	public GameObject currentBuilding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
		if (Input.GetMouseButtonDown(0)) {
			if (building) {
				Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				GameObject p = Instantiate(BasicTurret, new Vector3(worldPosition.x, worldPosition.y, 0.0f), Quaternion.identity);
			}			
		}
    }
	
	void SpawnBasicTurret() {
		if (currentBuilding != BasicTurret) {
			building = true;
			currentBuilding = BasicTurret;
		} else {
			building = false;
			currentBuilding = null;
		}
	}
}
