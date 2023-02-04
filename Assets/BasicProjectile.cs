using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
	
	
	public GameObject target;
	public float speed;
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
		if (target) {
			Vector3 movement = target.transform.position - transform.position;
			movement.Normalize();
			
			
			GetComponent<Rigidbody2D>().MovePosition(transform.position + movement * speed * Time.deltaTime);
		}
    }
}
