using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(GameManager.instance);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        SceneManager.LoadScene(data.activeScene);
        GameManager.instance.playerController.healthBar.SetHealth(data.health);

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        Debug.Log(position);
        GameManager.instance.playerController.transform.position = position;

        

    }
}
