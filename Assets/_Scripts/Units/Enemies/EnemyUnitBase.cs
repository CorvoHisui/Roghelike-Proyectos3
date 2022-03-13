using UnityEngine;
using Pathfinding;
using System;

public class EnemyUnitBase : UnitBase
{
    public Transform target;
    public float speed=5f;
    public float nextWaypointDistance=0;

    Path path;
    int currWaypoint=0;
    bool reachedEndOfPath=false;

    Seeker seeker;

    private void Awake() => GameManager.OnBeforeStateChanged += OnStateChanged;

    private void OnDestroy() => GameManager.OnBeforeStateChanged -= OnStateChanged;

    private void OnStateChanged(GameState newState) {
        seeker=GetComponent<Seeker>();
        seeker.StartPath(transform.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p){
        if(!p.error){
            path=p;
            currWaypoint=1;
        }
    }
    public void Update() {
        // Only allow interaction when it's the hero turn
        if (GameManager.Instance.State != GameState.EnemyTurn) return;

        if(Vector3.Distance(transform.position, target.position)>=1)
            ExecuteMove();
        else if(Vector3.Distance(transform.position, target.position)<1){
            ExecuteAttack();
        }
    }

    private void ExecuteAttack()
    {
        
        Debug.Log("EnemyAttack");
        GameManager.Instance.ChangeState(GameState.HeroTurn);

    }

    public virtual void ExecuteMove() {
         if(path==null){
            return;
        }
        if(currWaypoint>=path.vectorPath.Count){
            reachedEndOfPath=true;
            return;
        }
        else{
            reachedEndOfPath=false;
        }

        Vector2 direction=(path.vectorPath[currWaypoint]-transform.position).normalized;

        transform.position=Vector3.Lerp(transform.position,new Vector3(transform.position.x+direction.x, transform.position.y+direction.y,0), speed*Time.deltaTime);

        float distance=Vector2.Distance(transform.position,path.vectorPath[currWaypoint]);

        if(distance<nextWaypointDistance){
            GameManager.Instance.ChangeState(GameState.HeroTurn);
            currWaypoint++;
        }
        
        // Override this to do some hero-specific logic, then call this base method to clean up the turn
    }
}
