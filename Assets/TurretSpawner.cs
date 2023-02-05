using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
	
	
	public GameObject BasicTurret;
	
	public bool building = false;
	public GameObject currentBuilding;
	public GameObject currentPlacing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (building && currentBuilding != null) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			currentPlacing.transform.position = new Vector3(mousePosition.x, mousePosition.y, currentPlacing.transform.position.z);
		}
    }
	
	void SpawnBasicTurret() {
		if (currentPlacing != null) {
			Destroy(currentPlacing);
			currentPlacing = null;
		}
		if (currentBuilding != BasicTurret) {
			building = true;
			currentBuilding = BasicTurret;
			
			currentPlacing = Instantiate(BasicTurret, transform.position, Quaternion.identity);
			currentPlacing.GetComponent<BasicTower>().enabled = false;
		} else {
			building = false;
			currentBuilding = null;
		}
	}
	
	
	void OnMouseDown() {
		if (building) {
			if (currentPlacing != null) {
				currentPlacing.GetComponent<BasicTower>().enabled = true;
				currentPlacing = null;
			}
		}
	}
}
