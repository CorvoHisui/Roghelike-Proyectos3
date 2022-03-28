using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance=null;
    public Animator animator;
    public float transitionTime=1f;
    void Awake()
    {
        if(instance==null)
            instance=this;
        else if(instance!=this)
            Destroy(gameObject);
    }
    public void LoadScene(Loader.Scene scene){
        StartCoroutine(LoadScene(animator, scene, transitionTime));
    }

    public static IEnumerator LoadScene(Animator animator, Loader.Scene scene, float transitionTime){
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        Loader.Load(scene);
    }
}
