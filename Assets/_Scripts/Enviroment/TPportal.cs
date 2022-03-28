using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPportal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player"){
            LevelLoader.instance.LoadScene(Loader.Scene.LevelOne);
            Debug.Log("player tp");
        }
    }
}
