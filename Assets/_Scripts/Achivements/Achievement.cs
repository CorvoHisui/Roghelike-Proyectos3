using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement
{

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string description;
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    private bool unlocked;
    public bool Unlocked
    {
        get { return unlocked; }
        set { unlocked = value; }
    }
    private int spriteIndex;
    public int SpriteIndex
    {
        get { return spriteIndex; }
        set { spriteIndex = value; }
    }
    private GameObject achievementRef;

    public Achievement(string name, string description, int spriteIndex, GameObject achievementRef)
    {
        this.name = name;
        this.description = description;
        this.unlocked = false;
        this.spriteIndex = spriteIndex;
        this.achievementRef = achievementRef;
        LoadAchievement();
    }

    public bool EarnAchievement()
    {
        if (!unlocked)
        {
            achievementRef.GetComponent<Image>().sprite = AchievemenManager.Instance.unlockSprite;
            unlocked = true;
            SaveAchievements(true);
            return true;
        }
        return false;
    }

    public void SaveAchievements(bool value)
    {
        unlocked = value;

        PlayerPrefs.SetInt(name, value ? 1 : 0);

        PlayerPrefs.Save();
    }

    public void LoadAchievement()
    {
        unlocked = PlayerPrefs.GetInt(name) == 1 ? true : false;
        if (unlocked)
        {
            achievementRef.GetComponent<Image>().sprite = AchievemenManager.Instance.unlockSprite;
        }
    }
 
}
