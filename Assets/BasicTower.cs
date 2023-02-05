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
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
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
    void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.GetComponent<BasicEnemy>()) {
			rangeObjects.Add(col.gameObject);
		}
      
    }
	
    void OnTriggerExit2D(Collider2D col)
    {
		rangeObjects.Remove(col.gameObject);
      
    }

}
