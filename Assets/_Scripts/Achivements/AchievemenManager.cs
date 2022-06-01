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

    [SerializeField]
    Transform achievementParentOfBaseAchieveents;
    [SerializeField]
    Transform earnCanvas;



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
        CreateAchievement("logro1","Mata un slime","Has acabado con un slime",0);
        CreateAchievement( "logro12", "Mata 10 slimes", "Has acabado con 10 slimes",0);
        CreateAchievement( "logro13", "Mata una rata", "Has acabado con una rata",1);
        CreateAchievement( "logro14", "Mata 10 ratas", "Has acabado con 10 ratas",1);
        CreateAchievement( "logro15", "Mata un ladron", "Has acabado con un ladron",2);
        CreateAchievement( "logro16", "Mata 10 ladrones", "Has acabado con 10 ladrones",2);
        CreateAchievement( "logro17", "Mata una arana", "Has acabado con una arana",3);
        CreateAchievement( "logro18", "Mata 10 aranas", "Has acabado con 10 aranas",3);
        CreateAchievement( "logro19", "Mata un guardia", "Has acabado con un guardia",4);
        CreateAchievement( "logro110", "Mata 10 guardias", "Has acabado con 10 guardias",4);
        CreateAchievement( "logro111", "Mata un guardia de elite", "Has acabado con un guardia de elite",5);
        CreateAchievement( "logro112", "Mata 10 guardias de elite", "Has acabado con 10 guardias de elite",5);
        CreateAchievement( "logro113", "Supera el primer nivel", "Has conseguido superar el pueblo",6);
        CreateAchievement( "logro114", "Supera el segundo nivel", "Conseguiste atravesar los caminos",7);
        CreateAchievement( "logro115", "Supera el tercer nivel", "Superaste el bosque",8);
        CreateAchievement( "logro116", "Supera el cuarto nivel", "Escapaste de la ciudad",9);
        CreateAchievement( "logro117", "Supera el quinto nivel", "Acabaste con el castillo",10);
        CreateAchievement( "logro118", "¡Que aproveche!", "Has hecho tu primera comida",11);
        CreateAchievement( "logro119", "¡En tu cara!", "Arroja un objeto",12);
        CreateAchievement( "logro120", "¡Completado!", "Consigue todos los logros",13);
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
            SetAchievementInfo(earnCanvas, achievement,title);

            StartCoroutine(HideAchievement(achievement));
        }
    }

    public IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(3);
        Destroy(achievement);
    }

    public void CreateAchievement(string AchievementName, string title,string description, int spriteIndex)
    {
        GameObject achievement = (GameObject) Instantiate(achievmentPrefab);

        Achievement newAchievement = new Achievement(AchievementName, description, spriteIndex, achievement);

        achievements.Add(title, newAchievement);

        SetAchievementInfo(achievementParentOfBaseAchieveents, achievement, title);
    }

    public void SetAchievementInfo(Transform parentOfAchievemnt, GameObject achievement,string title)
    {
        achievement.transform.SetParent(parentOfAchievemnt);
        achievement.transform.localScale = new Vector3(1, 1, 1);
        achievement.transform.GetChild(0).GetComponent<Text>().text = title;
        achievement.transform.GetChild(1).GetComponent<Text>().text = achievements[title].Description;
        achievement.transform.GetChild(2).GetComponent<Image>().sprite = sprites [achievements[title].SpriteIndex];
    }
}
