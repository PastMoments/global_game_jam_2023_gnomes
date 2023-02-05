using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEProjectile : BasicProjectile
{
    // configure destroyTimer
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        if (destroyTimer > 0.0f) {
            destroyTimer -= Time.deltaTime;
        } else {
            Destroy(gameObject);
        }

		movement.Normalize();
		
		GetComponent<Rigidbody2D>().MovePosition(transform.position + (Vector3)(movement) * speed * Time.deltaTime);
		GetComponent<Rigidbody2D>().MoveRotation(Quaternion.LookRotation(movement, new Vector3(0.0f,0.0f,1.0f)));
    }
}
