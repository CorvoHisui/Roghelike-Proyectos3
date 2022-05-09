using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    void Awake()
    {
        BuildItemDatabase();
    }

    public Item GetItem(int id){
        return items.Find(item => item.id == id);
    }

    void BuildItemDatabase(){
        items = new List<Item>(){
            new Item(1, "apple", "basic food",null, 
            new Dictionary<string, int> {
                {"Health", 2},
                {"Hunger", 3}
            }),
            new Item(1, "Rat leg", "basic food",null, 
            new Dictionary<string, int> {
                {"Health", -2},
                {"Hunger", -1}
            })
        };
    }
}
