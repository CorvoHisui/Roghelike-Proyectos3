using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePort : Interactable
{
    public Loader.Scene lvl;
    // Start is called before the first frame update
    public override void Interact()
    {
        hasInteracted=false;
        base.Interact();
        Debug.Log("TP");
        Teleport();
    }
    void Teleport(){
        if(lvl == Loader.Scene.Taberna_2)
        {
            AchievemenManager.Instance.EarnAchievement("Supera el primer nivel");
        }
        LevelLoader.instance.LoadScene(lvl);
    }
}
