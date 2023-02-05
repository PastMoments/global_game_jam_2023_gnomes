using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
	
	
	public GameObject target;
	public float speed;
	public float damage = 0.0f;
	Vector2 movement;
	
	float destroyTimer = 5.0f; // destroy itself 5 seconds after targets disappear
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
		if (target) {
			if (movement == Vector2.zero) {
				movement = (Vector2)(target.transform.position - transform.position);
			}
		} else if (destroyTimer > 0.0f) {
			destroyTimer -= Time.deltaTime;
		} else {
			Destroy(gameObject);
		}
		
		movement.Normalize();
		GetComponent<Rigidbody2D>().MovePosition(transform.position + (Vector3)(movement) * speed * Time.deltaTime);
		if (movement != Vector2.zero) {
			float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
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
