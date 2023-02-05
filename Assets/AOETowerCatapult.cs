using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETowerCatapult : BasicTower
{


    // Update is called once per frame
    public override void Update()
    {
		shootTimer += Time.deltaTime;
		if (shootTimer >= cooldown) {
			rangeObjects.RemoveAll(x => (x == null));
			if (rangeObjects.Count > 0) {
				Vector2 movement = Vector2.zero;
				if (rangeObjects[0]) {
					movement = (Vector2)(rangeObjects[0].transform.position - transform.position);
					movement.Normalize();
				}
				BasicProjectile p = Instantiate(projectiles, transform.position + (Vector3)movement * 0.5f, Quaternion.identity).GetComponent<BasicProjectile>();
				p.target = rangeObjects[0];
				p.damage = damage;
				
				shootTimer -= cooldown;
			}
		}
    }
}
