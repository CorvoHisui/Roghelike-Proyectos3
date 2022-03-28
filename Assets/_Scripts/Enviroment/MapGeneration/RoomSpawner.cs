using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    private RoomTemplates roomTemplates;
    private int rand;
    public bool spawned=false;
    public float waitTime =4f;

    void Start()
    {
        Destroy(gameObject,waitTime);
        roomTemplates=GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }
    void Spawn()
    {
        if(spawned==false){
            if(openingDirection==1){
            //Need room with TOP door;
            rand = Random.Range(0, roomTemplates.topRooms.Length-1);
            Instantiate(roomTemplates.topRooms[rand], transform.position, Quaternion.identity);

            }
            else if(openingDirection==2){
                //Need room with RIGHT door;
                rand = Random.Range(0, roomTemplates.rightRooms.Length-1);
                Instantiate(roomTemplates.rightRooms[rand], transform.position, Quaternion.identity);
            }
            else if(openingDirection==3){
                //Need room with BOTTOM door
                rand = Random.Range(0, roomTemplates.bottomRooms.Length-1);
                Instantiate(roomTemplates.bottomRooms[rand], transform.position, Quaternion.identity);
            }
            else if(openingDirection==4){
                //Need room with LEFT door
                rand = Random.Range(0, roomTemplates.leftRooms.Length-1);
                Instantiate(roomTemplates.leftRooms[rand], transform.position, Quaternion.identity);
            }
            spawned=true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("SpawnPoint")){
            if(other.GetComponent<RoomSpawner>().spawned==false && spawned == false){
                //spawn WallBlocking exit
                Instantiate(roomTemplates.closedRooms, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned=true;
        }
    }
}
