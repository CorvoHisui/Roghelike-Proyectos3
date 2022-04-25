using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAi : MonoBehaviour
{
    public Transform target;
    public float speed=200f;
    public float nextWaypointDistance = 0.1f;

    Path path;
    int currentWaypoint=0;
    bool reachedEndOfPath=false;
    bool turnMade;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        GameManager.instance.AddEnemyToList(this);
    }

    // Update is called once per frame
    void Update()
    {
        MoveMotor();
    }

    public void FindPath(){
        turnMade=false;
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p){
        if(!p.error){
            path=p;
            currentWaypoint=0;
            
        }
    }
    void MoveMotor(){
        if(path==null){
            return;
        }
        if(currentWaypoint>=path.vectorPath.Count){
            reachedEndOfPath=true;
            return;
        }else{
            reachedEndOfPath=false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance<nextWaypointDistance){
            turnMade=true;
        }
    }
}
