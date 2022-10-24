using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;                             // waypoint is just an empty game object which is used to determine enemy movement
    [SerializeField] private Transform playerTransform;
  
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float chaseDistance = 2.0f;

    private int currentWayPointIndex = 0;

    private bool attack = false;
    private bool enemyHasWatchedPlayer = false;

    

    void Update()
    {
        if (enemyHasWatchedPlayer == false)
        {                                                                  //Enemy is patrolling area
            IsPatrollingArea();
        }                                              


        if (playerTransform.position.x<=chaseDistance )                                                                                                                                                                                                                                          
        {                                                                                             
            enemyHasWatchedPlayer =true;
        }
        else
        {
            enemyHasWatchedPlayer=false;
        }
        

        if(enemyHasWatchedPlayer == true)
        {
            AttackPlayer();
        }

    
              
    }

    void IsPatrollingArea()                                                                                    //ASSUMING THERE ARE ONLY 2 WAYPOINTS
    {
        // Here if distance between enemy and wayPoint is 0 or very less then make enemy to go to other waypoint

        if (Vector2.Distance(wayPoints[currentWayPointIndex].transform.position, transform.position) < 0.5f )         
        {
            currentWayPointIndex++;
            FlipEnemy(); 
        }

        if (currentWayPointIndex >= wayPoints.Length)                   // A condition to refresh the waypointindex number
        {
            currentWayPointIndex = 0;
        }

        // Making enemy moving towards wayPoints

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWayPointIndex].transform.position, speed * Time.deltaTime);

        
    }
    

    void FlipEnemy()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x = currentScale.x * -1;                        // This code make enemy flip to the other side
        transform.localScale = currentScale;
                                                                  
    }


    void AttackPlayer()
    {
        if (transform.position.x > playerTransform.position.x)
        { 
            transform.position += Vector3.left * (speed + 2) * Time.deltaTime;
        }                                                                                          // Increased speed when Enemy Has Watched Player
        if (transform.position.x < playerTransform.position.x)
        {
            transform.position += Vector3.right * (speed + 2) * Time.deltaTime;
        }
    }
}
