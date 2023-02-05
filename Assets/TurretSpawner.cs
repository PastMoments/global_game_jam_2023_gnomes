using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretSpawner : MonoBehaviour
{
	
	
	public GameObject BasicTurret;
	
	public bool building = false;
	public GameObject currentBuilding;
	public GameObject currentPlacing; 
	
	
    [SerializeField] private EventSystem eventSystem;
    private GameObject lastSelectedObject;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() { 
		if (eventSystem.currentSelectedGameObject == null)
            eventSystem.SetSelectedGameObject(lastSelectedObject); // no current selection, go back to last selected
        else
            lastSelectedObject = eventSystem.currentSelectedGameObject; // keep setting current selected object
		
		if (building && currentPlacing != null) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			currentPlacing.transform.position = new Vector3(mousePosition.x, mousePosition.y, currentPlacing.transform.position.z);
		}
    }
	
	void SpawnCannon() {
		SpawnTurret(BasicTurret);
	}
	void SpawnHarpoon() {
		SpawnTurret(BasicTurret);
	}
	void SpawnCatapult() {
		SpawnTurret(BasicTurret);
	}
	void SpawnRedShroom() {
		SpawnTurret(BasicTurret);
	}
	void SpawnBlueShroom() {
		SpawnTurret(BasicTurret);
	}
	
	void SpawnTurret(GameObject turret) {
		if (currentPlacing != null) {
			Destroy(currentPlacing);
			currentPlacing = null;
		}
		if (currentBuilding != turret) {
			building = true;
			currentBuilding = turret;
			
			currentPlacing = Instantiate(turret, transform.position, Quaternion.identity);
			currentPlacing.GetComponent<BasicTower>().enabled = false;
		} else {
			building = false;
			currentBuilding = null;
		}
	}
	
	void OnMouseDown() {
		if (building) {
			if (currentPlacing != null) {
				
				// Remove turret cost from Currency, however, the cost is defined in the prefab in the editor.
				GameObject global_obj = GameObject.Find("Global");				
				int turretCost = currentPlacing.GetComponent<BasicTower>().cost;
				if(global_obj.GetComponent<Global>().treeSap >= turretCost) {
					currentPlacing.GetComponent<BasicTower>().enabled = true;
					global_obj.SendMessage("RemoveSaps", turretCost);
					currentPlacing = null;
					currentBuilding = null;
				}
			}
		}
	}
}
