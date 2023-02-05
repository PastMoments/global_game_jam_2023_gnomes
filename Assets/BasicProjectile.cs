using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
	
	
	public GameObject target;
	public float speed;
	public float damage = 0.0f;
	Vector3 movement;
	
	float destroyTimer = 5.0f; // destroy itself 5 seconds after targets disappear
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
		if (target) {
			movement = (target.transform.position - transform.position);
			movement.Normalize();
		} else if (destroyTimer > 0.0f) {
			destroyTimer -= Time.deltaTime;
		} else {
			Destroy(gameObject);
		}
			
		GetComponent<Rigidbody2D>().MovePosition(transform.position + movement * speed * Time.deltaTime);
    }
	
	
	// when a collision object enters range
    void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.GetComponent<BasicEnemy>()) {
			col.gameObject.SendMessage("ApplyDamage", damage);
			Destroy(gameObject);
		}
      
    }
	
}
