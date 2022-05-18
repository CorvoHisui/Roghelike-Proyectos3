using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    public void GenerateTooltip(Item item){
        string statText = "";
        foreach (var stat in item.stats){
            statText += stat.Key.ToString() + ": " + stat.Value + "\n";
        }
        string tooltip = string.Format("<b>{0}</b>\n{1}\n\n{2}", item.title, item.description, statText);
        text.text=tooltip;
        gameObject.SetActive(true);
    }
}
