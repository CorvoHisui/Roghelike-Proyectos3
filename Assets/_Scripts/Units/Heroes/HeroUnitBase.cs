using UnityEngine;

public abstract class HeroUnitBase : UnitBase {
    private bool _canMove;


    public float moveSpeed=5f;
    public Transform movePoint;
    public LayerMask notWakeable;
    public LayerMask enemy;
    //public Animator anim;

    private void Awake() => GameManager.OnBeforeStateChanged += OnStateChanged;

    private void OnDestroy() => GameManager.OnBeforeStateChanged -= OnStateChanged;

    private void OnStateChanged(GameState newState) {
        if (newState == GameState.HeroTurn) _canMove = true;
        movePoint.parent=null;
    }

    public void Update() {
        // Only allow interaction when it's the hero turn
        if (GameManager.Instance.State != GameState.HeroTurn) return;
        ExecuteMove();
    }

    public virtual void ExecuteMove() {
        // Override this to do some hero-specific logic, then call this base method to clean up the turn
        MoveMotor();
    }
    private void MoveMotor(){
        
        ///movePlayer
        transform.position=Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed*Time.deltaTime);


        //Check state change
        if(Vector3.Distance(transform.position,movePoint.position)<.05f && _canMove==false){
            GameManager.Instance.ChangeState(GameState.EnemyTurn);
        }

        //if state not changed Move movePoint
        else if(Vector3.Distance(transform.position,movePoint.position)<.05f){

            if(Mathf.Abs(Input.GetAxisRaw("Horizontal"))==1){
                
                if(!Physics2D.OverlapCircle(movePoint.position+new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0),.05f, notWakeable)){
                    movePoint.position+=new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                    _canMove=false;
                }
            }
            else if(Mathf.Abs(Input.GetAxisRaw("Vertical"))==1){

                if(!Physics2D.OverlapCircle(movePoint.position+new Vector3(0, Input.GetAxisRaw("Vertical"), 0),.1f, notWakeable)){
                    movePoint.position+=new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                    _canMove=false;
                }

            }
            
            //anim.SetBool("moving", false);
        }
        
        else{
            //anim.SetBool("moving",true);
            
        }
    }
}