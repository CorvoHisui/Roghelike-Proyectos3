using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievemenManager : MonoBehaviour
{
    public GameObject achievmentPrefab;

    public Sprite[] sprites;
    void Start()
    {
        CreateAchievement("General","Test Title","This is the description",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateAchievement(string category,string title,string description, int spriteIndex)
    {
        GameObject achievement = (GameObject) Instantiate(achievmentPrefab);

        SetAchievementInfo(category, achievement,title,description,spriteIndex);
    }

    public void SetAchievementInfo(string category, GameObject achievement,string title, string description, int spriteIndex)
    {
        achievement.transform.SetParent(GameObject.Find(category).transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);
        achievement.transform.GetChild(0).GetComponent<Text>().text = title;
        achievement.transform.GetChild(1).GetComponent<Text>().text = description;
        achievement.transform.GetChild(2).GetComponent<Image>().sprite = sprites[spriteIndex];
    }
}
