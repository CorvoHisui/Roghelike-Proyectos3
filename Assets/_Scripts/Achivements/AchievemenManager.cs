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

    private int fadeTime = 2;

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
        PlayerPrefs.DeleteAll();//QUITAR
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
        CreateAchievement( "logro120", "¡Completado!", "Consigue todos los logros",13,new string[] { "Mata un slime", "Mata 10 slimes", "Mata una rata", "Mata 10 ratas", "Mata un ladron", "Mata 10 ladrones", "Mata una arana", "Mata 10 aranas", "Mata un guardia", "Mata 10 guardias", "Mata un guardia de elite", "Mata 10 guardias de elite", "Supera el primer nivel", "Supera el segundo nivel", "Supera el tercer nivel", "Supera el cuarto nivel", "Supera el quinto nivel", "¡Que aproveche!", "¡En tu cara!" });
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

            StartCoroutine(FadeAchievement(achievement));
        }
    }

    public IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(3);
        Destroy(achievement);
    }

    public void CreateAchievement(string AchievementName, string title,string description, int spriteIndex,string[]dependencies=null)
    {
        GameObject achievement = (GameObject) Instantiate(achievmentPrefab);

        Achievement newAchievement = new Achievement(AchievementName, description, spriteIndex, achievement);

        achievements.Add(title, newAchievement);

        SetAchievementInfo(achievementParentOfBaseAchieveents, achievement, title);

        if (dependencies!=null)
        {
            foreach (string achievementTitle in dependencies)
            {
                Achievement dependency = achievements[achievementTitle];
                dependency.Child = title;
                newAchievement.AddDependency(dependency);
            }
        }
    }

    public void SetAchievementInfo(Transform parentOfAchievemnt, GameObject achievement,string title)
    {
        achievement.transform.SetParent(parentOfAchievemnt);
        achievement.transform.localScale = new Vector3(1, 1, 1);
        achievement.transform.GetChild(0).GetComponent<Text>().text = title;
        achievement.transform.GetChild(1).GetComponent<Text>().text = achievements[title].Description;
        achievement.transform.GetChild(2).GetComponent<Image>().sprite = sprites [achievements[title].SpriteIndex];
    }

    private IEnumerator FadeAchievement(GameObject achievement)
    {
        CanvasGroup canvasGroup = achievement.GetComponent<CanvasGroup>();
        float rate = 5.0f / fadeTime;
        int startAlpha = 0;
        int endAlpha = 1;

        for (int i = 0; i < 2; i++)
        {
            float progress = 0.0f;

            while (progress < 1.0)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, progress);
                progress += rate * Time.deltaTime;

                yield return null;
            }
            yield return new WaitForSeconds(2);
            startAlpha = 1;
            endAlpha = 0;
        }
        Destroy(achievement);
    }
}
