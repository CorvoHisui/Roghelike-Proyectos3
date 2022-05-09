using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CraftRecipeDatabase : MonoBehaviour
{
    public List<CraftRecipe> recipes;
    ItemDatabase itemDatabase;
    void Awake()
    {
        itemDatabase = GetComponent<ItemDatabase>();
        BuildCraftRecepiDatabase();
    }
    public Item CheckRecepie(int[] recipe){
        foreach (CraftRecipe craftRecipe in recipes)
        {
            if(craftRecipe.requiredItems.SequenceEqual(recipe)){
                return itemDatabase.GetItem(craftRecipe.itemToCraft);
            }
        }
        return null;
    }
    void BuildCraftRecepiDatabase(){
        recipes = new List<CraftRecipe>(){
            new CraftRecipe(1, 
            new int[]{
                2, 0, 0,
                0, 0, 0,
                0, 0, 0
            })
        };
    }
}
