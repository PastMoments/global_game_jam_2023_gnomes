using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEProjectileCatapult : BasicProjectile
{
    // implement curvature 

    // when a collision object enters range
    public override void OnTriggerEnter2D(Collider2D col)
    {
      if (col.gameObject.GetComponent<BasicEnemy>()) {
        col.gameObject.GetComponent<BasicEnemy>().ApplyDOTDamage((damage+1.0f, 2.0f)); // deals more damage but over time instead
        Destroy(gameObject);
      }
      
    }
}
