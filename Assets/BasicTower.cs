using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : MonoBehaviour
{

	public float cooldown = 1.0f;
	public GameObject projectiless;
	
	public float shootTimer = 0.0f;
	public int cost = 1;
    public float damage = 4.0f;
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
			print(projectiless);
			GameObject p = Instantiate(projectiless, new Vector3(0, 0, 0), Quaternion.identity);
			p.GetComponent<BasicProjectile>().target = rangeObjects.Count > 0 ? rangeObjects[0] : null; 
			shootTimer -= cooldown;
		}
		//gameObject.SendMessage("ApplyDamage", 5.0);
    }
	
   // when a collision object enters range
    void OnTriggerEnter2D(Collider2D col)
    {
      if (col.gameObject.GetComponent<BasicEnemy>()) {
        rangeObjects.Add(col.gameObject);
        print(rangeObjects.Count);
      }
      
    }
	
    void OnTriggerExit2D(Collider2D col)
    {

      rangeObjects.Remove(col.gameObject);
      print(rangeObjects.Count);
      
    }

}
