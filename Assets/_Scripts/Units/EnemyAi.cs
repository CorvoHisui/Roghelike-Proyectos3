using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAi : MonoBehaviour
{
    public enum EnemyAction { None, Movimiento, Ataque}
    private EnemyAction currentAction = EnemyAction.None;

    #region Pathfinding
    public Transform target;
    public float speed = 1f;
    public float nextWaypointDistance = 0.1f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    #endregion

    [SerializeField]
    Vector2 movementNextPosition;

    Seeker seeker;
    Rigidbody2D rb;

    UnitWithTurn unitWithTurn;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        //GameManager.instance.AddEnemyToList(this);
        unitWithTurn = GetComponent<UnitWithTurn>();
        target = FindObjectOfType<PlayerController>().transform;
    }
    public void SetEnemyAction(EnemyAction newEnemyAction)
    {
        if(TurnManager.instance.CurrentState!= GameState.EnemyTurn)
        {
            return;
        }
        switch (newEnemyAction)
        {
            case EnemyAction.None:
                break;
            case EnemyAction.Movimiento:
                currentAction = EnemyAction.Movimiento;
                FindPath();
                break;
            case EnemyAction.Ataque:
                break;
            default:
                break;
        }
    }
    private void Update()
    {
        if (TurnManager.instance.CurrentState != GameState.EnemyTurn)
        {
            return;
        }
        switch (currentAction)
        {
            case EnemyAction.None:
                break;
            case EnemyAction.Movimiento:
                //FindPath();
                MoveMotor();
                break;
            case EnemyAction.Ataque:
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    public void FindPath(){
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p){
        if(p.error==false){
            path=p;
            currentWaypoint=1;
            movementNextPosition = FindNextPosition();
;
        }
    }
    Vector2 FindNextPosition()
    {
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        Vector2 nextPosition=transform.position;

        if (direction.x > 0)
        {
            nextPosition += new Vector2(1, 0);
        }
        if (direction.x < 0)
        {
            nextPosition += new Vector2(-1, 0);
        }
        if (direction.y > 0)
        {
            nextPosition += new Vector2(0, 1);
        }
        if (direction.y < 0)
        {
            nextPosition += new Vector2(0, -1);
        }


        return nextPosition;
    }
    void MoveMotor(){
        if(path==null){
            Debug.Log("move motor called path null");
            return;
        }
        //if(currentWaypoint >= path.vectorPath.Count){
        //    reachedEndOfPath=true;
        //    Debug.Log("reached end of path");
        //}

        if (Vector2.Distance(transform.position, movementNextPosition) < nextWaypointDistance)
        {
            reachedEndOfPath = true;

        }
        else
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Debug.Log(direction);
            Vector2 movementVelocity = direction * speed * Time.deltaTime;

            rb.MovePosition(rb.position + movementVelocity);
            //transform.position += Vector3.one;


            reachedEndOfPath = false;
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint+1]);

        if(distance<nextWaypointDistance){
            currentWaypoint++;
        }
        if (reachedEndOfPath)
        {

            Debug.Log("aqui fuerzo enemigo al grid");
            unitWithTurn.turnCompleted = true;
            currentAction = EnemyAction.None;
            return;
        }
    }
}
