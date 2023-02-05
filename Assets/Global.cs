using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Global : MonoBehaviour
{
    public static Global instance;
    public float health = 100.0f; 
    public float timeElapsed = 0.0f;  
    public int treeSap = 10;

	public GameObject TimerText;
	public GameObject MoneyText;
	public GameObject HealthText;
	
    void Start()
    {
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
		
		TimeSpan t = TimeSpan.FromSeconds(timeElapsed);
		string format = (t.Hours >= 1 ? @"hh\:" : "") + @"mm\:ss\.ff";
		TimerText.GetComponent<Text>().text = t.ToString(format);
		MoneyText.GetComponent<Text>().text = health.ToString();
		HealthText.GetComponent<Text>().text = treeSap.ToString();
    }
    
    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (health == 0.0f) {
            print("GEE GEE");
        }
    }

    public void AddSaps(int amount) 
    {
        treeSap += amount; 
    }

    public void RemoveSaps(int amount)
    {
        treeSap -= amount;
    }

    public int GetSaps() 
    {
        return treeSap;
    }

    public void MuteToggle(bool muted)
    {
        if(muted) {
            AudioListener.volume = 0;
        } else {
            AudioListener.volume = 1;
        }

    }
}
