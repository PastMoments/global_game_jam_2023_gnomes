using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
   
    [Header("Currency")]
    public int treeSap = 1;
  
    public void addSaps(int amount) 
    {
        treeSap += amount; 
    }

    public void removeSaps(int amount)
    {
        treeSap -= amount;
    }

    public int getSaps() 
    {
        return treeSap;
    }
}
