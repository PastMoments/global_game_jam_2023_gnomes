using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : MonoBehaviour
{

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
