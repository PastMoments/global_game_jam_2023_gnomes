using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonProjectile : BasicProjectile
{
    public int canPierceEnemies = 5;

	// when a collision object enters range
    public override void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.GetComponent<BasicEnemy>()) {
			col.gameObject.GetComponent<BasicEnemy>().ApplyDamage(damage);
			
            if (canPierceEnemies == 0) {
                Destroy(gameObject);
            }

            canPierceEnemies -= 1;
		}
      
    }
	
}
