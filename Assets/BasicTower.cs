using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : MonoBehaviour
{

    public float health = 10.0f;
	
	private List<GameObject> rangeObjects = new List<GameObject>();
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
		rangeObjects.Add(col.gameObject);
		print(rangeObjects);
		
    }
	
    void OnTriggerExit2D(Collider2D col)
    {
		rangeObjects.Remove(col.gameObject);
		print(rangeObjects);
    }
}
