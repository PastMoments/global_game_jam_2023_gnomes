using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretSpawner : MonoBehaviour
{
	
	public GameObject Cannon;
	public GameObject Harpoon;
	public GameObject Catapult;
	public GameObject RedShroom;
	public GameObject BlueShroom;
	
	public bool building = false;
	public float minimumPlaceDistance;
	public GameObject currentBuilding;
	public GameObject currentPlacing;
	public List<GameObject> placedTurrets = new List<GameObject>(); // list will only contain Enemies
	
    [SerializeField] private EventSystem eventSystem;
    private GameObject lastSelectedObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() { 
		// Shenanigans to make sure buttons work good
		if (eventSystem.currentSelectedGameObject == null) {
			if (currentPlacing != null) {
				eventSystem.SetSelectedGameObject(lastSelectedObject);
			}
        } else {
			lastSelectedObject = eventSystem.currentSelectedGameObject;
			if (currentPlacing == null) {
				eventSystem.SetSelectedGameObject(null);
			}
		}
		

		if (building && currentPlacing != null) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			currentPlacing.transform.position = new Vector3(mousePosition.x, mousePosition.y, currentPlacing.transform.position.z);
		}
    }
	
	void SpawnCannon() {
		SpawnTurret(Cannon);
	}
	void SpawnHarpoon() {
		SpawnTurret(Harpoon);
	}
	void SpawnCatapult() {
		SpawnTurret(Catapult);
	}
	void SpawnRedShroom() {
		SpawnTurret(RedShroom);
	}
	void SpawnBlueShroom() {
		SpawnTurret(BlueShroom);
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
				foreach (GameObject turret in placedTurrets) {
					float dist = Vector3.Distance(currentPlacing.transform.position, turret.transform.position);
					print(dist);
					if (dist < minimumPlaceDistance) {
						
						return;
					}
				}
				
				// Remove turret cost from Currency, however, the cost is defined in the prefab in the editor.
				GameObject global_obj = GameObject.Find("Global");				
				int turretCost = currentPlacing.GetComponent<BasicTower>().cost;
				if(global_obj.GetComponent<Global>().treeSap >= turretCost) {
				  currentPlacing.GetComponent<BasicTower>().enabled = true;
				  currentPlacing.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
				  placedTurrets.Add(currentPlacing);
				  global_obj.SendMessage("RemoveSaps", turretCost);
				  currentPlacing = null;
				  currentBuilding = null;
				}
			}
		}
	}
}
