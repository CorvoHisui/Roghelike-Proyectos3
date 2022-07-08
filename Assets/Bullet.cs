using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAi>().health -= damage;
            Debug.Log("damage done");
            Debug.Log(collision.gameObject.GetComponent<EnemyAi>().health);
            collision.gameObject.GetComponent<EnemyAi>().checkHealth();
            Vector3 textPos = new Vector3(0, 0.5f, 0);
            GameManager.instance.ShowText(damage + "damage", 10, Color.red, collision.gameObject.transform.position + textPos, Vector3.up * 6f, 2f);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag== "obstacle")
        {
            Destroy(gameObject);
        }
        
        
    }
}
