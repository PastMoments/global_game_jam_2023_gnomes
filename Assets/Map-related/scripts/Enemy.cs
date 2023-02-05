using System.Collections;
using UnityEngine;

// this goes under Enemy prefab asset

public class Enemy: MonoBehaviour
{
    private int             wayPointCount;      // Number of waypoints
    private Transform[]     wayPoints;          // Waypoints info
    private int             currentIndex = 0;   // Current position index
    private Movement2D      movement2D;         // Object movement control -> refer to Movement2D.cs

    public void Setup(Transform[] wayPoints){
        movement2D = GetComponent<Movement2D>();        

        // Setting WayPoints info for Eenemy movement
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        // Setting enemy;s position as the 0th index of wayPoints
        transform.position = wayPoints[currentIndex].position;

        // Initiate enemy moving functions
        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove(){ 
    
        NextMoveTo();

        while(true){
            // Enemy object rotation
            transform.Rotate(Vector3.forward * 10);

            // If the distance between enemy's current position and target is less than 0.02 * movement2D.MoveSpeed start "if" statement
            // movement2D.MoveSpeed -> Because if the speed is fast, a frame moves bigger than 0.02, and it may neglect "if" statement
            if(Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement2D.MoveSpeed){
                
                // Direction to next target setting
                NextMoveTo();
            }

            yield return null;
        }
    }

    private void NextMoveTo()
    {
        // If final wayPoints not reached 
        if (currentIndex < wayPointCount - 1)
        {
            // Set enemy location to target location
            transform.position = wayPoints[currentIndex].position;
            // Enemy next target => next wayPoints
            currentIndex ++;

            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        // If current position is the last wayPoints
        else
        {
            // Destroy corresponding object 
            Destroy(gameObject);
        }
    }
        
}