using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : StaticInstance<LevelLoader>
{
    public Animator animator;
    public float transitionTime=1f;

    public void LoadScene(Loader.Scene scene){
        StartCoroutine(LoadScene(animator, scene, transitionTime));
    }

    public static IEnumerator LoadScene(Animator animator, Loader.Scene scene, float transitionTime){
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        Loader.Load(scene);
    }
}
