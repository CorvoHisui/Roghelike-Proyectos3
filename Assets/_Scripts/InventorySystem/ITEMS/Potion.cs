using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public int hp=2;
    PlayerController playerController;
    public void Heal(){
        playerController=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        playerController.currHealth += hp;
        playerController.healthBar.SetHealth(playerController.currHealth);
        Destroy(gameObject);
    }
}
