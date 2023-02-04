using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Global : MonoBehaviour
{
    public static Global instance;
    public float health; 
    public float timeElapsed = 0.0f;  
    public int treeSap = 1;

    void Start()
    {
        health = 100.0f;
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
    }
    
    void ApplyDamage(float damage)
    {
        health -= damage;
        if (health == 0.0f) {
            print("GEE GEE");
        }
    }

    void AddSaps(int amount) 
    {
        treeSap += amount; 
    }

    void RemoveSaps(int amount)
    {
        treeSap -= amount;
    }

    int GetSaps() 
    {
        return treeSap;
    }
}
