using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : MonoBehaviour
{

	public float cooldown;
	public GameObject projectiles;
	
	public float shootTimer = 0.0f;
	public int cost;
    public float damage;
	public float range = 5.0f;
    // check for null/invalid entries that represents destroyed Enemy Objects
	public List<GameObject> rangeObjects = new List<GameObject>(); // list will only contain Enemies
	
    // Start is called before the first frame update
    public virtual void Start()
    {        
    }

	// reference from prefab builds a new basic turret with default value 0. changing it in the editor does not does the value of what we spawn with 
	// it will still be 0 when we try to access it. 

    // Update is called once per frame
    public virtual void Update()
    {
		shootTimer += Time.deltaTime;
		if (shootTimer >= cooldown) {
			rangeObjects.RemoveAll(x => (x == null));
			if (rangeObjects.Count > 0) {
				BasicProjectile p = Instantiate(projectiles, transform.position, Quaternion.identity).GetComponent<BasicProjectile>();
				p.target = rangeObjects[0];
				p.damage = damage;
				shootTimer -= cooldown;
			}
		}
    }
	
	// when a collision object enters range
    public virtual void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.GetComponent<BasicEnemy>()) {
			rangeObjects.Add(col.gameObject);
		}
      
    }
	
    public virtual void OnTriggerExit2D(Collider2D col)
    {
		rangeObjects.Remove(col.gameObject);
      
    }

}
