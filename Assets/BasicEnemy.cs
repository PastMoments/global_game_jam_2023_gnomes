using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float health = 10.0f;
    public float value = 1.0f;
	public float speed = 1.0f;

    public List<Transform> waypoints;
	public int currentWaypointIndex = 0;
	float slowAmount;
	float duration;
	float DOTDamage;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.forward * 5);
		print(health);
		float intensity = speed;
		if (duration > 0.0f) {
			if (slowAmount != 0.0f)  {
				intensity = speed / slowAmount;
			}
			
			if (DOTDamage != 0.0f) {
				float damageToBeDealt = DOTDamage / (duration * 1000);
				ApplyDamage(damageToBeDealt);
			}

			duration -= Time.deltaTime;
		} else {
			slowAmount = 0.0f;
			DOTDamage = 0.0f;
		}

		float intensity = speed;
		if (duration > 0) {
			intensity = speed / slowAmount;

			duration -= Time.deltaTime;
		}

		if (waypoints.Count <= currentWaypointIndex) {
			Destroy(gameObject);
			GameObject.Find("Global").GetComponent<Global>().ApplyDamage(value);
			return;
		}
		
		
		Vector3 target = new Vector3(waypoints[currentWaypointIndex].position.x, waypoints[currentWaypointIndex].position.y, 0.0f);
		
		Vector3 direction = (target - transform.position);
		float length_to_target = direction.magnitude;
		direction.Normalize();

		if (currentWaypointIndex == 0) {
			GetComponent<Rigidbody2D>().position = target;
		} else {
			GetComponent<Rigidbody2D>().MovePosition(transform.position + direction * Time.deltaTime * intensity);
		}

		if (length_to_target <= Time.deltaTime * intensity) {
			currentWaypointIndex++;
		}
	
    }
	
	public void ApplyDamage(float damage) {
		health -= damage;
		if (health <= 0.0f) {
			GameObject.Find("Global").GetComponent<Global>().AddSaps((int)value);
			Destroy(gameObject);
		}
	}

	public void ApplySlow((float, float) slow) {
		this.slowAmount = slow.Item1;
		this.duration = slow.Item2;
	}

	public void ApplyDOTDamage((float, float) damage) {
		this.DOTDamage = damage.Item1;
		this.duration = damage.Item2;
	}
}
