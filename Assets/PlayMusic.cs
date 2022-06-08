using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public string song;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play(song);
    }

}
