using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRooms;

    public List<GameObject> rooms;

    
    public float waitTime;
    public bool spawnedBoss;
    public GameObject boss;
    

    void Update()
    {
        if(waitTime<=0&&spawnedBoss==false){
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i==rooms.Count-1){
                    Instantiate(boss, rooms[i].transform.position,Quaternion.identity);
                    spawnedBoss=true;
                    Debug.Log("SpawnedPortal");
                }
            }

            
        }
        else{
            waitTime-=Time.deltaTime;
        }
    }
    
}
