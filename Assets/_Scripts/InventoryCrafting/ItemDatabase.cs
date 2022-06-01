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
    public Item GetItem(string title){
        return items.Find(item => item.title == title);
    }

    void BuildItemDatabase(){
        items = new List<Item>(){
            new Item(1, "Carne", "basic food",null, 
            new Dictionary<string, int> {
                {"Health", 2},
                {"Hunger", 3}
            }),
            new Item(2, "Huevo", "basic food",null, 
            new Dictionary<string, int> {
                {"Health", -2},
                {"Hunger", -1}
            }),
            new Item(3, "Pan", "basic food",null, 
            new Dictionary<string, int> {
                {"Health", 2},
                {"Hunger", 3}
            }),
            new Item(4, "Tomate", "basic food",null, 
            new Dictionary<string, int> {
                {"Health", 2},
                {"Hunger", 3}
            }),
            new Item(5, "Manzana", "basic food",null, 
            new Dictionary<string, int> {
                {"Health", 2},
                {"Hunger", 3}
            }),
            new Item(6, "Trozo de slime", "basic food",null, 
            new Dictionary<string, int> {
                {"Health", 2},
                {"Hunger", 3}
            }),
            new Item(7, "Diente de araña", "basic food",null, 
            new Dictionary<string, int> {
                {"Health", 2},
                {"Hunger", 3}
            }),
            new Item(8, "Pata de rata", "basic food",null, 
            new Dictionary<string, int> {
                {"Health", 2},
                {"Hunger", 3}
            }),
            new Item(9, "Sandwich", "basic food",null, 
            new Dictionary<string, int> {
                {"Health", 2},
                {"Hunger", 3}
            }),
            new Item(10, "Gazpacho frutal", "basic food",null, 
            new Dictionary<string, int> {
                {"Health", 2},
                {"Hunger", 3}
            }),
            new Item(11, "Bocadillo de tortilla", "basic food",null, 
            new Dictionary<string, int> {
                {"Health", 2},
                {"Hunger", 3}
            }),
            new Item(12, "Carne y huevo", "basic food",null, 
            new Dictionary<string, int> {
                {"Health", -2},
                {"Hunger", -1}
            })
        };
    }
}
