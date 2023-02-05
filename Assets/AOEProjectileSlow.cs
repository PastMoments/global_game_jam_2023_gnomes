using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEProjectileSlow : AOEProjectile
{
    // configure destroyTimer

    // when a collision object enters range
    public override void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.GetComponent<BasicEnemy>()) {
			col.gameObject.SendMessage("ApplyDamage", damage);
            col.gameObject.SendMessage("ApplySlow", (2.0, 2.0)); // slow by half
			Destroy(gameObject);
		}
      
    }
}
