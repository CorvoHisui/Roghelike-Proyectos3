using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievemenManager : MonoBehaviour
{
    public GameObject achievmentPrefab;

    public Sprite[] sprites;

    public GameObject visualAchievement;

    public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

    public Sprite unlockSprite;

    private static AchievemenManager instance;
    internal Sprite unlockedSprite;

    public static AchievemenManager Instance
    {
        get {
            if (instance==null)
            {
                instance = GameObject.FindObjectOfType<AchievemenManager>();
            }
            return AchievemenManager.instance;
        }
    }
    void Start()
    {
        //PlayerPrefs.DeleteAll();//QUITAR
        CreateAchievement("General","Mata un slime","Has acabado con un slime",0);
        CreateAchievement("General", "Mata 10 slimes", "Has acabado con 10 slimes",0);
        CreateAchievement("General", "Mata una rata", "Has acabado con una rata",1);
        CreateAchievement("General", "Mata 10 ratas", "Has acabado con 10 ratas",1);
        CreateAchievement("General", "Mata un ladron", "Has acabado con un ladron",2);
        CreateAchievement("General", "Mata 10 ladrones", "Has acabado con 10 ladrones",2);
        CreateAchievement("General", "Mata una araña", "Has acabado con una arana",3);
        CreateAchievement("General", "Mata 10 arañas", "Has acabado con 10 aranas",3);
        CreateAchievement("General", "Mata un guardia", "Has acabado con un guardia",4);
        CreateAchievement("General", "Mata 10 guardias", "Has acabado con 10 guardias",4);
        CreateAchievement("General", "Mata un guardia de elite", "Has acabado con un guardia de elite",5);
        CreateAchievement("General", "Mata 10 guardia de elite", "Has acabado con 10 guardias de elite",5);
        CreateAchievement("General", "Supera el primer nivel", "Has superado el primer nivel",6);
        CreateAchievement("General", "Supera el segundo nivel", "Has superado el segundo nivel",7);
        CreateAchievement("General", "Supera el tercer nivel", "Has superado el tercer nivel",8);
        CreateAchievement("General", "Supera el cuarto nivel", "Has superado el cuarto nivel",9);
        CreateAchievement("General", "Supera el quinto nivel", "Has superado el quinto nivel",10);
        CreateAchievement("General", "¡Que aproveche!", "Has hecho tu primera comida",11);
        CreateAchievement("General", "¡En tu cara!", "Arroja un objeto",12);
        CreateAchievement("General", "¡Completado!", "Consigue todos los logros",13);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            EarnAchievement("Mata un slime");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            EarnAchievement("Supera el tercer nivel");
        }
    }

    public void EarnAchievement(string title)
    {
        if (achievements[title].EarnAchievement())
        {
            GameObject achievement = (GameObject)Instantiate(visualAchievement);
            SetAchievementInfo("EarnCanvas",achievement,title);

            StartCoroutine(HideAchievement(achievement));
        }
    }

    public IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(3);
        Destroy(achievement);
    }

    public void CreateAchievement(string parent,string title,string description, int spriteIndex)
    {
        GameObject achievement = (GameObject) Instantiate(achievmentPrefab);

        Achievement newAchievement = new Achievement(name, description, spriteIndex, achievement);

        achievements.Add(title, newAchievement);

        SetAchievementInfo(parent, achievement,title);
    }

    public void SetAchievementInfo(string parent, GameObject achievement,string title)
    {
        achievement.transform.SetParent(GameObject.Find(parent).transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);
        achievement.transform.GetChild(0).GetComponent<Text>().text = title;
        achievement.transform.GetChild(1).GetComponent<Text>().text = achievements[title].Description;
        achievement.transform.GetChild(2).GetComponent<Image>().sprite = sprites [achievements[title].SpriteIndex];
    }
}
