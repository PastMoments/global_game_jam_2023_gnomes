using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETower : BasicTower
{
    public List<Vector3> allProjectiles = new List<Vector3>();
    public override void Update()
    {
      shootTimer += Time.deltaTime;
      if (shootTimer >= cooldown) {
        rangeObjects.RemoveAll(x => (x == null));
        
        if (rangeObjects.Count > 0) {
          // Vector2 movement = Vector2.zero;

          // movement = (Vector2)(rangeObjects[0].transform.position - transform.position);
          // movement.Normalize();
          
          // GameObject p = Instantiate(projectiles, transform.position + (Vector3)movement * 0.5f, Quaternion.identity);
          allProjectiles.Add(Vector2.right);
          allProjectiles.Add(Vector2.left);
          allProjectiles.Add(Vector2.up);
          allProjectiles.Add(Vector2.down);
          allProjectiles.Add(new Vector2(0.5f, 0.5f));
          allProjectiles.Add(new Vector2(-0.5f, -0.5f));
          allProjectiles.Add(new Vector2(-0.5f, 0.5f));
          allProjectiles.Add(new Vector2(0.5f, -0.5f));
          
          

          for (int i = 0; i < 8; i++) {
            GameObject p = Instantiate(projectiles, transform.position, Quaternion.identity);
            AOEProjectile projectile = p.GetComponent<AOEProjectile>();
            projectile.movement = allProjectiles[i];
            projectile.damage = damage;
          }
          shootTimer -= cooldown;
        }
		  }
    }

}
