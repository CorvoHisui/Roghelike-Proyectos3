using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public int index;
    public int maxIndex;
    [SerializeField] bool keyDown;
    [SerializeField] RectTransform rectTransform;
    public bool isPressUp, isPressDown, isPressConfirm;
    int verticalMovement;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform.GetComponent<RectTransform>();
        isPressUp=false;
        isPressDown=false;
    }
    public void onPressUp()
    {
        isPressUp = true;
    }
 
    public void onReleaseUp()
    {
        isPressUp = false;
    }
 
    public void onPressDown()
    {
        isPressDown = true;
    }
 
    public void onReleaseDown()
    {
        isPressDown = false;
    }
 
    public void onPressConfirm()
    {
        isPressConfirm = true;
    }
 
    public void onReleaseConfirm()
    {
        isPressConfirm= false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isPressUp)   verticalMovement = 1; 
        if (isPressDown) verticalMovement = -1;
        if (!isPressUp && !isPressDown) verticalMovement = 0;
        if (Input.GetAxisRaw("Vertical") != 0 || verticalMovement!=0)
        {
            if(!keyDown)
            {
                if(Input.GetAxisRaw("Vertical") < 0 || verticalMovement<0)
                {
                    if (index < maxIndex)
                    {
                        index++;
                        if (index > 1 && index < maxIndex)
                        {
                            rectTransform.offsetMax -= new Vector2(0, -64);
                        }
                    }
                    else
                    {
                        index = 0;
                        rectTransform.offsetMax = Vector2.zero;
                    }
    
                } else if(Input.GetAxisRaw("Vertical") > 0 || verticalMovement>0) {
                    
                    if (index > 0)
                    {
                        index--;
                        if(index < maxIndex - 1 && index > 0)
                        {
                            rectTransform.offsetMax -= new Vector2(0, 64);
                        }
                    } 
                    else
                    {
                        index = maxIndex;
                        rectTransform.offsetMax = new Vector2(0, (maxIndex - 2) * 64);
                    }
                }
                keyDown = true;
            } 
        } 
        else{
            keyDown = false;
        }
    }

    public virtual void OnEnable() 
    {
        // This method is supposed to be overridden
        // in child classes that inherit from this class 
    }
}
