using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
	
	
	public GameObject BasicTurret;
	public bool building = false;
	public float minimumPlaceDistance;
	public GameObject currentBuilding;
	public GameObject currentPlacing;
	public List<GameObject> placedTurrets = new List<GameObject>(); // list will only contain Enemies

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (building && currentPlacing != null) {
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
			placedTurrets.Add(currentPlacing.gameObject);
		} else {
			building = false;
			currentBuilding = null;
		}
	}
	
	void OnMouseDown() {
		if (building) {
			if (currentPlacing != null) {

				foreach (GameObject turret in placedTurrets)
				{
					float dist = Vector3.Distance(currentTurret.position, turret.position);
					if (dist > minimumPlaceDistance) {
						currentPlacing.GetComponent<BasicTower>().enabled = true;
									// Remove turret cost from Currency, however, the cost is defined in the prefab in the editor.
						int turretCost = currentPlacing.GetComponent<BasicTower>().cost;
						GameObject.Find("Global").SendMessage("RemoveSaps", turretCost);
						
						currentPlacing = null;
					}
	
				}
			}
		}
	}
}
