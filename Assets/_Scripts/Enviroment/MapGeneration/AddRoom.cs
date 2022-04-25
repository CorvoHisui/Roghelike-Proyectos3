using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;
    void Start()
    {
        templates=GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }
    void Update()
    {
        if(templates.spawnedBoss){
            foreach (Transform child in transform) {
                if(child.name=="Destroyer"){
                    GameObject.Destroy(child.gameObject);
                }
                
            }
        }
    }
}
