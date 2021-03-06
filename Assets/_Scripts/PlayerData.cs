using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public int health;
    public Scene scene;

    public float[] position;
    public string activeScene;
    public List<Item> inventory = new List<Item>();

    public PlayerData(GameManager manager)
    {
        activeScene = SceneManager.GetActiveScene().name;
        health = manager.playerController.currHealth;
        scene = SceneManager.GetActiveScene();

        position = new float[3];

        position[0] = manager.playerController.transform.position.x;
        position[1] = manager.playerController.transform.position.y;
        position[2] = manager.playerController.transform.position.z;
    }
}
