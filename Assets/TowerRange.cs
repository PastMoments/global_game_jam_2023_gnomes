using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TowerRange : MonoBehaviour
{
	
	public float range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		BasicTower parent = gameObject.GetComponentInParent(typeof(BasicTower)) as BasicTower;
		if (range != parent.range) {
			range = parent.range;
			Vector2 scale = new Vector2(2.0f,1.0f);
			scale.Normalize();
			scale = scale * range;
			transform.localScale = new Vector3(scale.x, scale.y, 1.0f);
		}
    }
	
	// when a collision object enters range
    void OnTriggerEnter2D(Collider2D col)
    {
		transform.parent.gameObject.SendMessage("OnTriggerEnter2D", col);
      
    }
	
    void OnTriggerExit2D(Collider2D col)
    {
		transform.parent.gameObject.SendMessage("OnTriggerExit2D", col);
      
    }
}
