using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer, textPrefab;

    private List<FloatingText> floatingTexts=new List<FloatingText>();

    void Update()
    {
        foreach (FloatingText txt in floatingTexts)
        {
            txt.UpdateFloatingText();
        }
    }
    public void Show(string _msg, int _fontSize, Color _color, Vector3 _position, Vector3 _motion, float _duration){
        
        FloatingText floatingText=GetFloatingText();

        floatingText.txt.text = _msg;
        floatingText.txt.fontSize = _fontSize;
        floatingText.txt.color = _color;
        
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(_position);
        floatingText.motion=_motion;
        floatingText.duration=_duration;

        floatingText.Show();
    }
    private FloatingText GetFloatingText(){
        FloatingText txt=floatingTexts.Find(t=> !t.active);

        if(txt==null){

            txt=new FloatingText();
            txt.go=Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt=txt.go.GetComponent<TextMeshProUGUI>();

            floatingTexts.Add(txt);
        }

        return txt;
    }
}
