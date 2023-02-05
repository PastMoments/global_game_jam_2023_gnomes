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
        col.gameObject.GetComponent<BasicEnemy>().ApplyDamage(damage);
        col.gameObject.GetComponent<BasicEnemy>().ApplySlow((2.0f,2.0f)); // slow by half
        Destroy(gameObject);
      }

    }
}
