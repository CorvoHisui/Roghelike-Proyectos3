using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CraftRecipeDatabase : MonoBehaviour
{
        public List<CraftRecipe> recipes = new List<CraftRecipe>();
    private ItemDatabase itemDatabase;
    private void Awake()
    {
        itemDatabase = GetComponent<ItemDatabase>();
        BuildCraftRecepiDatabase();
    }
    public Item CheckRecipe(int[] recipe)
    {
        foreach(CraftRecipe craftRecipe in recipes)
        {
            if (craftRecipe.requiredItems.SequenceEqual(recipe))
            {
                return itemDatabase.GetItem(craftRecipe.itemToCraft);
            }
        }
        return null;
    }
    void BuildCraftRecepiDatabase(){
        recipes = new List<CraftRecipe>(){
            new CraftRecipe(9, 
            new int[]{
                0, 3, 0,
                0, 1, 0,
                0, 3, 0
            }),
            new CraftRecipe(10, 
            new int[]{
                0, 4, 0,
                4, 5, 4,
                0, 4, 0
            }),
            new CraftRecipe(11, 
            new int[]{
                0, 3, 0,
                0, 2, 0,
                0, 3, 0
            }),
            new CraftRecipe(12, 
            new int[]{
                0, 0, 0,
                1, 1, 2,
                0, 0, 0
            }),
        };
    }
}
