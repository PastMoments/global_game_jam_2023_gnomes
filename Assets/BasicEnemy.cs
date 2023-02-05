using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float health = 10.0f;
    public int value = 1;
	public float speed = 1.0f;

    public List<Transform> waypoints;
	public int currentWaypointIndex = 0;
	
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.forward * 5);

		if (waypoints.Count <= currentWaypointIndex) {
			// TODO: destroy itself and then decrease our health
			return;
		}
		
		
		Vector3 target = new Vector3(waypoints[currentWaypointIndex].position.x, waypoints[currentWaypointIndex].position.y, 0.0f);
		
		Vector3 direction = (target - transform.position);
		float length_to_target = direction.magnitude;
		direction.Normalize();

		if (currentWaypointIndex == 0) {
			GetComponent<Rigidbody2D>().position = target;
		} else {
			GetComponent<Rigidbody2D>().MovePosition(transform.position + direction * Time.deltaTime * speed);
		}

		if (length_to_target <= Time.deltaTime * speed) {
			currentWaypointIndex++;
		}
	
    }
	
	void ApplyDamage(float damage) {
		health -= damage;
		if (health <= 0.0f) {
			GameObject.Find("Global").SendMessage("AddSaps", value);
			Destroy(gameObject);
		}
	}
}
