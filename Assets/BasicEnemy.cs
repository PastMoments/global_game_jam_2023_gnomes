using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
	
    public float health = 10.0f;
    public int value = 1;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
		gameObject.transform.position += new Vector3(-0.5f, 0.0f, 0.0f) * Time.deltaTime;
		if (health == 0.0f) {
			GameObject.Find("Global").SendMessage("AddSaps", value);
		}
    }
	
	void ApplyDamage(float damage) {
		health -= damage;
    if (health == 0.0f) {
      Destroy(gameObject);
    }
		print("Trying to apply damage");
  }
}
